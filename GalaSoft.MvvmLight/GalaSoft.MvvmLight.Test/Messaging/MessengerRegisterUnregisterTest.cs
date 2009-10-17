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

        [TestMethod]
        public void TestRegisterForGenericMessageBase()
        {
            var testContentException = new InvalidOperationException();
            var testContentDateTime = DateTime.Now;
            const string TestContentString = "abcd";

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
                Content = TestContentString
            });

            Assert.AreEqual(TestContentString, ReceivedContentStringA1);
            Assert.AreEqual(testContentException, ReceivedContentException);
            Assert.AreEqual(testContentDateTime, ReceivedContentDateTime1);
        }

        [TestMethod]
        public void TestRegisterForGenericMessageSpecific()
        {
            var testContentException = new InvalidOperationException();
            var testContentDateTime = DateTime.Now;
            const string TestContentString = "abcd";

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
                Content = TestContentString
            });

            Assert.AreEqual(TestContentString, ReceivedContentStringA1);
            Assert.AreEqual(testContentException, ReceivedContentException);
            Assert.AreEqual(testContentDateTime, ReceivedContentDateTime1);
        }

        [TestMethod]
        public void TestRegisterForSubclassesOfObject()
        {
            const string TestContentA = "abcd";
            const string TestContentB = "efgh";

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
                Content = TestContentA
            });

            Assert.AreEqual(TestContentA, ReceivedContentStringA1);
            Assert.AreEqual(null, ReceivedContentStringB);

            Messenger.Default.Send(new TestMessageB
            {
                Content = TestContentB
            });

            Assert.AreEqual(TestContentA, ReceivedContentStringA1);
            Assert.AreEqual(TestContentB, ReceivedContentStringB);
        }

        [TestMethod]
        public void TestRegisterForSubclassesOfTestMessageA()
        {
            const string TestContentA = "abcd";
            const string TestContentAa = "1234";
            const string TestContentB = "efgh";

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
                Content = TestContentA
            });

            Assert.AreEqual(TestContentA, ReceivedContentStringA1);
            Assert.AreEqual(null, ReceivedContentStringA2);
            Assert.AreEqual(null, ReceivedContentStringB);

            Messenger.Default.Send(new TestMessageAa
            {
                Content = TestContentAa
            });

            Assert.AreEqual(TestContentAa, ReceivedContentStringA1);
            Assert.AreEqual(TestContentAa, ReceivedContentStringA2);
            Assert.AreEqual(null, ReceivedContentStringB);

            Messenger.Default.Send(new TestMessageB
            {
                Content = TestContentB
            });

            Assert.AreEqual(TestContentAa, ReceivedContentStringA1);
            Assert.AreEqual(TestContentAa, ReceivedContentStringA2);
            Assert.AreEqual(null, ReceivedContentStringB);
        }

        [TestMethod]
        public void TestRegisterSimpleTypes()
        {
            const string TestContentString = "abcd";
            var testContentDateTime = DateTime.Now;
            const int TestContentInt = 42;

            Messenger.Reset();
            Reset();

            Messenger.Default.Register<string>(this, m => ReceivedContentStringA1 = m);
            Messenger.Default.Register<DateTime>(this, m => ReceivedContentDateTime1 = m);
            Messenger.Default.Register<int>(this, m => ReceivedContentInt = m);

            Assert.AreEqual(null, ReceivedContentStringA1);
            Assert.AreEqual(DateTime.MinValue, ReceivedContentDateTime1);
            Assert.AreEqual(default(int), ReceivedContentInt);

            Messenger.Default.Send(TestContentString);

            Assert.AreEqual(TestContentString, ReceivedContentStringA1);
            Assert.AreEqual(DateTime.MinValue, ReceivedContentDateTime1);
            Assert.AreEqual(default(int), ReceivedContentInt);

            Messenger.Default.Send(testContentDateTime);

            Assert.AreEqual(TestContentString, ReceivedContentStringA1);
            Assert.AreEqual(testContentDateTime, ReceivedContentDateTime1);
            Assert.AreEqual(default(int), ReceivedContentInt);

            Messenger.Default.Send(TestContentInt);

            Assert.AreEqual(TestContentString, ReceivedContentStringA1);
            Assert.AreEqual(testContentDateTime, ReceivedContentDateTime1);
            Assert.AreEqual(TestContentInt, ReceivedContentInt);
        }

        [TestMethod]
        public void TestRegisterStrictandNonStricRecipients()
        {
            var testContentDateTime = DateTime.Now;
            const string TestContentString = "abcd";

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
                Content = TestContentString
            });

            Assert.AreEqual(3, receivedMessages);
            Assert.AreEqual(TestContentString, ReceivedContentStringA1);
            Assert.AreEqual(testContentDateTime, ReceivedContentDateTime1);
            Assert.AreEqual(testContentDateTime, ReceivedContentDateTime2);
        }

        [TestMethod]
        public void TestUnregisterOneAction()
        {
            const string TestContentA1 = "abcd";
            const string TestContentB1 = "1234";
            const string TestContentA2 = "efgh";
            const string TestContentB2 = "5678";

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
                Content = TestContentA1
            });

            Messenger.Default.Send(new TestMessageB
            {
                Content = TestContentB1
            });

            Assert.AreEqual(TestContentA1, ReceivedContentStringA1);
            Assert.AreEqual(TestContentA1, ReceivedContentStringA2);
            Assert.AreEqual(TestContentB1, ReceivedContentStringB);
            Assert.AreEqual(TestContentA1, externalRecipient.ReceivedContentA);
            Assert.AreEqual(TestContentB1, externalRecipient.ReceivedContentB);

            Messenger.Default.Unregister(this, actionA1);

            Messenger.Default.Send(new TestMessageA
            {
                Content = TestContentA2
            });

            Messenger.Default.Send(new TestMessageB
            {
                Content = TestContentB2
            });

            Assert.AreEqual(TestContentA1, ReceivedContentStringA1);
            Assert.AreEqual(TestContentA2, ReceivedContentStringA2);
            Assert.AreEqual(TestContentB2, ReceivedContentStringB);
            Assert.AreEqual(TestContentA2, externalRecipient.ReceivedContentA);
            Assert.AreEqual(TestContentB2, externalRecipient.ReceivedContentB);
        }

        [TestMethod]
        public void TestUnregisterOneInstance()
        {
            const string TestContentA1 = "abcd";
            const string TestContentB1 = "1234";
            const string TestContentA2 = "efgh";
            const string TestContentB2 = "5678";

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
                Content = TestContentA1
            });

            Messenger.Default.Send(new TestMessageB
            {
                Content = TestContentB1
            });

            Assert.AreEqual(TestContentA1, ReceivedContentStringA1);
            Assert.AreEqual(TestContentA1, ReceivedContentStringA2);
            Assert.AreEqual(TestContentB1, ReceivedContentStringB);
            Assert.AreEqual(TestContentA1, externalRecipient.ReceivedContentA);
            Assert.AreEqual(TestContentB1, externalRecipient.ReceivedContentB);

            Messenger.Default.Unregister(this);

            Messenger.Default.Send(new TestMessageA
            {
                Content = TestContentA2
            });

            Messenger.Default.Send(new TestMessageB
            {
                Content = TestContentB2
            });

            Assert.AreEqual(TestContentA1, ReceivedContentStringA1);
            Assert.AreEqual(TestContentA1, ReceivedContentStringA2);
            Assert.AreEqual(TestContentB1, ReceivedContentStringB);
            Assert.AreEqual(TestContentA2, externalRecipient.ReceivedContentA);
            Assert.AreEqual(TestContentB2, externalRecipient.ReceivedContentB);
        }

        [TestMethod]
        public void TestUnregisterOneMessageType()
        {
            const string TestContentA1 = "abcd";
            const string TestContentB1 = "1234";
            const string TestContentA2 = "efgh";
            const string TestContentB2 = "5678";

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
                Content = TestContentA1
            });

            Messenger.Default.Send(new TestMessageB
            {
                Content = TestContentB1
            });

            Assert.AreEqual(TestContentA1, ReceivedContentStringA1);
            Assert.AreEqual(TestContentA1, ReceivedContentStringA2);
            Assert.AreEqual(TestContentB1, ReceivedContentStringB);
            Assert.AreEqual(TestContentA1, externalRecipient.ReceivedContentA);
            Assert.AreEqual(TestContentB1, externalRecipient.ReceivedContentB);

            Messenger.Default.Unregister<TestMessageA>(this);

            Messenger.Default.Send(new TestMessageA
            {
                Content = TestContentA2
            });

            Messenger.Default.Send(new TestMessageB
            {
                Content = TestContentB2
            });

            Assert.AreEqual(TestContentA1, ReceivedContentStringA1);
            Assert.AreEqual(TestContentA1, ReceivedContentStringA2);
            Assert.AreEqual(TestContentB2, ReceivedContentStringB);
            Assert.AreEqual(TestContentA2, externalRecipient.ReceivedContentA);
            Assert.AreEqual(TestContentB2, externalRecipient.ReceivedContentB);
        }

        [TestMethod]
        public void TestRegisterUnregisterInterfaceMessage()
        {
            const string TestContent1 = "abcd";
            const string TestContent2 = "efgh";

            Reset();
            Messenger.Reset();

            Messenger.Default.Register<IMessage>(this, true, m => ReceivedContentStringA1 = m.GetValue());

            Assert.AreEqual(null, ReceivedContentStringA1);

            Messenger.Default.Send(new TestMessageImplementsIMessage(TestContent1));

            Assert.AreEqual(TestContent1, ReceivedContentStringA1);

            Messenger.Default.Unregister<IMessage>(this);

            Messenger.Default.Send(new TestMessageImplementsIMessage(TestContent2));

            Assert.AreEqual(TestContent1, ReceivedContentStringA1);
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

        public class TestMessageGeneric<T> : TestMessageGenericBase
        {
            public T Content
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
                set;
            }

            public string ReceivedContentB
            {
                get;
                set;
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