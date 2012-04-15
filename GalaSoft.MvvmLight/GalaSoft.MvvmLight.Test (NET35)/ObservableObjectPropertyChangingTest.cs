using System;
using GalaSoft.MvvmLight.Test.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GalaSoft.MvvmLight.Test
{
    [TestClass]
    public class ObservableObjectPropertyChangingTest
    {
        [TestMethod]
        public void TestPropertyChangingNoBroadcast()
        {
            var receivedDateTimeLocal = DateTime.MinValue;

            var vm = new TestClassWithObservableObject();
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == TestClassWithObservableObject.LastChangedPropertyName)
                {
                    receivedDateTimeLocal = vm.LastChanged;
                }
            };

            var receivedPropertyChanging = false;

            vm.PropertyChanging += (s, e) =>
                                   {
                                       if (e.PropertyName == TestClassWithObservableObject.LastChangedPropertyName)
                                       {
                                           Assert.AreEqual(DateTime.MinValue, receivedDateTimeLocal);
                                           Assert.AreEqual(DateTime.MinValue, vm.LastChanged);
                                           receivedPropertyChanging = true;
                                       }
                                   };

            var now = DateTime.Now;
            vm.LastChanged = now;
            Assert.AreEqual(now, vm.LastChanged);
            Assert.AreEqual(now, receivedDateTimeLocal);
            Assert.IsTrue(receivedPropertyChanging);
        }

        [TestMethod]
        public void TestPropertyChangingNoMagicString()
        {
            var receivedDateTimeLocal = DateTime.MinValue;

            var vm = new TestClassWithObservableObject();
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "LastChangedNoMagicString")
                {
                    receivedDateTimeLocal = vm.LastChangedNoMagicString;
                }
            };

            var receivedPropertyChanging = false;

            vm.PropertyChanging += (s, e) =>
            {
                if (e.PropertyName == "LastChangedNoMagicString")
                {
                    Assert.AreEqual(DateTime.MinValue, receivedDateTimeLocal);
                    Assert.AreEqual(DateTime.MinValue, vm.LastChangedNoMagicString);
                    receivedPropertyChanging = true;
                }
            };

            var now = DateTime.Now;
            vm.LastChangedNoMagicString = now;
            Assert.AreEqual(now, vm.LastChangedNoMagicString);
            Assert.AreEqual(now, receivedDateTimeLocal);
            Assert.IsTrue(receivedPropertyChanging);
        }

        [TestMethod]
#if !NET40
#if DEBUG
        [ExpectedException(typeof(ArgumentException))]
#endif
#else
        // For some reason the VS test adapter throws exception even in Release mode
        [ExpectedException(typeof(ArgumentException))]
#endif
        public void TestRaisePropertyChangingValidInvalidPropertyName()
        {
            var vm = new TestClassWithObservableObject();

            var receivedPropertyChanging = false;
            var invalidPropertyNameReceived = false;
            vm.PropertyChanging += (s, e) =>
            {
                if (e.PropertyName == TestClassWithObservableObject.LastChangedPropertyName)
                {
                    receivedPropertyChanging = true;
                }
                else
                {
                    invalidPropertyNameReceived = true;
                }
            };

            vm.RaisePropertyChangingPublic(TestClassWithObservableObject.LastChangedPropertyName);

            Assert.IsTrue(receivedPropertyChanging);
            Assert.IsFalse(invalidPropertyNameReceived);

            vm.RaisePropertyChangingPublic(TestClassWithObservableObject.LastChangedPropertyName + "1");

            Assert.IsTrue(invalidPropertyNameReceived);
        }

        [TestMethod]
        public void TestPropertyChangingWithSet()
        {
            var instance = new TestClassWithObservableObject();

            const int value1 = 1234;
            const int value2 = 5678;

            instance.PropertyWithSet = value1;

            var changingWasRaised = false;
            var changedWasRaised = false;

            instance.PropertyChanging += (s, e) =>
            {
                if (e.PropertyName != TestClassWithObservableObject.PropertyWithSetPropertyName)
                {
                    return;
                }

                var sender = (TestClassWithObservableObject)s;
                Assert.AreSame(instance, sender);

                Assert.AreEqual(value1, instance.PropertyWithSet);
                changingWasRaised = true;
            };

            instance.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName != TestClassWithObservableObject.PropertyWithSetPropertyName)
                {
                    return;
                }

                var sender = (TestClassWithObservableObject)s;
                Assert.AreSame(instance, sender);

                Assert.AreEqual(value2, instance.PropertyWithSet);
                changedWasRaised = true;
            };

            instance.PropertyWithSet = value2;

            Assert.IsTrue(changingWasRaised);
            Assert.IsTrue(changedWasRaised);
        }

        [TestMethod]
        public void TestPropertyChangingWithStringWithSet()
        {
            var instance = new TestClassWithObservableObject();

            const int value1 = 1234;
            const int value2 = 5678;

            instance.PropertyWithStringSet = value1;

            var changingWasRaised = false;
            var changedWasRaised = false;

            instance.PropertyChanging += (s, e) =>
            {
                if (e.PropertyName != TestClassWithObservableObject.PropertyWithStringSetPropertyName)
                {
                    return;
                }

                var sender = (TestClassWithObservableObject)s;
                Assert.AreSame(instance, sender);

                Assert.AreEqual(value1, instance.PropertyWithStringSet);
                changingWasRaised = true;
            };

            instance.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName != TestClassWithObservableObject.PropertyWithStringSetPropertyName)
                {
                    return;
                }

                var sender = (TestClassWithObservableObject)s;
                Assert.AreSame(instance, sender);

                Assert.AreEqual(value2, instance.PropertyWithStringSet);
                changedWasRaised = true;
            };

            instance.PropertyWithStringSet = value2;

            Assert.IsTrue(changingWasRaised);
            Assert.IsTrue(changedWasRaised);
        }
    }
}
