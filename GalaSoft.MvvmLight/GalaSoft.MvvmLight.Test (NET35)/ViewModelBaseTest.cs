using System;
using System.ComponentModel;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Test.Stubs;
using GalaSoft.MvvmLight.Test.ViewModel;

#if NETFX_CORE
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

#if NETFX_CORE
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
#else
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;
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

            const string content1 = "Hello world";
            const string content2 = "Another message";

            Messenger.Default.Send(content1);

            Assert.AreEqual(content1, vm.ReceivedContent);

            var cleanupVm = vm as ICleanup;
            cleanupVm.Cleanup();

            Assert.IsTrue(vm.CleanupWasCalled);

            Messenger.Default.Send(content2);

            Assert.AreEqual(content1, vm.ReceivedContent);
        }

        [TestMethod]
        public void TestPropertyChangedSend()
        {
            Messenger.Reset();
            var receivedDateTimeMessengerOldChanged = DateTime.MaxValue;
            var receivedDateTimeMessengerNewChanged = DateTime.MinValue;
            var receivedDateTimeLocalChanged = DateTime.MinValue;
            var receivedDateTimeLocalChanging = DateTime.MinValue;

            Messenger.Default.Register<PropertyChangedMessage<DateTime>>(this, m =>
                {
                    if (m.PropertyName == TestViewModel.LastChanged1PropertyName)
                    {
                        receivedDateTimeMessengerOldChanged = m.OldValue;
                        receivedDateTimeMessengerNewChanged = m.NewValue;
                    }
                });

            var vm = new TestViewModel();
            vm.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == TestViewModel.LastChanged1PropertyName)
                    {
                        receivedDateTimeLocalChanged = vm.LastChanged1;
                    }
                };

            vm.PropertyChanging += (s, e) =>
            {
                if (e.PropertyName == TestViewModel.LastChanged1PropertyName)
                {
                    receivedDateTimeLocalChanging = vm.LastChanged1;
                }
            };

            var now = DateTime.Now;
            vm.LastChanged1 = now;

            Assert.AreEqual(now, vm.LastChanged1);
            Assert.AreEqual(DateTime.MaxValue, receivedDateTimeMessengerOldChanged);
            Assert.AreEqual(now, receivedDateTimeMessengerNewChanged);
            Assert.AreEqual(now, receivedDateTimeLocalChanged);
            Assert.AreEqual(DateTime.MaxValue, receivedDateTimeLocalChanging);
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
        public void TestPropertyChangedNoBroadcast()
        {
            Messenger.Reset();
            var receivedDateTimeLocalChanged = DateTime.MinValue;
            var receivedDateTimeLocalChanging = DateTime.MinValue;
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
                        receivedDateTimeLocalChanged = vm.LastChanged2;
                    }
                };

            vm.PropertyChanging += (s, e) =>
            {
                if (e.PropertyName == TestViewModel.LastChanged2PropertyName)
                {
                    receivedDateTimeLocalChanging = vm.LastChanged2;
                }
            };

            var now = DateTime.Now;
            vm.LastChanged2 = now;
            Assert.AreEqual(now, vm.LastChanged2);
            Assert.AreEqual(now, receivedDateTimeLocalChanged);
            Assert.AreEqual(DateTime.MaxValue, receivedDateTimeLocalChanging);
            Assert.AreEqual(DateTime.MinValue, receivedDateTimeMessenger);
        }

