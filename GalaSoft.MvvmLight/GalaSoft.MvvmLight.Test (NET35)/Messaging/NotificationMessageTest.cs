using System;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GalaSoft.MvvmLight.Test.Messaging
{
    [TestClass]
    public class NotificationMessageTest
    {
        private static readonly string DummyNotification1 = Guid.NewGuid().ToString();

        private static readonly string DummyNotification2 = Guid.NewGuid().ToString();

        public void ExecuteTestGeneric(object sender, object target)
        {
            var testContent1 = new InvalidOperationException();
            var testContent2 = new InvalidCastException();

            Exception receivedContent1 = null;
            Exception receivedContent2 = null;

            object receivedSender = null;
            object receivedTarget = null;

            Messenger.Reset();

            Messenger.Default.Register<NotificationMessage<Exception>>(
                this,
                 m =>
                 {
                     receivedSender = m.Sender;
                     receivedTarget = m.Target;

                     if (m.Notification == DummyNotification1)
                     {
                         receivedContent1 = testContent1;
                         return;
                     }

                     if (m.Notification == DummyNotification2)
                     {
                         receivedContent2 = testContent2;
                         return;
                     }
                 });

            Assert.AreEqual(null, receivedContent1);
            Assert.AreEqual(null, receivedContent2);

            NotificationMessage<Exception> message1;
            NotificationMessage<Exception> message2;

            if (sender == null)
            {
                message1 = new NotificationMessage<Exception>(testContent1, DummyNotification1);
                message2 = new NotificationMessage<Exception>(testContent2, DummyNotification2);
            }
            else
            {
                if (target == null)
                {
                    message1 = new NotificationMessage<Exception>(sender, testContent1, DummyNotification1);
                    message2 = new NotificationMessage<Exception>(sender, testContent2, DummyNotification2);
                }
                else
                {
                    message1 = new NotificationMessage<Exception>(sender, target, testContent1, DummyNotification1);
                    message2 = new NotificationMessage<Exception>(sender, target, testContent2, DummyNotification2);
                }
            }

            Messenger.Default.Send(message1);

            Assert.AreEqual(sender, receivedSender);
            Assert.AreEqual(target, receivedTarget);
            Assert.AreEqual(testContent1, receivedContent1);
            Assert.AreEqual(null, receivedContent2);

            receivedSender = null;
            receivedTarget = null;

            Messenger.Default.Send(message2);

            Assert.AreEqual(sender, receivedSender);
            Assert.AreEqual(target, receivedTarget);
            Assert.AreEqual(testContent1, receivedContent1);
            Assert.AreEqual(testContent2, receivedContent2);
        }

        [TestMethod]
        public void TestNotificationGenericMessage()
        {
            ExecuteTestGeneric(null, null);
        }

        [TestMethod]
        public void TestNotificationGenericMessageWithSender()
        {
            ExecuteTestGeneric(this, null);
        }

        [TestMethod]
        public void TestNotificationGenericMessageWithTarget()
        {
            ExecuteTestGeneric(this, this);
        }

        [TestMethod]
        public void TestNotificationMessage()
        {
            ExecuteTest(null, null);
        }

        [TestMethod]
        public void TestNotificationMessageWithSender()
        {
            ExecuteTest(this, null);
        }

        [TestMethod]
        public void TestNotificationMessageWithSenderAndTarget()
        {
            ExecuteTest(this, this);
        }

        private void ExecuteTest(object sender, object target)
        {
            object receivedSender = null;
            object receivedTarget = null;
            string receivedNotification = null;

            Messenger.Reset();

            Messenger.Default.Register<NotificationMessage>(
                this,
                m =>
                {
                    receivedSender = m.Sender;
                    receivedTarget = m.Target;
                    receivedNotification = m.Notification;
                });

            NotificationMessage message1;
            NotificationMessage message2;

            if (sender == null)
            {
                message1 = new NotificationMessage(DummyNotification1);
                message2 = new NotificationMessage(DummyNotification2);
            }
            else
            {
                if (target == null)
                {
                    message1 = new NotificationMessage(sender, DummyNotification1);
                    message2 = new NotificationMessage(sender, DummyNotification2);
                }
                else
                {
                    message1 = new NotificationMessage(sender, target, DummyNotification1);
                    message2 = new NotificationMessage(sender, target, DummyNotification2);
                }
            }

            Messenger.Default.Send(message1);

            Assert.AreEqual(sender, receivedSender);
            Assert.AreEqual(target, receivedTarget);
            Assert.AreEqual(DummyNotification1, receivedNotification);

            receivedTarget = null;
            receivedSender = null;

            Messenger.Default.Send(message2);

            Assert.AreEqual(sender, receivedSender);
            Assert.AreEqual(target, receivedTarget);
            Assert.AreEqual(DummyNotification2, receivedNotification);
        }
    }
}