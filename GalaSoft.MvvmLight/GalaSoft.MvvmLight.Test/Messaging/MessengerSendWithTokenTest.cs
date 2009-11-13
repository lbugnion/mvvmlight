using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GalaSoft.MvvmLight.Messaging;

namespace GalaSoft.MvvmLight.Test.Messaging
{
    [TestClass]
    public class MessengerSendWithTokenTest
    {
        [TestMethod]
        public void TestSendWithToken()
        {
            string receivedContent1 = null;
            string receivedContent2 = null;
            string receivedContent3 = null;

            Messenger.Reset();

            var token1 = new object();
            var token2 = new object();

            Messenger.Default.Register<string>(this, m => receivedContent1 = m);
            Messenger.Default.Register<string>(this, token1, m => receivedContent2 = m);
            Messenger.Default.Register<string>(this, token2, m => receivedContent3 = m);

            var message1 = "Hello world";
            var message2 = "And again";
            var message3 = "Third one";

            Messenger.Default.Send(message1, token1);

            Assert.IsNull(receivedContent1);
            Assert.AreEqual(message1, receivedContent2);
            Assert.IsNull(receivedContent3);

            Messenger.Default.Send(message2, token2);

            Assert.IsNull(receivedContent1);
            Assert.AreEqual(message1, receivedContent2);
            Assert.AreEqual(message2, receivedContent3);

            Messenger.Default.Send(message3);

            Assert.AreEqual(message3, receivedContent1);
            Assert.AreEqual(message1, receivedContent2);
            Assert.AreEqual(message2, receivedContent3);
        }

        [TestMethod]
        public void TestSendMessageBaseWithToken()
        {
            Exception receivedContent1 = null;
            Exception receivedContent2 = null;
            Exception receivedContent3 = null;

            Messenger.Reset();

            var token1 = new object();
            var token2 = new object();

            Messenger.Default.Register<Exception>(this, true, m => receivedContent1 = m);
            Messenger.Default.Register<Exception>(this, token1, true, m => receivedContent2 = m);
            Messenger.Default.Register<Exception>(this, token2, true, m => receivedContent3 = m);

            var message = new InvalidOperationException();

            Messenger.Default.Send(message, token1);

            Assert.IsNull(receivedContent1);
            Assert.AreEqual(message, receivedContent2);
            Assert.IsNull(receivedContent3);
        }

        [TestMethod]
        public void TestSendWithIntToken()
        {
            InvalidOperationException receivedContent1 = null;
            InvalidOperationException receivedContent2 = null;
            InvalidOperationException receivedContent3 = null;

            Messenger.Reset();

            var token1 = 123;
            var token2 = 456;

            Messenger.Default.Register<InvalidOperationException>(this, m => receivedContent1 = m);
            Messenger.Default.Register<InvalidOperationException>(this, token1, m => receivedContent2 = m);
            Messenger.Default.Register<InvalidOperationException>(this, token2, m => receivedContent3 = m);

            var message = new InvalidOperationException();

            Messenger.Default.Send(message, token1);

            Assert.IsNull(receivedContent1);
            Assert.AreEqual(message, receivedContent2);
            Assert.IsNull(receivedContent3);
        }
    }
}
