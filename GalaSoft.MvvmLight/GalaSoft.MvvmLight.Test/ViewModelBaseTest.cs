using System;
using System.ComponentModel;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Test.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GalaSoft.MvvmLight.Test
{
    /// <summary>
    /// Summary description for ViewModelBaseTest
    /// </summary>
    [TestClass]
    public class ViewModelBaseTest
    {
        private DateTime _receivedDateTime;

        [TestMethod]
        public void DisposeTest()
        {
            Messenger.Reset();

            var vm = new OldTestViewModel();
            Messenger.Default.Register(vm, typeof(OldTestMessage));

            const string Content1 = "Hello world";
            const string Content2 = "Another message";

            var message1 = new OldTestMessage(this, Content1);
            Messenger.Default.Broadcast(message1);

            Assert.AreEqual(Content1, vm.ReceivedContent);

            vm.Dispose();

            var message2 = new OldTestMessage(this, Content2);
            Messenger.Default.Broadcast(message2);

            Assert.AreEqual(Content1, vm.ReceivedContent);
        }

        [TestMethod]
        public void PropertyChangedTestBroadcast()
        {
            Messenger.Reset();
            _receivedDateTime = DateTime.MinValue;

            var recipient = new OldTestRecipient();
            Messenger.Default.Register(recipient, typeof(PropertyChangedMessage<DateTime>));

            var vm = new OldTestViewModel();
            vm.PropertyChanged += VMPropertyChanged;

            Assert.AreEqual(_receivedDateTime, DateTime.MinValue);

            var now = DateTime.Now;
            vm.LastChanged2 = now;
            Assert.AreEqual(now, vm.LastChanged2);
            Assert.AreEqual(_receivedDateTime, vm.LastChanged2);
            Assert.AreEqual(now, recipient.DateTimeContent);
        }

        [TestMethod]
        public void PropertyChangedTestBroadcastApplicationMessenger()
        {
            _receivedDateTime = DateTime.MinValue;

            var messenger = new Messenger();

            var recipient1 = new OldTestRecipient();
            var recipient2 = new OldTestRecipient();
            messenger.Register(recipient1, typeof(PropertyChangedMessage<DateTime>));
            Messenger.Default.Register(recipient2, typeof(PropertyChangedMessage<DateTime>));

            var vm = new OldTestViewModel(messenger);
            vm.PropertyChanged += VMPropertyChanged;

            Assert.AreEqual(_receivedDateTime, DateTime.MinValue);

            var now = DateTime.Now;
            vm.LastChanged2 = now;
            Assert.AreEqual(now, vm.LastChanged2);
            Assert.AreEqual(_receivedDateTime, vm.LastChanged2);
            Assert.AreEqual(now, recipient1.DateTimeContent);
            Assert.AreEqual(DateTime.MinValue, recipient2.DateTimeContent);
        }

        [TestMethod]
        public void PropertyChangedTestBroadcastNonStaticMessenger()
        {
            _receivedDateTime = DateTime.MinValue;

            var messenger = new Messenger();

            var recipient1 = new OldTestRecipient();
            var recipient2 = new OldTestRecipient();
            messenger.Register(recipient1, typeof(PropertyChangedMessage<DateTime>));
            Messenger.Default.Register(recipient2, typeof(PropertyChangedMessage<DateTime>));

            var vm = new OldTestViewModel(messenger);
            vm.PropertyChanged += VMPropertyChanged;

            Assert.AreEqual(_receivedDateTime, DateTime.MinValue);

            var now = DateTime.Now;
            vm.LastChanged2 = now;
            Assert.AreEqual(now, vm.LastChanged2);
            Assert.AreEqual(_receivedDateTime, vm.LastChanged2);
            Assert.AreEqual(now, recipient1.DateTimeContent);
            Assert.AreEqual(DateTime.MinValue, recipient2.DateTimeContent);
        }

        [TestMethod]
        public void PropertyChangedTestNoBroadcast()
        {
            Messenger.Reset();
            _receivedDateTime = DateTime.MinValue;

            var recipient = new OldTestRecipient();
            Messenger.Default.Register(recipient, typeof(PropertyChangedMessage<DateTime>));

            var vm = new OldTestViewModel();
            vm.PropertyChanged += VMPropertyChanged;

            Assert.AreEqual(_receivedDateTime, DateTime.MinValue);

            var now = DateTime.Now;
            vm.LastChanged1 = now;
            Assert.AreEqual(now, vm.LastChanged1);
            Assert.AreEqual(_receivedDateTime, vm.LastChanged1);
            Assert.AreEqual(DateTime.MinValue, recipient.DateTimeContent);
        }

        private void VMPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName
                == OldTestViewModel.LastChanged1PropertyName)
            {
                _receivedDateTime = ((OldTestViewModel) sender).LastChanged1;
                return;
            }
            if (e.PropertyName
                == OldTestViewModel.LastChanged2PropertyName)
            {
                _receivedDateTime = ((OldTestViewModel) sender).LastChanged2;
                return;
            }
        }
    }
}