#if !SL3
        [TestMethod]
        public void TestPropertyChangedSendNoMagicString()
        {
            Messenger.Reset();
            var receivedDateTimeMessengerOld = DateTime.MaxValue;
            var receivedDateTimeMessengerNew = DateTime.MinValue;
            var receivedDateTimeLocalChanged = DateTime.MinValue;
            var receivedDateTimeLocalChanging = DateTime.MinValue;

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
                    receivedDateTimeLocalChanged = vm.LastChanged1;
                }
            };

            vm.PropertyChanging += (s, e) =>
            {
                if (e.PropertyName == "LastChanged1")
                {
                    receivedDateTimeLocalChanging = vm.LastChanged1;
                }
            };

            var now = DateTime.Now;
            vm.LastChanged1 = now;

            Assert.AreEqual(now, vm.LastChanged1);
            Assert.AreEqual(DateTime.MaxValue, receivedDateTimeMessengerOld);
            Assert.AreEqual(now, receivedDateTimeMessengerNew);
            Assert.AreEqual(now, receivedDateTimeLocalChanged);
            Assert.AreEqual(DateTime.MaxValue, receivedDateTimeLocalChanging);
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
        public void TestPropertyChangedNoBroadcastNoMagicString()
        {
            Messenger.Reset();
            var receivedDateTimeLocalChanged = DateTime.MinValue;
            var receivedDateTimeLocalChanging = DateTime.MinValue;
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
                    receivedDateTimeLocalChanged = vm.LastChanged2;
                }
            };

            vm.PropertyChanging += (s, e) =>
            {
                if (e.PropertyName == "LastChanged2")
                {
                    receivedDateTimeLocalChanging = vm.LastChanged2;
                }
            };

            var now = DateTime.Now;
            vm.LastChanged2 = now;
            Assert.AreEqual(now, vm.LastChanged2);
            Assert.AreEqual(now, receivedDateTimeLocalChanged);
            Assert.AreEqual(DateTime.MaxValue, receivedDateTimeLocalChanging);
            Assert.AreEqual(DateTime.MinValue, receivedDateTimeMessenger);
        }
#endif

        [TestMethod]
        public void TestRaiseValidInvalidPropertyName()
        {
            var vm = new ViewModelStub();

            var receivedPropertyChanged = false;
            var invalidPropertyChangedNameReceived = false;
            var receivedPropertyChanging = false;
            var invalidPropertyChangingNameReceived = false;
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == ViewModelStub.RealPropertyPropertyName)
                {
                    receivedPropertyChanged = true;
                }
                else
                {
                    invalidPropertyChangedNameReceived = true;
                }
            };

            vm.PropertyChanging += (s, e) =>
            {
                if (e.PropertyName == ViewModelStub.RealPropertyPropertyName)
                {
                    receivedPropertyChanging = true;
                }
                else
                {
                    invalidPropertyChangingNameReceived = true;
                }
            };

            vm.RaisePropertyChanging(ViewModelStub.RealPropertyPropertyName);
            vm.RaisePropertyChanged(ViewModelStub.RealPropertyPropertyName);

            Assert.IsTrue(receivedPropertyChanged);
            Assert.IsFalse(invalidPropertyChangedNameReceived);

            Assert.IsTrue(receivedPropertyChanging);
            Assert.IsFalse(invalidPropertyChangingNameReceived);

            try
            {
                vm.RaisePropertyChanging(ViewModelStub.RealPropertyPropertyName + "1");

#if DEBUG
                Assert.Fail("ArgumentException was expected");
#else
                Assert.IsTrue(invalidPropertyChangingNameReceived);
#endif
            }
            catch (ArgumentException)
            {
            }

            try
            {
                vm.RaisePropertyChanged(ViewModelStub.RealPropertyPropertyName + "1");

#if DEBUG
                Assert.Fail("ArgumentException was expected");
#else
                Assert.IsTrue(invalidPropertyChangedNameReceived);
#endif
            }
            catch (ArgumentException)
            {
            }
        }

        [TestMethod]
        public void TestRaiseWithEmptyString()
        {
#if !NETFX_CORE
            var vm = new TestViewModel();

            const string value1 = "Hello";
            const string value2 = "World";

            var textBox1 = new TextBox();
            var textBox2 = new TextBox();

            var binding1 = new Binding
            {
                Path = new PropertyPath("TestProperty1"),
                Source = vm,
            };

            var binding2 = new Binding
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
#else
            var vm = new TestViewModel();
            var raised = false;
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == string.Empty)
                {
                    raised = true;
                }
            };

            vm.RaiseEmptyPropertyChanged();
            Assert.IsTrue(raised);
