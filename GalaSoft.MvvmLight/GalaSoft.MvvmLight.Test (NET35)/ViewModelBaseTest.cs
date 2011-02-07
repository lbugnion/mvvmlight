using System;
using System.ComponentModel;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Test.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GalaSoft.MvvmLight.Helpers;

namespace GalaSoft.MvvmLight.Test
{
    /// <summary>
    /// Summary description for ViewModelBaseTest
    /// </summary>
    [TestClass]
    public class ViewModelBaseTest
    {
        [TestMethod]
        public void TestDispose()
        {
            Messenger.Reset();

            var vm = new TestViewModel();
            Messenger.Default.Register<string>(vm, vm.HandleStringMessage);

            const string Content1 = "Hello world";
            const string Content2 = "Another message";

            Messenger.Default.Send(Content1);

            Assert.AreEqual(Content1, vm.ReceivedContent);

            vm.Dispose();

            Messenger.Default.Send(Content2);

            Assert.AreEqual(Content1, vm.ReceivedContent);
        }

        [TestMethod]
        public void TestCleanup()
        {
            Messenger.Reset();

            var vm = new TestViewModel();
            Messenger.Default.Register<string>(vm, vm.HandleStringMessage);

            const string Content1 = "Hello world";
            const string Content2 = "Another message";

            Messenger.Default.Send(Content1);

            Assert.AreEqual(Content1, vm.ReceivedContent);

            var cleanupVm = vm as ICleanup;
            cleanupVm.Cleanup();

            Assert.IsTrue(vm.CleanupWasCalled);

            Messenger.Default.Send(Content2);

            Assert.AreEqual(Content1, vm.ReceivedContent);
        }

        [TestMethod]
        public void TestPropertyChangedSend()
        {
            Messenger.Reset();
            var receivedDateTimeMessengerOld = DateTime.MaxValue;
            var receivedDateTimeMessengerNew = DateTime.MinValue;
            var receivedDateTimeLocal = DateTime.MinValue;

            Messenger.Default.Register<PropertyChangedMessage<DateTime>>(this, m =>
                {
                    if (m.PropertyName == TestViewModel.LastChanged1PropertyName)
                    {
                        receivedDateTimeMessengerOld = m.OldValue;
                        receivedDateTimeMessengerNew = m.NewValue;
                    }
                });

            var vm = new TestViewModel();
            vm.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == TestViewModel.LastChanged1PropertyName)
                    {
                        receivedDateTimeLocal = vm.LastChanged1;
                    }
                };

            var now = DateTime.Now;
            vm.LastChanged1 = now;

