using System;
using System.ComponentModel;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Test.Messaging;
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

    public class ViewModelStub : ViewModelBase
    {
        /// <summary>
        /// The <see cref="RealProperty" /> property's name.
        /// </summary>
        public const string RealPropertyPropertyName = "RealProperty";

        private bool _realProperty;

        /// <summary>
        /// Gets the RealProperty property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool RealProperty
        {
            get
            {
                return _realProperty;
            }

            set
            {
                if (_realProperty.Equals(value))
                {
                    return;
                }

                _realProperty = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(RealPropertyPropertyName);
            }
        }

        public new void RaisePropertyChanged(string propertyName)
        {
            base.RaisePropertyChanged(propertyName);
        }
    }

    public class TestViewModel : ViewModelBase
    {
        public bool CleanupWasCalled
        {
            get;
            private set;
        }

        public const string ReceivedContentPropertyName = "ReceivedContent";

        private string _receivedContent;

        public string ReceivedContent
        {
            get
            {
                return _receivedContent;
            }

            private set
            {
                if (_receivedContent == value)
                {
                    return;
                }

                _receivedContent = value;
                RaisePropertyChanged(ReceivedContentPropertyName);
            }
        }

        public const string LastChanged1PropertyName = "LastChanged1";

        private DateTime _lastChanged1;

        public DateTime LastChanged1
        {
            get
            {
                return _lastChanged1;
            }

            set
            {
                if (_lastChanged1 == value)
                {
                    return;
                }

                var oldValue = _lastChanged1;
                _lastChanged1 = value;

                // Update bindings and broadcast change using GalaSoft.Utility.Messenging
                RaisePropertyChanged(LastChanged1PropertyName, oldValue, value, true);
            }
        }

        /// <summary>
        /// The <see cref="LastChanged2" /> property's name.
        /// </summary>
        public const string LastChanged2PropertyName = "LastChanged2";

        private DateTime _lastChanged2;

        /// <summary>
        /// Gets the LastChanged2 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime LastChanged2
        {
            get
            {
                return _lastChanged2;
            }

            set
            {
                if (_lastChanged2 == value)
                {
                    return;
                }

                _lastChanged2 = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(LastChanged2PropertyName);
            }
        }

        internal void HandleStringMessage(string message)
        {
            ReceivedContent = message;
        }

        public TestViewModel()
        {
            
        }

        public TestViewModel(IMessenger messenger)
            : base(messenger)
        {
        }

        public override void Cleanup()
        {
            CleanupWasCalled = true;
            base.Cleanup();
        }
    }
}