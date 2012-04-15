using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GalaSoft.MvvmLight.Messaging;

namespace GalaSoft.MvvmLight.Test.Messaging
{
    [TestClass]
    public class MessengerTestConstrainingMessages
    {
        private static readonly string TestContent = Guid.NewGuid().ToString();

        private bool _messageWasReceived;
        private bool _messageWasReceivedInITestMessage;
        private bool _messageWasReceivedInTestMessageBase;
        private bool _messageWasReceivedInMessageBase;

        private void Reset()
        {
            _messageWasReceived = false;
            _messageWasReceivedInITestMessage = false;
            _messageWasReceivedInTestMessageBase = false;
            _messageWasReceivedInMessageBase = false;
        }

        [TestMethod]
        public void TestConstrainingMessageByInterface()
        {
            Reset();
            Messenger.Reset();
            Messenger.Default.Register<ITestMessage>(this, ReceiveITestMessage);

            var testMessage = new TestMessageImpl(this)
            {
                Content = TestContent
            };

            Assert.IsFalse(_messageWasReceived);
            Assert.IsFalse(_messageWasReceivedInTestMessageBase);
            Assert.IsFalse(_messageWasReceivedInMessageBase);
            Assert.IsFalse(_messageWasReceivedInITestMessage);
            Messenger.Default.Send(testMessage);
            Assert.IsFalse(_messageWasReceived);
            Assert.IsFalse(_messageWasReceivedInTestMessageBase);
            Assert.IsFalse(_messageWasReceivedInMessageBase);
            Assert.IsFalse(_messageWasReceivedInITestMessage);

            Messenger.Default.Unregister<ITestMessage>(this);
            Messenger.Default.Register<ITestMessage>(this, true, ReceiveITestMessage);

            Messenger.Default.Send(testMessage);
            Assert.IsTrue(_messageWasReceived);
            Assert.IsTrue(_messageWasReceivedInITestMessage);
            Assert.IsFalse(_messageWasReceivedInTestMessageBase);
            Assert.IsFalse(_messageWasReceivedInMessageBase);
        }

        [TestMethod]
        public void TestConstrainingMessageByBaseClass()
        {
            Reset();
            Messenger.Reset();
            Messenger.Default.Register<TestMessageBase>(this, ReceiveTestMessageBase);

            var testMessage = new TestMessageImpl(this)
            {
                Content = TestContent
            };

            Assert.IsFalse(_messageWasReceived);
            Assert.IsFalse(_messageWasReceivedInTestMessageBase);
            Assert.IsFalse(_messageWasReceivedInMessageBase);
            Assert.IsFalse(_messageWasReceivedInITestMessage);
            Messenger.Default.Send(testMessage);
            Assert.IsFalse(_messageWasReceived);
            Assert.IsFalse(_messageWasReceivedInTestMessageBase);
            Assert.IsFalse(_messageWasReceivedInMessageBase);
            Assert.IsFalse(_messageWasReceivedInITestMessage);

            Messenger.Default.Unregister<ITestMessage>(this);
            Messenger.Default.Register<TestMessageBase>(this, true, ReceiveTestMessageBase);

            Messenger.Default.Send(testMessage);
            Assert.IsTrue(_messageWasReceived);
            Assert.IsTrue(_messageWasReceivedInTestMessageBase);
            Assert.IsFalse(_messageWasReceivedInMessageBase);
            Assert.IsFalse(_messageWasReceivedInITestMessage);
        }

        [TestMethod]
        public void TestConstrainingMessageByBaseClassAndReceiveWithInterface()
        {
            Reset();
            Messenger.Reset();
            Messenger.Default.Register<TestMessageBase>(this, ReceiveITestMessage);

            var testMessage = new TestMessageImpl(this)
            {
                Content = TestContent
            };

            Assert.IsFalse(_messageWasReceived);
            Assert.IsFalse(_messageWasReceivedInTestMessageBase);
            Assert.IsFalse(_messageWasReceivedInMessageBase);
            Assert.IsFalse(_messageWasReceivedInITestMessage);
            Messenger.Default.Send(testMessage);
            Assert.IsFalse(_messageWasReceived);
            Assert.IsFalse(_messageWasReceivedInTestMessageBase);
            Assert.IsFalse(_messageWasReceivedInMessageBase);
            Assert.IsFalse(_messageWasReceivedInITestMessage);

            Messenger.Default.Unregister<ITestMessage>(this);
            Messenger.Default.Register<TestMessageBase>(this, true, ReceiveITestMessage);

            Messenger.Default.Send(testMessage);
            Assert.IsTrue(_messageWasReceived);
            Assert.IsFalse(_messageWasReceivedInTestMessageBase);
            Assert.IsFalse(_messageWasReceivedInMessageBase);
            Assert.IsTrue(_messageWasReceivedInITestMessage);
        }

        [TestMethod]
        public void TestConstrainingMessageByBaseBaseClass()
        {
            Reset();
            Messenger.Reset();
            Messenger.Default.Register<MessageBase>(this, ReceiveMessageBase);

            var testMessage = new TestMessageImpl(this)
            {
                Content = TestContent
            };

            Assert.IsFalse(_messageWasReceived);
            Assert.IsFalse(_messageWasReceivedInTestMessageBase);
            Assert.IsFalse(_messageWasReceivedInMessageBase);
            Assert.IsFalse(_messageWasReceivedInITestMessage);
            Messenger.Default.Send(testMessage);
            Assert.IsFalse(_messageWasReceived);
            Assert.IsFalse(_messageWasReceivedInTestMessageBase);
            Assert.IsFalse(_messageWasReceivedInMessageBase);
            Assert.IsFalse(_messageWasReceivedInITestMessage);

            Messenger.Default.Unregister<ITestMessage>(this);
            Messenger.Default.Register<MessageBase>(this, true, ReceiveMessageBase);

            Messenger.Default.Send(testMessage);
            Assert.IsTrue(_messageWasReceived);
            Assert.IsFalse(_messageWasReceivedInTestMessageBase);
            Assert.IsTrue(_messageWasReceivedInMessageBase);
            Assert.IsFalse(_messageWasReceivedInITestMessage);
        }

        public void ReceiveITestMessage(ITestMessage testMessage)
        {
            Assert.IsNotNull(testMessage);
            Assert.AreEqual(TestContent, testMessage.Content);
            _messageWasReceived = true;
            _messageWasReceivedInITestMessage = true;
        }

        public void ReceiveTestMessageBase(TestMessageBase testMessage)
        {
            Assert.IsNotNull(testMessage);
            Assert.AreEqual(TestContent, testMessage.Content);
            _messageWasReceived = true;
            _messageWasReceivedInTestMessageBase = true;
        }

        public void ReceiveMessageBase(MessageBase testMessage)
        {
            Assert.IsNotNull(testMessage);

            var castedMessage = testMessage as ITestMessage;

            if (castedMessage != null)
            {
                Assert.AreEqual(TestContent, castedMessage.Content);
                _messageWasReceived = true;
                _messageWasReceivedInMessageBase = true;
            }
        }
    }
}
