using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GalaSoft.MvvmLight.Messaging;

namespace GalaSoft.MvvmLight.Test.Messaging
{
    [TestClass]
    public class MessengerOverrideDefaultTest
    {
        private string ReceivedContent
        {
            get;
            set;
        }

        [TestMethod]
        public void TestOverrideDefault()
        {
            const string TestContent1 = "Test content 1";
            const string TestContent2 = "Test content 2";
            const string TestContent3 = "Test content 3";

            Messenger.Reset();

            Messenger.Default.Register<string>(this, m => ReceivedContent = m);
            Assert.IsNull(ReceivedContent);
            Messenger.Default.Send(TestContent1);
            Assert.AreEqual(TestContent1, ReceivedContent);

            Messenger.Reset();
            Messenger.OverrideDefault(new TestMessenger());

            Messenger.Default.Send(TestContent2);
            Assert.AreEqual(1, ((TestMessenger)Messenger.Default).MessagesTransmitted);
            Assert.AreEqual(TestContent1, ReceivedContent);

            Messenger.Default.Register<string>(this, m => ReceivedContent = m);
            Assert.AreEqual(1, ((TestMessenger)Messenger.Default).MessagesTransmitted);
            Messenger.Default.Send(TestContent3);
            Assert.AreEqual(TestContent3, ReceivedContent);
            Assert.AreEqual(2, ((TestMessenger)Messenger.Default).MessagesTransmitted);
        }

        // Helpers

        private class TestMessenger : Messenger
        {
            private readonly List<Delegate> _recipients = new List<Delegate>();

            public int MessagesTransmitted
            {
                get;
                private set;
            }

            public override void Send<TMessage>(TMessage message)
            {
                MessagesTransmitted++;

                base.Send(message);
            }
        }
    }
}