#endif
        }

        [TestMethod]
        public void TestRaiseWithNullString()
        {
#if !NETFX_CORE
            var vm = new TestViewModel();

            const string value1 = "Hello";
            const string value2 = "World";

            var textBox1 = new TextBox();
            var textBox2 = new TextBox();

            var binding1 = new Binding
            {
                Path = new PropertyPath("TestProperty1"),
                Source = vm,
            };

            var binding2 = new Binding
            {
                Path = new PropertyPath("TestProperty2"),
                Source = vm,
            };

            BindingOperations.SetBinding(textBox1, TextBox.TextProperty, binding1);
            BindingOperations.SetBinding(textBox2, TextBox.TextProperty, binding2);

            Assert.AreEqual(string.Empty, textBox1.Text);
            Assert.AreEqual(string.Empty, textBox2.Text);

            vm.RaiseNullPropertyChanged(value1, value2);

            Assert.AreEqual(value1, textBox1.Text);
            Assert.AreEqual(value2, textBox2.Text);
#else
            var vm = new TestViewModel();
            var raised = false;
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == string.Empty)
                {
                    raised = true;
                }
            };

            vm.RaiseNullPropertyChanged();
            Assert.IsFalse(raised); // Doesn't work in WinRT
#endif
        }

        [TestMethod]
        public void TestRaiseWithEmptyStringAndBroadcast()
        {
            var vm = new TestViewModel();

            const string value1 = "Hello";
            const string value2 = "World";

            var messengerValue = string.Empty;
            vm.GetMessengerInstance().Register<string>(this, msg => messengerValue = msg);

            try
            {
                vm.RaiseEmptyPropertyChangedWithBroadcast(value1, value2);
                Assert.Fail("ArgumentException was expected");
            }
            catch (ArgumentException)
            {
            }
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

        static void InstancePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Void
        }

