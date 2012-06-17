using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Messaging;

#if NETFX_CORE
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

namespace GalaSoft.MvvmLight.Test.Messaging
{
    [TestClass]
    public class NotificationMessageActionTest
    {
        private static readonly string DummyNotification1 = Guid.NewGuid().ToString();

        private static readonly Random RandomGenerator = new Random();

        [TestMethod]
        public void TestNotificationMessageAction()
        {
            ExecuteTest(null, null);
        }

        [TestMethod]
        public void TestNotificationMessageActionWithSender()
        {
            ExecuteTest(this, null);
        }

        [TestMethod]
        public void TestNotificationMessageActionWithSenderAndTarget()
        {
            ExecuteTest(this, this);
        }

        [TestMethod]
        public void TestNotificationMessageActionT1()
        {
            ExecuteTest(null, null, RandomGenerator.NextDouble());
        }

        [TestMethod]
        public void TestNotificationMessageActionT1WithSender()
        {
            ExecuteTest(this, null, RandomGenerator.NextDouble());
        }

        [TestMethod]
        public void TestNotificationMessageActionT1WithSenderAndTarget()
        {
            ExecuteTest(this, this, RandomGenerator.NextDouble());
        }

        [TestMethod]
        public void TestNotificationMessageActionWithNullCallback1()
        {
            Messenger.Default.Register<NotificationMessageAction<DateTime>>(
                this,
                m => { });

            try
            {
                Messenger.Default.Send(new NotificationMessageAction<DateTime>(DummyNotification1, null));
                Assert.Fail("ArgumentNullException was not thrown");
            }
            catch (ArgumentNullException)
            {
            }
        }

        [TestMethod]
        public void TestNotificationMessageActionWithNullCallback2()
        {
            Messenger.Default.Register<NotificationMessageAction<DateTime>>(
                this,
                m => { });

            try
            {
                Messenger.Default.Send(new NotificationMessageAction<DateTime>(this, DummyNotification1, null));
                Assert.Fail("ArgumentNullException was not thrown");
            }
            catch (ArgumentNullException)
            {
            }
        }

        [TestMethod]
        public void TestNotificationMessageActionWithNullCallback3()
        {
            Messenger.Default.Register<NotificationMessageAction<DateTime>>(
                this,
                m => { });

            try
            {
                Messenger.Default.Send(new NotificationMessageAction<DateTime>(this, this, DummyNotification1, null));
                Assert.Fail("ArgumentNullException was not thrown");
            }
            catch (ArgumentNullException)
            {
            }
        }

        private void ExecuteTest(object sender, object target)
        {
            object receivedSender = null;
            object receivedTarget = null;
            string receivedNotification = null;

            var callbackExecuted1 = false;

            Messenger.Reset();

            Messenger.Default.Register<NotificationMessageAction>(
                this,
                true,
                m =>
                {
                    receivedSender = m.Sender;
                    receivedTarget = m.Target;
                    receivedNotification = m.Notification;
                    m.Execute();
                });

            NotificationMessageAction message1 = null;

            Action callback1 = () =>
            {
                callbackExecuted1 = true;
            };

            if (sender == null)
            {
                message1 = new NotificationMessageAction(DummyNotification1, callback1);
            }
            else
            {
                if (target == null)
                {
                    message1 = new NotificationMessageAction(sender, DummyNotification1, callback1);
                }
                else
                {
                    message1 = new NotificationMessageAction(sender, target, DummyNotification1, callback1);
                }
            }

            Messenger.Default.Send(message1);

            Assert.AreEqual(sender, receivedSender);
            Assert.AreEqual(target, receivedTarget);
            Assert.AreEqual(DummyNotification1, receivedNotification);
            Assert.IsTrue(callbackExecuted1);
        }

        private void ExecuteTest<T>(object sender, object target, T argument1)
        {
            object receivedSender = null;
            object receivedTarget = null;
            string receivedNotification = null;
            var receivedArgument1 = default(T);
            var callbackExecuted1 = false;

            Messenger.Reset();

            Messenger.Default.Register<NotificationMessageAction<T>>(
                this,
                m =>
                {
                    receivedSender = m.Sender;
                    receivedTarget = m.Target;
                    receivedNotification = m.Notification;
                    m.Execute(argument1);
                });

            NotificationMessageAction<T> message1 = null;

            Action<T> callback1 = p =>
            {
                callbackExecuted1 = true;
                receivedArgument1 = p;
            };

            if (sender == null)
            {
                message1 = new NotificationMessageAction<T>(DummyNotification1, callback1);
            }
            else
            {
                if (target == null)
                {
                    message1 = new NotificationMessageAction<T>(sender, DummyNotification1, callback1);
                }
                else
                {
                    message1 = new NotificationMessageAction<T>(sender, target, DummyNotification1, callback1);
                }
            }

            Messenger.Default.Send(message1);

            Assert.AreEqual(sender, receivedSender);
            Assert.AreEqual(target, receivedTarget);
            Assert.AreEqual(DummyNotification1, receivedNotification);
            Assert.IsTrue(callbackExecuted1);
            Assert.AreEqual(argument1, receivedArgument1);
        }
    }
}
