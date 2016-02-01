using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Test.Controls;
using GalaSoft.MvvmLight.Test.ViewModel;
using NUnit.Framework;

#if ANDROID
using Android.App;
using Android.Widget;
#elif __IOS__
using UIKit;
#endif

namespace GalaSoft.MvvmLight.Test.Binding
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ConverterTest
    {
        public TestViewModel Vm
        {
            get;
            private set;
        }

#if ANDROID
        public EditText Text
        {
            get;
            private set;
        }
#elif __IOS__
        public UITextViewEx Text
        {
            get;
            private set;
        }
#endif

        [Test]
        public void BindingConverter_ConvertDateTimeToText_NoError()
        {
            var now = DateTime.Now;

            Vm = new TestViewModel
            {
                Date = now
            };

#if ANDROID
            Text = new EditText(Application.Context);
#elif __IOS__
            Text = new UITextViewEx();
#endif

            this.SetBinding(
                () => Vm.Date,
                () => Text.Text)
                .ConvertSourceToTarget(d => d.Date.ToShortDateString());

            Assert.AreEqual(now, Vm.Date);
            Assert.AreEqual(now.ToShortDateString(), Text.Text);

            Vm.Date += TimeSpan.FromDays(3);

            Assert.AreEqual((now + TimeSpan.FromDays(3)).ToShortDateString(), Text.Text);
        }

        [Test]
        public void BindingConverter_ConvertDateTimeTwoWayToText_NoError()
        {
            var now = DateTime.Now;

            Vm = new TestViewModel
            {
                Date = now
            };

#if ANDROID
            Text = new EditText(Application.Context);
#elif __IOS__
            Text = new UITextViewEx();
#endif

            this.SetBinding(
                () => Vm.Date,
                () => Text.Text,
                BindingMode.TwoWay)
                .ConvertSourceToTarget(d => d.Date.ToShortDateString())
                .ConvertTargetToSource(d => DateTime.ParseExact(d, "dd/MM/yyyy", CultureInfo.InvariantCulture));

            Assert.AreEqual(now, Vm.Date);
            Assert.AreEqual(now.ToShortDateString(), Text.Text);
            Vm.Date += TimeSpan.FromDays(3);
            Assert.AreEqual((now + TimeSpan.FromDays(3)).ToShortDateString(), Text.Text);

            var newDateString = "13/04/1971";
            var newDate = new DateTime(1971, 4, 13);
            Text.Text = newDateString;

            Assert.AreEqual(newDateString, Text.Text);
            Assert.AreEqual(newDate, Vm.Date);
        }

        [Test]
        public void BindingConverter_ConvertInvalidDateConversion_NoError()
        {
            var vmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "13/04/1971"
                }
            };

            var vmTarget = new TestViewModel();

            var binding = new Binding<string, DateTime>(
                vmSource,
                () => vmSource.Model.MyProperty,
                vmTarget,
                () => vmTarget.Date)
                .ConvertSourceToTarget(d => DateTime.ParseExact(d, "dd/MM/yyyy", CultureInfo.InvariantCulture));

            var referenceDate = new DateTime(1971, 4, 13);
            Assert.AreEqual(referenceDate, vmTarget.Date);

            var newDateString = "13/04/197"; // Invalid date string
            vmSource.Model.MyProperty = newDateString;

            Assert.AreEqual(referenceDate, vmTarget.Date);

            newDateString = "13/04/1972"; // Valid date string
            vmSource.Model.MyProperty = newDateString;

            referenceDate = new DateTime(1972, 4, 13);
            Assert.AreEqual(referenceDate, vmTarget.Date);
        }

        [Test]
        public void BindingConverter_ConvertBackInvalidDateConversion_NoError()
        {
            var date = DateTime.Now;

            Vm = new TestViewModel
            {
                Date = date
            };

#if ANDROID
            Text = new EditText(Application.Context);
#elif __IOS__
            Text = new UITextViewEx();
#endif

            this.SetBinding(
                () => Vm.Date,
                () => Text.Text,
                BindingMode.TwoWay)
                .ConvertSourceToTarget(d => d.Date.ToShortDateString())
                .ConvertTargetToSource(d => DateTime.ParseExact(d, "dd/MM/yyyy", CultureInfo.InvariantCulture));

            Assert.AreEqual(date, Vm.Date);
            Assert.AreEqual(date.ToShortDateString(), Text.Text);

            date += TimeSpan.FromDays(3);

            Vm.Date = date;
            Assert.AreEqual(date.ToShortDateString(), Text.Text);

            var newDateString = "13/04/197"; // Invalid date string
            Text.Text = newDateString;

            Assert.AreEqual(newDateString, Text.Text);
            Assert.AreEqual(date, Vm.Date);

            newDateString = "13/04/1971"; // Valid date string
            Text.Text = newDateString;

            Assert.AreEqual(newDateString, Text.Text);
            Assert.AreEqual(new DateTime(1971, 4, 13), Vm.Date);
        }

        [Test]
        public void BindingConverter_ConvertInvalidDateConversionWithExplicitExceptionHandling_NoError()
        {
            var vmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "13/04/1971"
                }
            };

            var vmTarget = new TestViewModel();

            var binding = new Binding<string, DateTime>(
                vmSource,
                () => vmSource.Model.MyProperty,
                vmTarget,
                () => vmTarget.Date)
                .ConvertSourceToTarget(
                    d =>
                    {
                        try
                        {
                            return DateTime.ParseExact(d, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        }
                        catch (Exception)
                        {
                            return DateTime.MinValue;
                        }
                    });

            var referenceDate = new DateTime(1971, 4, 13);
            Assert.AreEqual(referenceDate, vmTarget.Date);

            var newDateString = "13/04/197"; // Invalid date string
            vmSource.Model.MyProperty = newDateString;

            Assert.AreEqual(DateTime.MinValue, vmTarget.Date);

            newDateString = "13/04/1972"; // Valid date string
            vmSource.Model.MyProperty = newDateString;

            referenceDate = new DateTime(1972, 4, 13);
            Assert.AreEqual(referenceDate, vmTarget.Date);
        }

        [Test]
        public void BindingConverter_ConvertBackFromMinDate_NoError()
        {
            Vm = new TestViewModel();

#if ANDROID
            Text = new EditText(Application.Context);
#elif __IOS__
            Text = new UITextViewEx();
#endif

            this.SetBinding(
                () => Vm.Date,
                () => Text.Text,
                BindingMode.TwoWay)
                .ConvertSourceToTarget(d => d.Date.ToShortDateString())
                .ConvertTargetToSource(d => DateTime.ParseExact(d, "dd/MM/yyyy", CultureInfo.InvariantCulture));

            Assert.AreEqual(DateTime.MinValue, Vm.Date);
            Assert.AreEqual(DateTime.MinValue.ToShortDateString(), Text.Text);

            var newDateString = "01/01/000"; // Invalid date string
            Text.Text = newDateString;

            Assert.AreEqual(newDateString, Text.Text);
            Assert.AreEqual(DateTime.MinValue, Vm.Date);

            newDateString = "01/01/0002"; // Valid date string
            Text.Text = newDateString;

            Assert.AreEqual(newDateString, Text.Text);
            Assert.AreEqual(new DateTime(2, 1, 1), Vm.Date);
        }
    }
}