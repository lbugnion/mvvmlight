using System;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GalaSoft.MvvmLight.Test.Messaging
{
    [TestClass]
    public class NotificationMessageFuncTest
    {
        private static readonly string DummyNotification1 = Guid.NewGuid().ToString();

        private static readonly string DummyNotification2 = Guid.NewGuid().ToString();

        private static readonly Random RandomGenerator = new Random();

        [TestMethod]
        public void TestNotificationMessageFunc()
        {
            ExecuteTest(null, null);
        }

        [TestMethod]
        public void TestNotificationMessageFuncWithSender()
        {
            ExecuteTest(this, null);
        }

        [TestMethod]
        public void TestNotificationMessageFuncWithSenderAndTarget()
        {
            ExecuteTest(this, this);
        }

        [TestMethod]
        public void TestNotificationMessageFuncT1()
        {
            ExecuteTest(null, null, RandomGenerator.NextDouble());
        }

        [TestMethod]
        public void TestNotificationMessageFuncT1WithSender()
        {
            ExecuteTest(this, null, RandomGenerator.NextDouble());
        }

        [TestMethod]
        public void TestNotificationMessageFuncT1WithSenderAndTarget()
        {
            ExecuteTest(this, this, RandomGenerator.NextDouble());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNotificationMessageFuncWithNullCallback1()
        {
            Messenger.Default.Register<NotificationMessageFunc<DateTime>>(
                this,
                m => {});

            Messenger.Default.Send(new NotificationMessageFunc<DateTime>(DummyNotification1, null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNotificationMessageFuncWithNullCallback2()
        {
            Messenger.Default.Register<NotificationMessageFunc<DateTime>>(
                this,
                m => { });

            Messenger.Default.Send(new NotificationMessageFunc<DateTime>(this, DummyNotification1, null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNotificationMessageFuncWithNullCallback3()
        {
            Messenger.Default.Register<NotificationMessageFunc<DateTime>>(
                this,
                m => { });

            Messenger.Default.Send(new NotificationMessageFunc<DateTime>(this, this, DummyNotification1, null));
        }

        private void ExecuteTest(object sender, object target)
        {
            object receivedSender = null;
            object receivedTarget = null;
            string receivedNotification = null;

            var callbackExecuted1 = false;
            var callbackExecuted2 = false;
            var returnedValue1 = DateTime.MinValue;
            Exception returnedValue2 = null;

            Messenger.Reset();

            Messenger.Default.Register<NotificationMessageWithCallback>(
                this,
                true,
                m =>
                {
                    receivedSender = m.Sender;
                    receivedTarget = m.Target;
                    receivedNotification = m.Notification;

                    var casted1 = m as NotificationMessageFunc<DateTime>;
                    if (casted1 != null)
                    {
                        returnedValue1 = casted1.Execute();
                        return;
                    }

                    var casted2 = m as NotificationMessageFunc<Exception>;
                    if (casted2 != null)
                    {
                        returnedValue2 = casted2.Execute();
                        return;
                    }
                });

            NotificationMessageFunc<DateTime> message1 = null;
            NotificationMessageFunc<Exception> message2 = null;

            var returnedContent1 = DateTime.Now;
            Exception returnedContent2 = new InvalidOperationException();

            Func<DateTime> callback1 = () =>
            {
                callbackExecuted1 = true;
                return returnedContent1;
            };

            Func<Exception> callback2 = () =>
            {
                callbackExecuted2 = true;
                return returnedContent2;
            };

            if (sender == null)
            {
                message1 = new NotificationMessageFunc<DateTime>(DummyNotification1, callback1);
                message2 = new NotificationMessageFunc<Exception>(DummyNotification2, callback2);
            }
            else
            {
                if (target == null)
                {
                    message1 = new NotificationMessageFunc<DateTime>(sender, DummyNotification1, callback1);
                    message2 = new NotificationMessageFunc<Exception>(sender, DummyNotification2, callback2);
                }
                else
                {
                    message1 = new NotificationMessageFunc<DateTime>(sender, target, DummyNotification1, callback1);
                    message2 = new NotificationMessageFunc<Exception>(sender, target, DummyNotification2, callback2);
                }
            }

            Messenger.Default.Send(message1);

            Assert.AreEqual(sender, receivedSender);
            Assert.AreEqual(target, receivedTarget);
            Assert.AreEqual(DummyNotification1, receivedNotification);
            Assert.IsTrue(callbackExecuted1);
            Assert.IsFalse(callbackExecuted2);
            Assert.AreEqual(returnedContent1, returnedValue1);
            Assert.AreEqual(null, returnedValue2);

            receivedTarget = null;
            receivedSender = null;

            Messenger.Default.Send(message2);

            Assert.AreEqual(sender, receivedSender);
            Assert.AreEqual(target, receivedTarget);
            Assert.AreEqual(DummyNotification2, receivedNotification);
            Assert.IsTrue(callbackExecuted1);
            Assert.IsTrue(callbackExecuted2);
            Assert.AreEqual(returnedContent1, returnedValue1);
            Assert.AreEqual(returnedContent2, returnedValue2);
        }

        private void ExecuteTest<T>(object sender, object target, T argument1)
        {
            object receivedSender = null;
            object receivedTarget = null;
            string receivedNotification = null;

            var callbackExecuted1 = false;
            var callbackExecuted2 = false;

            T receivedArgument1 = default(T);

            var returnedValue1 = DateTime.MinValue;
            Exception returnedValue2 = null;

            Messenger.Reset();

            Messenger.Default.Register<NotificationMessageWithCallback>(
                this,
                true,
                m =>
                {
                    receivedSender = m.Sender;
                    receivedTarget = m.Target;
                    receivedNotification = m.Notification;

                    var casted1 = m as NotificationMessageFunc<T, DateTime>;
                    if (casted1 != null)
                    {
                        returnedValue1 = casted1.Execute(argument1);
                        return;
                    }

                    var casted2 = m as NotificationMessageFunc<T, Exception>;
                    if (casted2 != null)
                    {
                        returnedValue2 = casted2.Execute(argument1);
                        return;
                    }
                });

            NotificationMessageFunc<T, DateTime> message1 = null;
            NotificationMessageFunc<T, Exception> message2 = null;

            var returnedContent1 = DateTime.Now;
            Exception returnedContent2 = new InvalidOperationException();

            Func<T, DateTime> callback1 = p =>
            {
                callbackExecuted1 = true;
                receivedArgument1 = p;
                return returnedContent1;
            };

            Func<T, Exception> callback2 = p =>
            {
                callbackExecuted2 = true;
                receivedArgument1 = p;
                return returnedContent2;
            };

            if (sender == null)
            {
                message1 = new NotificationMessageFunc<T, DateTime>(DummyNotification1, callback1);
                message2 = new NotificationMessageFunc<T, Exception>(DummyNotification2, callback2);
            }
            else
            {
                if (target == null)
                {
                    message1 = new NotificationMessageFunc<T, DateTime>(sender, DummyNotification1, callback1);
                    message2 = new NotificationMessageFunc<T, Exception>(sender, DummyNotification2, callback2);
                }
                else
                {
                    message1 = new NotificationMessageFunc<T, DateTime>(sender, target, DummyNotification1, callback1);
                    message2 = new NotificationMessageFunc<T, Exception>(sender, target, DummyNotification2, callback2);
                }
            }

            Messenger.Default.Send(message1);

            Assert.AreEqual(sender, receivedSender);
            Assert.AreEqual(target, receivedTarget);
            Assert.AreEqual(DummyNotification1, receivedNotification);
            Assert.IsTrue(callbackExecuted1);
            Assert.IsFalse(callbackExecuted2);
            Assert.AreEqual(returnedContent1, returnedValue1);
            Assert.AreEqual(null, returnedValue2);
            Assert.AreEqual(argument1, receivedArgument1);

            receivedTarget = null;
            receivedSender = null;
            receivedArgument1 = default(T);

            Messenger.Default.Send(message2);

            Assert.AreEqual(sender, receivedSender);
            Assert.AreEqual(target, receivedTarget);
            Assert.AreEqual(DummyNotification2, receivedNotification);
            Assert.IsTrue(callbackExecuted1);
            Assert.IsTrue(callbackExecuted2);
            Assert.AreEqual(returnedContent1, returnedValue1);
            Assert.AreEqual(returnedContent2, returnedValue2);
            Assert.AreEqual(argument1, receivedArgument1);
        }
    }
}
