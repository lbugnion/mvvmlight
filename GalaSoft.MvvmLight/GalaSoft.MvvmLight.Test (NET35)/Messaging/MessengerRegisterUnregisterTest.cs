using System;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GalaSoft.MvvmLight.Test.Messaging
{
    [TestClass]
    public class MessengerRegisterUnregisterTest
    {
        public DateTime ReceivedContentDateTime1
        {
            get;
            private set;
        }

        public DateTime ReceivedContentDateTime2
        {
            get;
            private set;
        }

        public Exception ReceivedContentException
        {
            get;
            private set;
        }

        public int ReceivedContentInt
        {
            get;
            private set;
        }

        public string ReceivedContentStringA1
        {
            get;
            private set;
        }

        public string ReceivedContentStringA2
        {
            get;
            private set;
        }

        public string ReceivedContentStringB
        {
            get;
            private set;
        }

#if !WINDOWS_PHONE
        [TestMethod]
        public void TestRegisterForGenericMessageBase()
        {
            var testContentException = new InvalidOperationException();
            var testContentDateTime = DateTime.Now;
            const string testContentString = "abcd";

            Messenger.Reset();
            Reset();

            Messenger.Default.Register<TestMessageGenericBase>(
                this,
                true,
                m =>
                {
                    var exceptionMessage =
                        m as TestMessageGeneric<Exception>;
                    if (exceptionMessage != null)
                    {
                        ReceivedContentException =
                            exceptionMessage.Content;
                        return;
                    }

                    var dateTimeMessage =
                        m as TestMessageGeneric<DateTime>;
                    if (dateTimeMessage != null)
                    {
                        ReceivedContentDateTime1 =
                            dateTimeMessage.Content;
                        return;
                    }

                    var stringMessage = m as TestMessageGeneric<string>;
                    if (stringMessage != null)
                    {
                        ReceivedContentStringA1 = stringMessage.Content;
                        return;
                    }
                });

            Assert.AreEqual(null, ReceivedContentStringA1);
            Assert.AreEqual(null, ReceivedContentException);
            Assert.AreEqual(DateTime.MinValue, ReceivedContentDateTime1);

            Messenger.Default.Send(new TestMessageGeneric<Exception>
            {
                Content = testContentException
            });

            Assert.AreEqual(null, ReceivedContentStringA1);
            Assert.AreEqual(testContentException, ReceivedContentException);
            Assert.AreEqual(DateTime.MinValue, ReceivedContentDateTime1);

            Messenger.Default.Send(new TestMessageGeneric<DateTime>
            {
                Content = testContentDateTime
            });

            Assert.AreEqual(null, ReceivedContentStringA1);
            Assert.AreEqual(testContentException, ReceivedContentException);
            Assert.AreEqual(testContentDateTime, ReceivedContentDateTime1);

            Messenger.Default.Send(new TestMessageGeneric<string>
            {
                Content = testContentString
            });

            Assert.AreEqual(testContentString, ReceivedContentStringA1);
            Assert.AreEqual(testContentException, ReceivedContentException);
            Assert.AreEqual(testContentDateTime, ReceivedContentDateTime1);
        }

        [TestMethod]
        public void TestRegisterForGenericMessageSpecific()
        {
            var testContentException = new InvalidOperationException();
            var testContentDateTime = DateTime.Now;
            const string testContentString = "abcd";

            Messenger.Reset();
            Reset();

            Messenger.Default.Register<TestMessageGeneric<DateTime>>(this, m => ReceivedContentDateTime1 = m.Content);
            Messenger.Default.Register<TestMessageGeneric<Exception>>(this, m => ReceivedContentException = m.Content);
            Messenger.Default.Register<TestMessageGeneric<string>>(this, m => ReceivedContentStringA1 = m.Content);

            Assert.AreEqual(null, ReceivedContentStringA1);
            Assert.AreEqual(null, ReceivedContentException);
            Assert.AreEqual(DateTime.MinValue, ReceivedContentDateTime1);

            Messenger.Default.Send(new TestMessageGeneric<Exception>
            {
                Content = testContentException
            });

            Assert.AreEqual(null, ReceivedContentStringA1);
            Assert.AreEqual(testContentException, ReceivedContentException);
            Assert.AreEqual(DateTime.MinValue, ReceivedContentDateTime1);

            Messenger.Default.Send(new TestMessageGeneric<DateTime>
            {
                Content = testContentDateTime
            });

            Assert.AreEqual(null, ReceivedContentStringA1);
            Assert.AreEqual(testContentException, ReceivedContentException);
            Assert.AreEqual(testContentDateTime, ReceivedContentDateTime1);

            Messenger.Default.Send(new TestMessageGeneric<string>
            {
                Content = testContentString
            });

            Assert.AreEqual(testContentString, ReceivedContentStringA1);
            Assert.AreEqual(testContentException, ReceivedContentException);
            Assert.AreEqual(testContentDateTime, ReceivedContentDateTime1);
        }

        [TestMethod]
        public void TestRegisterStrictandNonStrictRecipients()
        {
            var testContentDateTime = DateTime.Now;
            const string testContentString = "abcd";

            Messenger.Reset();
            Reset();

            var receivedMessages = 0;

            Messenger.Default.Register<TestMessageGenericBase>(
                this,
                true,
                m =>
                {
                    receivedMessages++;

                    var dateTimeMessage =
                        m as TestMessageGeneric<DateTime>;
                    if (dateTimeMessage != null)
                    {
                        ReceivedContentDateTime1 =
                            dateTimeMessage.Content;
                        return;
                    }

                    var stringMessage = m as TestMessageGeneric<string>;
                    if (stringMessage != null)
                    {
                        ReceivedContentStringA1 = stringMessage.Content;
                        return;
                    }
                });

            Messenger.Default.Register<TestMessageGeneric<DateTime>>(this,
                                                                     m =>
                                                                     {
                                                                         receivedMessages++;
                                                                         ReceivedContentDateTime2 = m.Content;
                                                                     });

            Assert.AreEqual(null, ReceivedContentStringA1);
            Assert.AreEqual(DateTime.MinValue, ReceivedContentDateTime1);
            Assert.AreEqual(DateTime.MinValue, ReceivedContentDateTime2);

            Messenger.Default.Send(new TestMessageGeneric<DateTime>
            {
                Content = testContentDateTime
            });

            Assert.AreEqual(2, receivedMessages);
            Assert.AreEqual(null, ReceivedContentStringA1);
            Assert.AreEqual(testContentDateTime, ReceivedContentDateTime1);
            Assert.AreEqual(testContentDateTime, ReceivedContentDateTime2);

            Messenger.Default.Send(new TestMessageGeneric<string>
            {
                Content = testContentString
            });

            Assert.AreEqual(3, receivedMessages);
            Assert.AreEqual(testContentString, ReceivedContentStringA1);
            Assert.AreEqual(testContentDateTime, ReceivedContentDateTime1);
            Assert.AreEqual(testContentDateTime, ReceivedContentDateTime2);
        }

        public class TestMessageGeneric<T> : TestMessageGenericBase
        {
            public T Content
            {
                get;
                set;
            }
        }
#endif

        [TestMethod]
        public void TestRegisterForSubclassesOfObject()
        {
            const string testContentA = "abcd";
            const string testContentB = "efgh";

            Reset();
            Messenger.Reset();

            Messenger.Default.Register<object>(
                this,
                true,
                m =>
                {
                    var messageA = m as TestMessageA;
                    if (messageA != null)
                    {
                        ReceivedContentStringA1 = messageA.Content;
                        return;
                    }

                    var messageB = m as TestMessageB;
                    if (messageB != null)
                    {
                        ReceivedContentStringB = messageB.Content;
                        return;
                    }
                });

            Assert.AreEqual(null, ReceivedContentStringA1);
            Assert.AreEqual(null, ReceivedContentStringB);

            Messenger.Default.Send(new TestMessageA
            {
                Content = testContentA
            });

            Assert.AreEqual(testContentA, ReceivedContentStringA1);
            Assert.AreEqual(null, ReceivedContentStringB);

            Messenger.Default.Send(new TestMessageB
            {
                Content = testContentB
            });

            Assert.AreEqual(testContentA, ReceivedContentStringA1);
            Assert.AreEqual(testContentB, ReceivedContentStringB);
        }

        [TestMethod]
        public void TestRegisterForSubclassesOfTestMessageA()
        {
            const string testContentA = "abcd";
            const string testContentAa = "1234";
            const string testContentB = "efgh";

            Reset();
            Messenger.Reset();

            Messenger.Default.Register<TestMessageA>(
                this,
                true,
                m =>
                {
                    var messageA = m;
                    if (messageA != null)
                    {
                        ReceivedContentStringA1 = messageA.Content;
                    }

                    var messageAa = m as TestMessageAa;
                    if (messageAa != null)
                    {
                        ReceivedContentStringA2 = messageAa.Content;
                    }
                });

            Assert.AreEqual(null, ReceivedContentStringA1);
            Assert.AreEqual(null, ReceivedContentStringA2);
            Assert.AreEqual(null, ReceivedContentStringB);

            Messenger.Default.Send(new TestMessageA
            {
                Content = testContentA
            });

            Assert.AreEqual(testContentA, ReceivedContentStringA1);
            Assert.AreEqual(null, ReceivedContentStringA2);
            Assert.AreEqual(null, ReceivedContentStringB);

            Messenger.Default.Send(new TestMessageAa
            {
                Content = testContentAa
            });

            Assert.AreEqual(testContentAa, ReceivedContentStringA1);
            Assert.AreEqual(testContentAa, ReceivedContentStringA2);
            Assert.AreEqual(null, ReceivedContentStringB);

            Messenger.Default.Send(new TestMessageB
            {
                Content = testContentB
            });

            Assert.AreEqual(testContentAa, ReceivedContentStringA1);
            Assert.AreEqual(testContentAa, ReceivedContentStringA2);
            Assert.AreEqual(null, ReceivedContentStringB);
        }

        [TestMethod]
        public void TestRegisterSimpleTypes()
        {
            const string testContentString = "abcd";
            var testContentDateTime = DateTime.Now;
            const int testContentInt = 42;

            Messenger.Reset();
            Reset();

            Messenger.Default.Register<string>(this, m => ReceivedContentStringA1 = m);
            Messenger.Default.Register<DateTime>(this, m => ReceivedContentDateTime1 = m);
            Messenger.Default.Register<int>(this, m => ReceivedContentInt = m);

            Assert.AreEqual(null, ReceivedContentStringA1);
            Assert.AreEqual(DateTime.MinValue, ReceivedContentDateTime1);
            Assert.AreEqual(default(int), ReceivedContentInt);

            Messenger.Default.Send(testContentString);

            Assert.AreEqual(testContentString, ReceivedContentStringA1);
            Assert.AreEqual(DateTime.MinValue, ReceivedContentDateTime1);
            Assert.AreEqual(default(int), ReceivedContentInt);

            Messenger.Default.Send(testContentDateTime);

            Assert.AreEqual(testContentString, ReceivedContentStringA1);
            Assert.AreEqual(testContentDateTime, ReceivedContentDateTime1);
            Assert.AreEqual(default(int), ReceivedContentInt);

            Messenger.Default.Send(testContentInt);

            Assert.AreEqual(testContentString, ReceivedContentStringA1);
            Assert.AreEqual(testContentDateTime, ReceivedContentDateTime1);
            Assert.AreEqual(testContentInt, ReceivedContentInt);
        }

        [TestMethod]
        public void TestUnregisterOneAction()
        {
            const string testContentA1 = "abcd";
            const string testContentB1 = "1234";
            const string testContentA2 = "efgh";
            const string testContentB2 = "5678";

            Reset();
            Messenger.Reset();

            Action<TestMessageA> actionA1 = m => ReceivedContentStringA1 = m.Content;

            Messenger.Default.Register(this, actionA1);
            Messenger.Default.Register<TestMessageA>(this, m => ReceivedContentStringA2 = m.Content);
            Messenger.Default.Register<TestMessageB>(this, m => ReceivedContentStringB = m.Content);

            var externalRecipient = new TestRecipient();
            externalRecipient.RegisterWith(Messenger.Default);

            Assert.AreEqual(null, ReceivedContentStringA1);
            Assert.AreEqual(null, ReceivedContentStringA2);
            Assert.AreEqual(null, ReceivedContentStringB);
            Assert.AreEqual(null, externalRecipient.ReceivedContentA);
            Assert.AreEqual(null, externalRecipient.ReceivedContentB);

            Messenger.Default.Send(new TestMessageA
            {
                Content = testContentA1
            });

            Messenger.Default.Send(new TestMessageB
            {
                Content = testContentB1
            });

            Assert.AreEqual(testContentA1, ReceivedContentStringA1);
            Assert.AreEqual(testContentA1, ReceivedContentStringA2);
            Assert.AreEqual(testContentB1, ReceivedContentStringB);
            Assert.AreEqual(testContentA1, externalRecipient.ReceivedContentA);
            Assert.AreEqual(testContentB1, externalRecipient.ReceivedContentB);

            Messenger.Default.Unregister(this, actionA1);

            Messenger.Default.Send(new TestMessageA
            {
                Content = testContentA2
            });

            Messenger.Default.Send(new TestMessageB
            {
                Content = testContentB2
            });

            Assert.AreEqual(testContentA1, ReceivedContentStringA1);
            Assert.AreEqual(testContentA2, ReceivedContentStringA2);
            Assert.AreEqual(testContentB2, ReceivedContentStringB);
            Assert.AreEqual(testContentA2, externalRecipient.ReceivedContentA);
            Assert.AreEqual(testContentB2, externalRecipient.ReceivedContentB);
        }

        [TestMethod]
        public void TestUnregisterOneInstance()
        {
            const string testContentA1 = "abcd";
            const string testContentB1 = "1234";
            const string testContentA2 = "efgh";
            const string testContentB2 = "5678";

            Reset();
            Messenger.Reset();

            Messenger.Default.Register<TestMessageA>(this, m => ReceivedContentStringA1 = m.Content);
            Messenger.Default.Register<TestMessageA>(this, m => ReceivedContentStringA2 = m.Content);
            Messenger.Default.Register<TestMessageB>(this, m => ReceivedContentStringB = m.Content);

            var externalRecipient = new TestRecipient();
            externalRecipient.RegisterWith(Messenger.Default);

            Assert.AreEqual(null, ReceivedContentStringA1);
            Assert.AreEqual(null, ReceivedContentStringA2);
            Assert.AreEqual(null, ReceivedContentStringB);
            Assert.AreEqual(null, externalRecipient.ReceivedContentA);
            Assert.AreEqual(null, externalRecipient.ReceivedContentB);

            Messenger.Default.Send(new TestMessageA
            {
                Content = testContentA1
            });

            Messenger.Default.Send(new TestMessageB
            {
                Content = testContentB1
            });

            Assert.AreEqual(testContentA1, ReceivedContentStringA1);
            Assert.AreEqual(testContentA1, ReceivedContentStringA2);
            Assert.AreEqual(testContentB1, ReceivedContentStringB);
            Assert.AreEqual(testContentA1, externalRecipient.ReceivedContentA);
            Assert.AreEqual(testContentB1, externalRecipient.ReceivedContentB);

            Messenger.Default.Unregister(this);

            Messenger.Default.Send(new TestMessageA
            {
                Content = testContentA2
            });

            Messenger.Default.Send(new TestMessageB
            {
                Content = testContentB2
            });

            Assert.AreEqual(testContentA1, ReceivedContentStringA1);
            Assert.AreEqual(testContentA1, ReceivedContentStringA2);
            Assert.AreEqual(testContentB1, ReceivedContentStringB);
            Assert.AreEqual(testContentA2, externalRecipient.ReceivedContentA);
            Assert.AreEqual(testContentB2, externalRecipient.ReceivedContentB);
        }

        [TestMethod]
        public void TestUnregisterOneMessageType()
        {
            const string testContentA1 = "abcd";
            const string testContentB1 = "1234";
            const string testContentA2 = "efgh";
            const string testContentB2 = "5678";

            Reset();
            Messenger.Reset();

            Messenger.Default.Register<TestMessageA>(this, m => ReceivedContentStringA1 = m.Content);
            Messenger.Default.Register<TestMessageA>(this, m => ReceivedContentStringA2 = m.Content);
            Messenger.Default.Register<TestMessageB>(this, m => ReceivedContentStringB = m.Content);

            var externalRecipient = new TestRecipient();
            externalRecipient.RegisterWith(Messenger.Default);

            Assert.AreEqual(null, ReceivedContentStringA1);
            Assert.AreEqual(null, ReceivedContentStringA2);
            Assert.AreEqual(null, ReceivedContentStringB);
            Assert.AreEqual(null, externalRecipient.ReceivedContentA);
            Assert.AreEqual(null, externalRecipient.ReceivedContentB);

            Messenger.Default.Send(new TestMessageA
            {
                Content = testContentA1
            });

            Messenger.Default.Send(new TestMessageB
            {
                Content = testContentB1
            });

            Assert.AreEqual(testContentA1, ReceivedContentStringA1);
            Assert.AreEqual(testContentA1, ReceivedContentStringA2);
            Assert.AreEqual(testContentB1, ReceivedContentStringB);
            Assert.AreEqual(testContentA1, externalRecipient.ReceivedContentA);
            Assert.AreEqual(testContentB1, externalRecipient.ReceivedContentB);

            Messenger.Default.Unregister<TestMessageA>(this);

            Messenger.Default.Send(new TestMessageA
            {
                Content = testContentA2
            });

            Messenger.Default.Send(new TestMessageB
            {
                Content = testContentB2
            });

            Assert.AreEqual(testContentA1, ReceivedContentStringA1);
            Assert.AreEqual(testContentA1, ReceivedContentStringA2);
            Assert.AreEqual(testContentB2, ReceivedContentStringB);
            Assert.AreEqual(testContentA2, externalRecipient.ReceivedContentA);
            Assert.AreEqual(testContentB2, externalRecipient.ReceivedContentB);
        }

        [TestMethod]
        public void TestRegisterUnregisterInterfaceMessage()
        {
            const string testContent1 = "abcd";
            const string testContent2 = "efgh";

            Reset();
            Messenger.Reset();

            Messenger.Default.Register<IMessage>(this, true, m => ReceivedContentStringA1 = m.GetValue());

            Assert.AreEqual(null, ReceivedContentStringA1);

            Messenger.Default.Send(new TestMessageImplementsIMessage(testContent1));

            Assert.AreEqual(testContent1, ReceivedContentStringA1);

            Messenger.Default.Unregister<IMessage>(this);

            Messenger.Default.Send(new TestMessageImplementsIMessage(testContent2));

            Assert.AreEqual(testContent1, ReceivedContentStringA1);
        }

        [TestMethod]
        public void TestRegisterUnregisterOneActionWithToken()
        {
            const string testContent1 = "abcd";
            const string testContent2 = "efgh";
            const string testContent3 = "ijkl";
            const string testContent4 = "mnop";
            const int token1 = 1234;
            const int token2 = 4567;

            Reset();
            Messenger.Reset();

            Action<string> action1 = m => ReceivedContentStringA1 = m;
            Action<string> action2 = m => ReceivedContentStringA2 = m;
            Action<string> action3 = m => ReceivedContentStringB = m;

            Messenger.Default.Register(this, token1, action1);
            Messenger.Default.Register(this, token2, action2);
            Messenger.Default.Register(this, token2, action3);

            Messenger.Default.Send(testContent1, token1);
            Messenger.Default.Send(testContent2, token2);

            Assert.AreEqual(testContent1, ReceivedContentStringA1);
            Assert.AreEqual(testContent2, ReceivedContentStringA2);
            Assert.AreEqual(testContent2, ReceivedContentStringB);

            Messenger.Default.Unregister(this, token2, action3);
            Messenger.Default.Send(testContent3, token1);
            Messenger.Default.Send(testContent4, token2);

            Assert.AreEqual(testContent3, ReceivedContentStringA1);
            Assert.AreEqual(testContent4, ReceivedContentStringA2);
            Assert.AreEqual(testContent2, ReceivedContentStringB);
        }

        [TestMethod]
        public void TestRegisterUnregisterWithToken()
        {
            const string testContent1 = "abcd";
            const string testContent2 = "efgh";
            const string testContent3 = "ijkl";
            const int token1 = 1234;
            const int token2 = 4567;

            Reset();
            Messenger.Reset();

            Messenger.Default.Register<string>(this, token1, m => ReceivedContentStringA1 = m);
            Messenger.Default.Register<string>(this, token2, m => ReceivedContentStringA2 = m);

            Assert.AreEqual(null, ReceivedContentStringA1);
            Assert.AreEqual(null, ReceivedContentStringA2);

            Messenger.Default.Send(testContent1, token1);

            Assert.AreEqual(testContent1, ReceivedContentStringA1);
            Assert.AreEqual(null, ReceivedContentStringA2);

            Messenger.Default.Send(testContent2, token2);

            Assert.AreEqual(testContent1, ReceivedContentStringA1);
            Assert.AreEqual(testContent2, ReceivedContentStringA2);

            Messenger.Default.Unregister<string>(this, token1);
            Messenger.Default.Send(testContent3, token1);

            Assert.AreEqual(testContent1, ReceivedContentStringA1);
            Assert.AreEqual(testContent2, ReceivedContentStringA2);
        }

        //// Helpers

        private void Reset()
        {
            ReceivedContentStringA1 = null;
            ReceivedContentStringA2 = null;
            ReceivedContentStringB = null;
            ReceivedContentInt = default(int);

            ReceivedContentDateTime1 = DateTime.MinValue;
            ReceivedContentDateTime2 = DateTime.MinValue;
            ReceivedContentException = null;
        }

        public class TestMessageA
        {
            public string Content
            {
                get;
                set;
            }
        }

        public class TestMessageAa : TestMessageA
        {
        }

        public class TestMessageB
        {
            public string Content
            {
                get;
                set;
            }
        }

        public class TestMessageGenericBase
        {
        }

        private class TestRecipient
        {
            public string ReceivedContentA
            {
                get;
                private set;
            }

            public string ReceivedContentB
            {
                get;
                private set;
            }

            internal void RegisterWith(Messenger messenger)
            {
                messenger.Register<TestMessageA>(this, m => ReceivedContentA = m.Content);
                messenger.Register<TestMessageB>(this, m => ReceivedContentB = m.Content);
            }
        }

        private interface IMessage
        {
            string GetValue();
        }

        public class TestMessageImplementsIMessage : IMessage
        {
            private string Value
            {
                get;
                set;
            }

            public TestMessageImplementsIMessage(string value)
            {
                Value = value;
            }

            public string GetValue()
            {
                return Value;
            }
        }

    }
}