using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GalaSoft.MvvmLight.Messaging;

namespace GalaSoft.MvvmLight.Test.Messaging
{
    [TestClass]
    public class MessengerRegisterWhileSendingTest
    {
        private const string TestContentString = "Hello world";
        private const string TestContentStringNested = "Hello earth";

        [TestMethod]
        public void TestNewMessengerRegisteringWhileSending()
        {
            Messenger.Reset();
            TestRecipient.Reset();

            var list = new List<TestRecipient1>();

            for (var index = 0; index < 10; index++)
            {
                list.Add(new TestRecipient1(true));
            }

            Messenger.Default.Send(new GenericMessage<string>(TestContentString));

            Assert.AreEqual(null, TestRecipient.LastReceivedString);
            Assert.AreEqual(0, TestRecipient.ReceivedStringMessages);

            Messenger.Default.Send(new GenericMessage<string>(TestContentStringNested));

            Assert.AreEqual(TestContentStringNested, TestRecipient.LastReceivedString);
            Assert.AreEqual(10, TestRecipient.ReceivedStringMessages);
        }

        [TestMethod]
        public void TestNewMessengerRegisteringForMessageBaseWhileSending()
        {
            Messenger.Reset();
            TestRecipient.Reset();

            var list = new List<TestRecipient2>();

            for (var index = 0; index < 10; index++)
            {
                list.Add(new TestRecipient2(true));
            }

            Messenger.Default.Send(new GenericMessage<string>(TestContentString));

            Assert.AreEqual(null, TestRecipient.LastReceivedString);
            Assert.AreEqual(0, TestRecipient.ReceivedStringMessages);

            Messenger.Default.Send(new GenericMessage<string>(TestContentStringNested));

            Assert.AreEqual(TestContentStringNested, TestRecipient.LastReceivedString);
            Assert.AreEqual(10, TestRecipient.ReceivedStringMessages);
        }

        [TestMethod]
        public void TestOldMessengerRegisteringWhileSending()
        {
            Messenger.Reset();
            TestRecipient.Reset();

            var list = new List<TestRecipient1>();

            for (var index = 0; index < 10; index++)
            {
                list.Add(new TestRecipient3());
            }

            Messenger.Default.Broadcast(new GenericMessage<string>(TestContentString));

            Assert.AreEqual(null, TestRecipient.LastReceivedString);
            Assert.AreEqual(0, TestRecipient.ReceivedStringMessages);

            Messenger.Default.Broadcast(new GenericMessage<string>(TestContentStringNested));

            Assert.AreEqual(TestContentStringNested, TestRecipient.LastReceivedString);
            Assert.AreEqual(20, TestRecipient.ReceivedStringMessages);
        }

        [TestMethod]
        public void TestOldMessengerRegisteringForMessageBaseWhileSending()
        {
            Messenger.Reset();
            TestRecipient.Reset();

            var list = new List<TestRecipient2>();

            for (var index = 0; index < 10; index++)
            {
                list.Add(new TestRecipient4());
            }

            Messenger.Default.Broadcast(new GenericMessage<string>(TestContentString));

            Assert.AreEqual(null, TestRecipient.LastReceivedString);
            Assert.AreEqual(0, TestRecipient.ReceivedStringMessages);

            Messenger.Default.Broadcast(new GenericMessage<string>(TestContentStringNested));

            Assert.AreEqual(TestContentStringNested, TestRecipient.LastReceivedString);
            Assert.AreEqual(20, TestRecipient.ReceivedStringMessages);
        }

        public abstract class TestRecipient
        {
            public static string LastReceivedString
            {
                get;
                protected set;
            }

            public static int ReceivedStringMessages
            {
                get;
                protected set;
            }

            public static void Reset()
            {
                LastReceivedString = null;
                ReceivedStringMessages = 0;
            }
        }
        
        public class TestRecipient1 : TestRecipient
        {
            public TestRecipient1(bool register)
            {
                if (register)
                {
                    Messenger.Default.Register<GenericMessage<string>>(this, ReceiveString);
                }
            }

            protected virtual void ReceiveString(GenericMessage<string> m)
            {
                Messenger.Default.Register<GenericMessage<string>>(this, ReceiveStringNested);
            }

            protected void ReceiveStringNested(GenericMessage<string> m)
            {
                ReceivedStringMessages++;
                LastReceivedString = m.Content;
            }
        }

        public class TestRecipient2 : TestRecipient
        {
            public TestRecipient2(bool register)
            {
                if (register)
                {
                    Messenger.Default.Register<MessageBase>(this, true, ReceiveString);
                }
            }

            protected virtual void ReceiveString(MessageBase m)
            {
                var message = m as GenericMessage<string>;
                if (message != null)
                {
                    Messenger.Default.Register<MessageBase>(this, true, ReceiveStringNested);
                }
            }

            protected void ReceiveStringNested(MessageBase m)
            {
                var message = m as GenericMessage<string>;
                if (message != null)
                {
                    ReceivedStringMessages++;
                    LastReceivedString = message.Content;
                }
            }
        }

        public class TestRecipient3 : TestRecipient1, IMessageRecipient
        {
            private TestRecipient3 _innerRecipient;

            public TestRecipient3()
                : base(false)
            {
                Messenger.Default.Register(this, typeof(GenericMessage<string>));
            }

            protected override void ReceiveString(GenericMessage<string> m)
            {
                _innerRecipient = new TestRecipient3();
            }

            public void ReceiveMessage(MessageBase message)
            {
                var casted = message as GenericMessage<string>;
                if (casted != null)
                {
                    if (casted.Content == TestContentString)
                    {
                        ReceiveString(casted);
                        return;
                    }

                    if (casted.Content == TestContentStringNested)
                    {
                        ReceiveStringNested(casted);
                    }
                }
            }
        }

        public class TestRecipient4 : TestRecipient2, IMessageRecipient
        {
            private TestRecipient4 _innerRecipient;

            public TestRecipient4()
                : base(false)
            {
                Messenger.Default.Register(this, typeof(MessageBase), true);
            }

            protected override void ReceiveString(MessageBase m)
            {
                var message = m as GenericMessage<string>;
                if (message != null)
                {
                    _innerRecipient = new TestRecipient4();
                }
            }

            public void ReceiveMessage(MessageBase message)
            {
                var casted = message as GenericMessage<string>;
                if (casted != null)
                {
                    if (casted.Content == TestContentString)
                    {
                        ReceiveString(casted);
                        return;
                    }

                    if (casted.Content == TestContentStringNested)
                    {
                        ReceiveStringNested(casted);
                    }
                }
            }
        }
    }
}
