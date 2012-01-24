using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GalaSoft.MvvmLight.Test.Messaging
{
    [TestClass]
    public class MessengerSendToAllTest
    {
        public string StringContent1
        {
            get;
            private set;
        }

        public string StringContent2
        {
            get;
            private set;
        }

        [TestMethod]
        public void TestSendingToAllRecipients()
        {
            const string TestContent = "abcd";

            Reset();
            Messenger.Reset();

            Messenger.Default.Register<TestMessage>(this, m => StringContent1 = m.Content);

            Messenger.Default.Register<TestMessage>(this, m => StringContent2 = m.Content);

            var externalRecipient = new TestRecipient();
            externalRecipient.RegisterWith(Messenger.Default);

            Assert.AreEqual(null, StringContent1);
            Assert.AreEqual(null, StringContent2);
            Assert.AreEqual(null, externalRecipient.StringContent);

            Messenger.Default.Send(new TestMessage
            {
                Content = TestContent
            });

            Assert.AreEqual(TestContent, StringContent1);
            Assert.AreEqual(TestContent, StringContent2);
            Assert.AreEqual(TestContent, externalRecipient.StringContent);
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void TestSendingNullMessage()
        {
            Messenger.Reset();
            Messenger.Default.Send<NotificationMessage>(null);
        }

        //// Helpers

        private void Reset()
        {
            StringContent1 = null;
            StringContent2 = null;
        }

        public class TestMessage
        {
            public string Content
            {
                get;
                set;
            }
        }

        private class TestRecipient
        {
            public string StringContent
            {
                get;
                private set;
            }

            internal void RegisterWith(Messenger messenger)
            {
                messenger.Register<TestMessage>(this, m => StringContent = m.Content);
            }
        }
    }
}