using System;
using System.Diagnostics.CodeAnalysis;
using Android.App;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using NUnit.Framework;

namespace GalaSoft.MvvmLight.Test.Binding
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ObserveEventNonDefaultEventTest
    {
        [Test]
        public void Binding_OneWayFromEditTextToEditTextWithObserveEvent_BindingGetsUpdated()
        {
            var control1 = new EditText(Application.Context);
            var control2 = new EditText(Application.Context);

            var binding = new Binding<string, string>(
                control1,
                () => control1.Text,
                control2,
                () => control2.Text)
                .ObserveSourceEvent<View.LongClickEventArgs>("LongClick");

            Assert.AreEqual(string.Empty, control1.Text);
            Assert.AreEqual(control1.Text, control2.Text);
            var value = DateTime.Now.Ticks.ToString();
            control1.Text = value;
            Assert.AreEqual(value, control1.Text);
            Assert.AreEqual(string.Empty, control2.Text);
            control1.PerformLongClick();
            Assert.AreEqual(control1.Text, control2.Text);
        }

        [Test]
        public void Binding_TwoWayFromEditTextToEditTextWithObserveEvent_BindingGetsUpdated()
        {
            var control1 = new EditText(Application.Context);
            var control2 = new EditText(Application.Context);

            var binding = new Binding<string, string>(
                control1,
                () => control1.Text,
                control2,
                () => control2.Text,
                BindingMode.TwoWay)
                .ObserveSourceEvent<View.LongClickEventArgs>("LongClick")
                .ObserveTargetEvent<View.LongClickEventArgs>("LongClick");

            Assert.AreEqual(string.Empty, control1.Text);
            Assert.AreEqual(control1.Text, control2.Text);
            var value = DateTime.Now.Ticks.ToString();
            control1.Text = value;
            Assert.AreEqual(value, control1.Text);
            Assert.AreEqual(string.Empty, control2.Text);
            control1.PerformLongClick();
            Assert.AreEqual(control1.Text, control2.Text);

            var newValue = value + "Suffix";
            control2.Text = newValue;
            Assert.AreEqual(newValue, control2.Text);
            Assert.AreEqual(value, control1.Text);
            control2.PerformLongClick();
            Assert.AreEqual(control2.Text, control1.Text);
        }
    }
}