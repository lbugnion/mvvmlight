using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Test.Stubs;
using GalaSoft.MvvmLight.Test.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GalaSoft.MvvmLight.Test
{
    [TestClass]
    public class NotifyPropertyChangedTest
    {
        [TestMethod]
        public void TestPropertyChangeNoBroadcast()
        {
            var receivedDateTimeLocal = DateTime.MinValue;

            var vm = new TestClassWithNotifyPropertyChanged();
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == TestClassWithNotifyPropertyChanged.LastChangedPropertyName)
                {
                    receivedDateTimeLocal = vm.LastChanged;
                }
            };

            var now = DateTime.Now;
            vm.LastChanged = now;
            Assert.AreEqual(now, vm.LastChanged);
            Assert.AreEqual(now, receivedDateTimeLocal);
        }

        [TestMethod]
        public void TestPropertyChangeNoMagicString()
        {
            var receivedDateTimeLocal = DateTime.MinValue;

            var vm = new TestClassWithNotifyPropertyChanged();
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "LastChangedNoMagicString")
                {
                    receivedDateTimeLocal = vm.LastChangedNoMagicString;
                }
            };

            var now = DateTime.Now;
            vm.LastChangedNoMagicString = now;
            Assert.AreEqual(now, vm.LastChangedNoMagicString);
            Assert.AreEqual(now, receivedDateTimeLocal);
        }

        [TestMethod]
        public void TestPropertyChangedSendInline()
        {
            var receivedDateTimeLocal = DateTime.MinValue;

            var vm = new TestClassWithNotifyPropertyChanged();
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "LastChangedInline")
                {
                    receivedDateTimeLocal = vm.LastChangedInline;
                }
            };

            var now = DateTime.Now;
            vm.LastChangedInline = now;

            Assert.AreEqual(now, vm.LastChangedInline);
            Assert.AreEqual(now, receivedDateTimeLocal);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPropertyChangedSendInlineOutOfSetter()
        {
            var vm = new TestClassWithNotifyPropertyChanged();
            vm.RaisePropertyChangedInlineOutOfPropertySetter();
        }

        [TestMethod]
#if DEBUG
        [ExpectedException(typeof(ArgumentException))]
#endif
        public void TestRaiseValidInvalidPropertyName()
        {
            var vm = new TestClassWithNotifyPropertyChanged();

            var receivedPropertyChanged = false;
            var invalidPropertyNameReceived = false;
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == TestClassWithNotifyPropertyChanged.LastChangedPropertyName)
                {
                    receivedPropertyChanged = true;
                }
                else
                {
                    invalidPropertyNameReceived = true;
                }
            };

            vm.RaisePropertyChangedPublic(TestClassWithNotifyPropertyChanged.LastChangedPropertyName);

            Assert.IsTrue(receivedPropertyChanged);
            Assert.IsFalse(invalidPropertyNameReceived);

            vm.RaisePropertyChangedPublic(TestClassWithNotifyPropertyChanged.LastChangedPropertyName + "1");

            Assert.IsTrue(invalidPropertyNameReceived);
        }
    }
}