#if !SL3
        [TestMethod]
        public void TestSetBroadcast()
        {
            Messenger.Reset();

            var vm = new ViewModelStub();
            const int expectedValue = 1234;
            var receivedValueChanged = 0;
            var receivedValueChanging = 0;
            var receivedValueWithMessenger = 0;

            Messenger.Default.Register<PropertyChangedMessage<int>>(this, msg => receivedValueWithMessenger = msg.NewValue);

            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == ViewModelStub.PropertyWithSetBroadcastPropertyName)
                {
                    receivedValueChanged = vm.PropertyWithSetBroadcast;
                }
            };

            vm.PropertyChanging += (s, e) =>
            {
                if (e.PropertyName == ViewModelStub.PropertyWithSetBroadcastPropertyName)
                {
                    receivedValueChanging = vm.PropertyWithSetBroadcast;
                }
            };

            vm.PropertyWithSetBroadcast = expectedValue;
            Assert.AreEqual(expectedValue, receivedValueChanged);
            Assert.AreEqual(-1, receivedValueChanging);
            Assert.AreEqual(expectedValue, receivedValueWithMessenger);
        }

        [TestMethod]
        public void TestSetNoBroadcast()
        {
            Messenger.Reset();

            var vm = new ViewModelStub();
            const int expectedValue = 1234;
            var receivedValueChanged = 0;
            var receivedValueChanging = 0;
            var receivedValueWithMessenger = 0;

            Messenger.Default.Register<PropertyChangedMessage<int>>(this, msg => receivedValueWithMessenger = msg.NewValue);

            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == ViewModelStub.PropertyWithSetNoBroadcastPropertyName)
                {
                    receivedValueChanged = vm.PropertyWithSetNoBroadcast;
                }
            };

            vm.PropertyChanging += (s, e) =>
            {
                if (e.PropertyName == ViewModelStub.PropertyWithSetNoBroadcastPropertyName)
                {
                    receivedValueChanging = vm.PropertyWithSetNoBroadcast;
                }
            };

            vm.PropertyWithSetNoBroadcast = expectedValue;
            Assert.AreEqual(expectedValue, receivedValueChanged);
            Assert.AreEqual(-1, receivedValueChanging);
            Assert.AreEqual(0, receivedValueWithMessenger);
        }

        [TestMethod]
        public void TestSetWithStringBroadcast()
        {
            Messenger.Reset();

            var vm = new ViewModelStub();
            const int expectedValue = 1234;
            var receivedValueChanged = 0;
            var receivedValueChanging = 0;
            var receivedValueWithMessenger = 0;

            Messenger.Default.Register<PropertyChangedMessage<int>>(this, msg => receivedValueWithMessenger = msg.NewValue);

            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == ViewModelStub.PropertyWithStringSetBroadcastPropertyName)
                {
                    receivedValueChanged = vm.PropertyWithStringSetBroadcast;
                }
            };

            vm.PropertyChanging += (s, e) =>
            {
                if (e.PropertyName == ViewModelStub.PropertyWithStringSetBroadcastPropertyName)
                {
                    receivedValueChanging = vm.PropertyWithStringSetBroadcast;
                }
            };

            vm.PropertyWithStringSetBroadcast = expectedValue;
            Assert.AreEqual(expectedValue, receivedValueChanged);
            Assert.AreEqual(-1, receivedValueChanging);
            Assert.AreEqual(expectedValue, receivedValueWithMessenger);
        }

        [TestMethod]
        public void TestSetWithStringNoBroadcast()
        {
            Messenger.Reset();

            var vm = new ViewModelStub();
            const int expectedValue = 1234;
            var receivedValueChanged = 0;
            var receivedValueChanging = 0;
            var receivedValueWithMessenger = 0;

            Messenger.Default.Register<PropertyChangedMessage<int>>(this, msg => receivedValueWithMessenger = msg.NewValue);

            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == ViewModelStub.PropertyWithStringSetNoBroadcastPropertyName)
                {
                    receivedValueChanged = vm.PropertyWithStringSetNoBroadcast;
                }
            };

            vm.PropertyChanging += (s, e) =>
            {
                if (e.PropertyName == ViewModelStub.PropertyWithStringSetNoBroadcastPropertyName)
                {
                    receivedValueChanging = vm.PropertyWithStringSetNoBroadcast;
                }
            };

            vm.PropertyWithStringSetNoBroadcast = expectedValue;
            Assert.AreEqual(expectedValue, receivedValueChanged);
            Assert.AreEqual(-1, receivedValueChanging);
            Assert.AreEqual(0, receivedValueWithMessenger);
        }

        [TestMethod]
        public void TestReturnValueWithSetBroadcast()
        {
            var vm = new ViewModelStub();
            const int firstValue = 1234;
            var receivedValueChanged = 0;
            var receivedValueChanging = 0;

            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == ViewModelStub.PropertyWithSetBroadcastPropertyName)
                {
                    receivedValueChanged = vm.PropertyWithSetBroadcast;
                }
            };

            vm.PropertyChanging += (s, e) =>
            {
                if (e.PropertyName == ViewModelStub.PropertyWithSetBroadcastPropertyName)
                {
                    receivedValueChanging = vm.PropertyWithSetBroadcast;
                }
            };

            vm.PropertyWithSetBroadcast = firstValue;
            Assert.AreEqual(-1, receivedValueChanging);
            Assert.AreEqual(firstValue, receivedValueChanged);
            Assert.IsTrue(vm.SetRaisedPropertyChangedEvent);

            vm.PropertyWithSetBroadcast = firstValue;
            Assert.AreEqual(-1, receivedValueChanging);
            Assert.AreEqual(firstValue, receivedValueChanged);
            Assert.IsFalse(vm.SetRaisedPropertyChangedEvent);

            vm.PropertyWithSetBroadcast = firstValue + 1;
            Assert.AreEqual(firstValue, receivedValueChanging);
            Assert.AreEqual(firstValue + 1, receivedValueChanged);
            Assert.IsTrue(vm.SetRaisedPropertyChangedEvent);
        }

        [TestMethod]
        public void TestReturnValueWithStringSetBroadcast()
        {
            var vm = new ViewModelStub();
            const int firstValue = 1234;
            var receivedValueChanged = 0;
            var receivedValueChanging = 0;

            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == ViewModelStub.PropertyWithStringSetBroadcastPropertyName)
                {
                    receivedValueChanged = vm.PropertyWithStringSetBroadcast;
                }
            };

            vm.PropertyChanging += (s, e) =>
            {
                if (e.PropertyName == ViewModelStub.PropertyWithStringSetBroadcastPropertyName)
                {
                    receivedValueChanging = vm.PropertyWithStringSetBroadcast;
                }
            };

            vm.PropertyWithStringSetBroadcast = firstValue;
            Assert.AreEqual(-1, receivedValueChanging);
            Assert.AreEqual(firstValue, receivedValueChanged);
            Assert.IsTrue(vm.SetRaisedPropertyChangedEvent);

            vm.PropertyWithStringSetBroadcast = firstValue;
            Assert.AreEqual(-1, receivedValueChanging);
            Assert.AreEqual(firstValue, receivedValueChanged);
            Assert.IsFalse(vm.SetRaisedPropertyChangedEvent);

            vm.PropertyWithStringSetBroadcast = firstValue + 1;
            Assert.AreEqual(firstValue, receivedValueChanging);
            Assert.AreEqual(firstValue + 1, receivedValueChanged);
            Assert.IsTrue(vm.SetRaisedPropertyChangedEvent);
        }

        [TestMethod]
        public void TestReturnValueWithSetNoBroadcast()
        {
            var vm = new ViewModelStub();
            const int firstValue = 1234;
            var receivedValueChanged = 0;
            var receivedValueChanging = 0;

            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == ViewModelStub.PropertyWithSetNoBroadcastPropertyName)
                {
                    receivedValueChanged = vm.PropertyWithSetNoBroadcast;
                }
            };

            vm.PropertyChanging += (s, e) =>
            {
                if (e.PropertyName == ViewModelStub.PropertyWithSetNoBroadcastPropertyName)
                {
                    receivedValueChanging = vm.PropertyWithSetNoBroadcast;
                }
            };

            vm.PropertyWithSetNoBroadcast = firstValue;
            Assert.AreEqual(-1, receivedValueChanging);
            Assert.AreEqual(firstValue, receivedValueChanged);
            Assert.IsTrue(vm.SetRaisedPropertyChangedEvent);

            vm.PropertyWithSetNoBroadcast = firstValue;
            Assert.AreEqual(-1, receivedValueChanging);
            Assert.AreEqual(firstValue, receivedValueChanged);
            Assert.IsFalse(vm.SetRaisedPropertyChangedEvent);

            vm.PropertyWithSetNoBroadcast = firstValue + 1;
            Assert.AreEqual(firstValue, receivedValueChanging);
            Assert.AreEqual(firstValue + 1, receivedValueChanged);
            Assert.IsTrue(vm.SetRaisedPropertyChangedEvent);
        }

        [TestMethod]
        public void TestReturnValueWithStringSetNoBroadcast()
        {
            var vm = new ViewModelStub();
            const int firstValue = 1234;
            var receivedValueChanged = 0;
            var receivedValueChanging = 0;

            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == ViewModelStub.PropertyWithStringSetNoBroadcastPropertyName)
                {
                    receivedValueChanged = vm.PropertyWithStringSetNoBroadcast;
                }
            };

            vm.PropertyChanging += (s, e) =>
            {
                if (e.PropertyName == ViewModelStub.PropertyWithStringSetNoBroadcastPropertyName)
                {
                    receivedValueChanging = vm.PropertyWithStringSetNoBroadcast;
                }
            };

            vm.PropertyWithStringSetNoBroadcast = firstValue;
            Assert.AreEqual(-1, receivedValueChanging);
            Assert.AreEqual(firstValue, receivedValueChanged);
            Assert.IsTrue(vm.SetRaisedPropertyChangedEvent);

            vm.PropertyWithStringSetNoBroadcast = firstValue;
            Assert.AreEqual(-1, receivedValueChanging);
            Assert.AreEqual(firstValue, receivedValueChanged);
            Assert.IsFalse(vm.SetRaisedPropertyChangedEvent);

            vm.PropertyWithStringSetNoBroadcast = firstValue + 1;
            Assert.AreEqual(firstValue, receivedValueChanging);
            Assert.AreEqual(firstValue + 1, receivedValueChanged);
            Assert.IsTrue(vm.SetRaisedPropertyChangedEvent);
        }

        [TestMethod]
        public void TestRaisePropertyChangedNoMagicStringNullExpression()
        {
            var instance = new TestViewModelNoMagicString();
            instance.PropertyChanged += InstancePropertyChanged;

            try
            {
                instance.RaisePropertyChangedPublic<string>(null);
                Assert.Fail("ArgumentNullException was expected");
            }
            catch (ArgumentNullException)
            {
            }
        }

        [TestMethod]
        public void TestRaisePropertyChangedNoMagicStringNullExpressionWithBroadcast()
        {
            var instance = new TestViewModelNoMagicString();
            instance.PropertyChanged += InstancePropertyChanged;

            try
            {
                instance.RaisePropertyChangedPublic(null, "12", "34", true);
                Assert.Fail("ArgumentNullException was expected");
            }
            catch (ArgumentNullException)
            {
            }
        }

        [TestMethod]
        public void TestRaisePropertyChangedNoMagicStringNonPropertyExpression()
        {
            var instance = new TestViewModelNoMagicString();
            instance.PropertyChanged += InstancePropertyChanged;

            try
            {
                instance.RaisePropertyChangedPublic(() => DummyStringMethod());
                Assert.Fail("ArgumentException was expected");
            }
            catch (ArgumentException)
            {
            }
        }

        [TestMethod]
        public void TestRaisePropertyChangedNoMagicStringNonPropertyExpressionWithBroadcast()
        {
            var instance = new TestViewModelNoMagicString();
            instance.PropertyChanged += InstancePropertyChanged;

            try
            {
                instance.RaisePropertyChangedPublic(() => DummyStringMethod(), "12", "34", true);
                Assert.Fail("ArgumentException was expected");
            }
            catch (ArgumentException)
            {
            }
        }

        [TestMethod]
        public void TestRaisePropertyChangingNoMagicStringNullExpression()
        {
            var instance = new TestViewModelNoMagicString();
            instance.PropertyChanging += InstancePropertyChanging;

            try
            {
                instance.RaisePropertyChangingPublic<string>(null);
                Assert.Fail("ArgumentNullException was expected");
            }
            catch (ArgumentNullException)
            {
            }
        }

        private static void InstancePropertyChanging(object sender, PropertyChangingEventArgs e)
        {
        }

        [TestMethod]
        public void TestRaisePropertyChangingNoMagicStringNonPropertyExpression()
        {
            var instance = new TestViewModelNoMagicString();
            instance.PropertyChanging += InstancePropertyChanging;

            try
            {
                instance.RaisePropertyChangingPublic(() => DummyStringMethod());
                Assert.Fail("ArgumentException was expected");
            }
            catch (ArgumentException)
            {
            }
        }
