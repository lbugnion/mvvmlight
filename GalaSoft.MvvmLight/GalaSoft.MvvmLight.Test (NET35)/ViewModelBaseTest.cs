using System;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Test.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#if WIN8
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml;
#else
using System.Windows.Controls;
using System.Windows.Data;
#endif

namespace GalaSoft.MvvmLight.Test
{
    [TestClass]
    public class ViewModelBaseTest
    {
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

        [TestMethod]
#if WIN8
        [ExpectedException(typeof(NotSupportedException))]
#endif
        public void TestRaiseWithEmptyString()
        {
            var vm = new TestViewModel();

            var value1 = "Hello";
            var value2 = "World";

            var textBox1 = new TextBox();
            var textBox2 = new TextBox();

            var binding1 = new Binding()
            {
                Path = new PropertyPath("TestProperty1"),
                Source = vm,
            };

            var binding2 = new Binding()
            {
                Path = new PropertyPath("TestProperty2"),
                Source = vm,
            };

            BindingOperations.SetBinding(textBox1, TextBox.TextProperty, binding1);
            BindingOperations.SetBinding(textBox2, TextBox.TextProperty, binding2);

            Assert.AreEqual(string.Empty, textBox1.Text);
            Assert.AreEqual(string.Empty, textBox2.Text);

            vm.RaiseEmptyPropertyChanged(value1, value2);

            Assert.AreEqual(value1, textBox1.Text);
            Assert.AreEqual(value2, textBox2.Text);
        }

        [TestMethod]
        public void TestGettingMessengerInstanceWhenNotSet()
        {
            var messenger = new Messenger();
            var vm1 = new TestViewModel(messenger);
            var vm2 = new TestViewModel();

            Assert.AreSame(messenger, vm1.GetMessengerInstance());
            Assert.AreSame(Messenger.Default, vm2.GetMessengerInstance());
        }

        [TestMethod]
        public void TestSetBroadcast()
        {
            Messenger.Reset();

            var vm = new ViewModelStub();
            const int expectedValue = 1234;
            var receivedValue = 0;
            var receivedValueWithMessenger = 0;

            Messenger.Default.Register<PropertyChangedMessage<int>>(this, msg => receivedValueWithMessenger = msg.NewValue);

            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == ViewModelStub.PropertyWithSetBroadcastPropertyName)
                {
                    receivedValue = expectedValue;
                }
            };

            vm.PropertyWithSetBroadcast = expectedValue;
            Assert.AreEqual(expectedValue, receivedValue);
            Assert.AreEqual(expectedValue, receivedValueWithMessenger);
        }

        [TestMethod]
        public void TestSetNoBroadcast()
        {
            Messenger.Reset();

            var vm = new ViewModelStub();
            const int expectedValue = 1234;
            var receivedValue = 0;
            var receivedValueWithMessenger = 0;

            Messenger.Default.Register<PropertyChangedMessage<int>>(this, msg => receivedValueWithMessenger = msg.NewValue);

            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == ViewModelStub.PropertyWithSetNoBroadcastPropertyName)
                {
                    receivedValue = expectedValue;
                }
            };

            vm.PropertyWithSetNoBroadcast = expectedValue;
            Assert.AreEqual(expectedValue, receivedValue);
            Assert.AreEqual(0, receivedValueWithMessenger);
        }

        [TestMethod]
        public void TestSetWithStringBroadcast()
        {
            Messenger.Reset();

            var vm = new ViewModelStub();
            const int expectedValue = 1234;
            var receivedValue = 0;
            var receivedValueWithMessenger = 0;

            Messenger.Default.Register<PropertyChangedMessage<int>>(this, msg => receivedValueWithMessenger = msg.NewValue);

            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == ViewModelStub.PropertyWithStringSetBroadcastPropertyName)
                {
                    receivedValue = expectedValue;
                }
            };

            vm.PropertyWithStringSetBroadcast = expectedValue;
            Assert.AreEqual(expectedValue, receivedValue);
            Assert.AreEqual(expectedValue, receivedValueWithMessenger);
        }

        [TestMethod]
        public void TestSetWithStringNoBroadcast()
        {
            Messenger.Reset();

            var vm = new ViewModelStub();
            const int expectedValue = 1234;
            var receivedValue = 0;
            var receivedValueWithMessenger = 0;

            Messenger.Default.Register<PropertyChangedMessage<int>>(this, msg => receivedValueWithMessenger = msg.NewValue);

            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == ViewModelStub.PropertyWithStringSetNoBroadcastPropertyName)
                {
                    receivedValue = expectedValue;
                }
            };

            vm.PropertyWithStringSetNoBroadcast = expectedValue;
            Assert.AreEqual(expectedValue, receivedValue);
            Assert.AreEqual(0, receivedValueWithMessenger);
        }
    }
}