            Assert.AreEqual(now, vm.LastChanged1);
            Assert.AreEqual(DateTime.MinValue, receivedDateTimeMessengerOld);
            Assert.AreEqual(now, receivedDateTimeMessengerNew);
            Assert.AreEqual(now, receivedDateTimeLocal);
        }

        [TestMethod]
        public void TestPropertyChangedSendWithCustomMessenger()
        {
            var receivedDateTime1 = DateTime.MinValue;
            var receivedDateTime2 = DateTime.MinValue;

            var messenger = new Messenger();

            messenger.Register<PropertyChangedMessage<DateTime>>(this, m => receivedDateTime1 = m.NewValue);
            Messenger.Default.Register<PropertyChangedMessage<DateTime>>(this, m => receivedDateTime2 = m.NewValue);

            var vm = new TestViewModel(messenger);

            var now = DateTime.Now;
            vm.LastChanged1 = now;
            Assert.AreEqual(now, vm.LastChanged1);
            Assert.AreEqual(now, receivedDateTime1);
            Assert.AreEqual(DateTime.MinValue, receivedDateTime2);
        }

        [TestMethod]
        public void TestPropertyChangeNoBroadcast()
        {
            Messenger.Reset();
            var receivedDateTimeLocal = DateTime.MinValue;
            var receivedDateTimeMessenger = DateTime.MinValue;

            Messenger.Default.Register<PropertyChangedMessage<DateTime>>(this, m =>
            {
                if (m.PropertyName == TestViewModel.LastChanged2PropertyName)
                {
                    receivedDateTimeMessenger = m.NewValue;
                }
            });

            var vm = new TestViewModel();
            vm.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == TestViewModel.LastChanged2PropertyName)
                    {
                        receivedDateTimeLocal = vm.LastChanged2;
                    }
                };

            var now = DateTime.Now;
            vm.LastChanged2 = now;
            Assert.AreEqual(now, vm.LastChanged2);
            Assert.AreEqual(now, receivedDateTimeLocal);
            Assert.AreEqual(DateTime.MinValue, receivedDateTimeMessenger);
        }

        [TestMethod]
        public void TestPropertyChangedSendNoMagicString()
        {
            Messenger.Reset();
            var receivedDateTimeMessengerOld = DateTime.MaxValue;
            var receivedDateTimeMessengerNew = DateTime.MinValue;
            var receivedDateTimeLocal = DateTime.MinValue;

            Messenger.Default.Register<PropertyChangedMessage<DateTime>>(this, m =>
            {
                if (m.PropertyName == "LastChanged1")
                {
                    receivedDateTimeMessengerOld = m.OldValue;
                    receivedDateTimeMessengerNew = m.NewValue;
                }
            });

            var vm = new TestViewModelNoMagicString();
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "LastChanged1")
                {
                    receivedDateTimeLocal = vm.LastChanged1;
                }
            };

            var now = DateTime.Now;
            vm.LastChanged1 = now;

            Assert.AreEqual(now, vm.LastChanged1);
            Assert.AreEqual(DateTime.MinValue, receivedDateTimeMessengerOld);
            Assert.AreEqual(now, receivedDateTimeMessengerNew);
            Assert.AreEqual(now, receivedDateTimeLocal);
        }

        [TestMethod]
        public void TestPropertyChangedSendWithCustomMessengerNoMagicString()
        {
            var receivedDateTime1 = DateTime.MinValue;
            var receivedDateTime2 = DateTime.MinValue;

            var messenger = new Messenger();

            messenger.Register<PropertyChangedMessage<DateTime>>(this, m => receivedDateTime1 = m.NewValue);
            Messenger.Default.Register<PropertyChangedMessage<DateTime>>(this, m => receivedDateTime2 = m.NewValue);

            var vm = new TestViewModelNoMagicString(messenger);

            var now = DateTime.Now;
            vm.LastChanged1 = now;
            Assert.AreEqual(now, vm.LastChanged1);
            Assert.AreEqual(now, receivedDateTime1);
            Assert.AreEqual(DateTime.MinValue, receivedDateTime2);
        }

        [TestMethod]
        public void TestPropertyChangeNoBroadcastNoMagicString()
        {
            Messenger.Reset();
            var receivedDateTimeLocal = DateTime.MinValue;
            var receivedDateTimeMessenger = DateTime.MinValue;

            Messenger.Default.Register<PropertyChangedMessage<DateTime>>(this, m =>
            {
                if (m.PropertyName == "LastChanged2")
                {
                    receivedDateTimeMessenger = m.NewValue;
                }
            });

            var vm = new TestViewModelNoMagicString();
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "LastChanged2")
                {
                    receivedDateTimeLocal = vm.LastChanged2;
                }
            };

            var now = DateTime.Now;
            vm.LastChanged2 = now;
            Assert.AreEqual(now, vm.LastChanged2);
            Assert.AreEqual(now, receivedDateTimeLocal);
            Assert.AreEqual(DateTime.MinValue, receivedDateTimeMessenger);
        }

        [TestMethod]
        public void TestPropertyChangedSendInline()
        {
            var receivedDateTimeLocal = DateTime.MinValue;

            var vm = new TestViewModelInlinePropertyChanged();
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "LastChanged1")
                {
                    receivedDateTimeLocal = vm.LastChanged1;
                }
            };

            var now = DateTime.Now;
            vm.LastChanged1 = now;

            Assert.AreEqual(now, vm.LastChanged1);
            Assert.AreEqual(now, receivedDateTimeLocal);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPropertyChangedSendInlineOutOfSetter()
        {
            var vm = new TestViewModelInlinePropertyChanged();
            vm.RaisePropertyChangedInlineOutOfPropertySetter();
        }

        [TestMethod]
#if DEBUG
        [ExpectedException(typeof(ArgumentException))]
#endif
        public void TestRaiseValidInvalidPropertyName()
        {
            var vm = new ViewModelStub();

            var receivedPropertyChanged = false;
            var invalidPropertyNameReceived = false;
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == ViewModelStub.RealPropertyPropertyName)
                {
                    receivedPropertyChanged = true;
                }
                else
                {
                    invalidPropertyNameReceived = true;
                }
            };

            vm.RaisePropertyChanged(ViewModelStub.RealPropertyPropertyName);

            Assert.IsTrue(receivedPropertyChanged);
            Assert.IsFalse(invalidPropertyNameReceived);

            vm.RaisePropertyChanged(ViewModelStub.RealPropertyPropertyName + "1");

            Assert.IsTrue(invalidPropertyNameReceived);
        }
    }
}