#endif

        private static string DummyStringMethod()
        {
            return string.Empty;
        }

#if !SILVERLIGHT
#if !NETFX_CORE
        [TestMethod]
        public void TestTypeDescriptor()
        {
            var instance = new TestCustomTypeDescriptor();
            var argumentExceptionWasThrown = false;

            try
            {
                instance.RaisePropertyChangedPublic(
                    TestCustomTypeDescriptor.TestPropertyPropertyName);
            }
            catch (ArgumentException)
            {
                argumentExceptionWasThrown = true;
            }

            Assert.IsFalse(argumentExceptionWasThrown);

            try
            {
                instance.RaisePropertyChangedPublic(
                    TestCustomTypeDescriptor.TestPropertyPropertyName + TestCustomTypeDescriptor.PropertyNameSuffix);
            }
            catch (ArgumentException)
            {
                argumentExceptionWasThrown = true;
            }

            Assert.IsFalse(argumentExceptionWasThrown);

            try
            {
                instance.RaisePropertyChangedPublic(
                    TestCustomTypeDescriptor.TestPropertyPropertyName + "abcd");
            }
            catch (ArgumentException)
            {
                argumentExceptionWasThrown = true;
            }

#if NET40
            Assert.IsTrue(argumentExceptionWasThrown);
#else
#if DEBUG
            Assert.IsTrue(argumentExceptionWasThrown);
#else
            Assert.IsFalse(argumentExceptionWasThrown);
#endif
#endif
        }
#endif
#endif
    }
}