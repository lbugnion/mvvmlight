using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GalaSoft.MvvmLight.Test.Messaging
{
    [TestClass]
    public class MessengerBroadcastToTypeTest
    {
        [TestMethod]
        public void TestBroadcastToOneType()
        {
            Messenger.Reset();

            var recipient11 = new TestRecipient1();
            var recipient12 = new TestRecipient1();
            var recipient21 = new TestRecipient2();
            var recipient22 = new TestRecipient2();

            Messenger.Default.Register<string>(recipient11, recipient11.ReceiveMessage);
            Messenger.Default.Register<string>(recipient12, recipient12.ReceiveMessage);
            Messenger.Default.Register<string>(recipient21, recipient21.ReceiveMessage);
            Messenger.Default.Register<string>(recipient22, recipient22.ReceiveMessage);

            const string TestContent1 = "abcd";
            const string TestContent2 = "efgh";

            Assert.AreEqual(null, recipient11.ReceivedContentString);
            Assert.AreEqual(null, recipient12.ReceivedContentString);
            Assert.AreEqual(null, recipient21.ReceivedContentString);
            Assert.AreEqual(null, recipient22.ReceivedContentString);

            Messenger.Default.Send<string, TestRecipient1>(TestContent1);

            Assert.AreEqual(TestContent1, recipient11.ReceivedContentString);
            Assert.AreEqual(TestContent1, recipient12.ReceivedContentString);
            Assert.AreEqual(null, recipient21.ReceivedContentString);
            Assert.AreEqual(null, recipient22.ReceivedContentString);

            Messenger.Default.Send<string, TestRecipient2>(TestContent2);

            Assert.AreEqual(TestContent1, recipient11.ReceivedContentString);
            Assert.AreEqual(TestContent1, recipient12.ReceivedContentString);
            Assert.AreEqual(TestContent2, recipient21.ReceivedContentString);
            Assert.AreEqual(TestContent2, recipient22.ReceivedContentString);
        }

        //// Helpers

        private class TestRecipient1
        {
            public string ReceivedContentString
            {
                get;
                private set;
            }

            public void ReceiveMessage(string message)
            {
                ReceivedContentString = message;
            }
        }

        private class TestRecipient2
        {
            public string ReceivedContentString
            {
                get;
                private set;
            }

            public void ReceiveMessage(string message)
            {
                ReceivedContentString = message;
            }
        }
    }
}