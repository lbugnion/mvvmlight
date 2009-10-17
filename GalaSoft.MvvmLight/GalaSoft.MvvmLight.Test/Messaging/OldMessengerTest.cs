using System;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GalaSoft.MvvmLight.Test.Messaging
{
    [TestClass]
    public class OldMessengerTest
    {
        [TestMethod]
        public void StressTestRaisePropertyChanged()
        {
            Messenger.Reset();
            var vm = new OldTestViewModel();
            var recipient = new OldTestRecipient2();

            Messenger.Default.Register(recipient, typeof(PropertyChangedMessage<DateTime>));

            const int TestCount = 100000;

            for (var index = 0; index < TestCount; index++)
            {
                vm.LastChanged2 = DateTime.Now + TimeSpan.FromMinutes(index);
            }

            Assert.AreEqual(TestCount, recipient.ReceivedMessagesCount);

            recipient = null;

            GC.Collect();

            for (var index = 0; index < TestCount; index++)
            {
                vm.LastChanged2 = DateTime.Now + TimeSpan.FromMinutes(index);
            }
        }

        [TestMethod]
        public void TestFreeingReferences()
        {
            Messenger.Reset();
        }

        [TestMethod]
        public void TestMultipleMessageTypes()
        {
            var messenger = new Messenger();
            var recipient = new OldTestRecipient();

            messenger.Register(recipient, typeof(OldTestMessage));
            messenger.Register(recipient, typeof(GenericMessage<InvalidOperationException>));
            messenger.Register(recipient, typeof(GenericMessage<MissingMethodException>));

            Assert.IsNull(recipient.Content);
            Assert.IsNull(recipient.ObjectContent1);
            Assert.IsNull(recipient.ObjectContent2);

            var testObject1 = new InvalidOperationException();
            var genericMessage = new GenericMessage<InvalidOperationException>(this, testObject1);
            messenger.Broadcast(genericMessage);
            Assert.AreEqual(this, recipient.Sender);
            Assert.IsNull(recipient.Content);
            Assert.AreEqual(testObject1, recipient.ObjectContent1);
            Assert.IsNull(recipient.ObjectContent2);

            var testObject2 = new MissingMethodException();
            var genericMessage2 = new GenericMessage<MissingMethodException>(this, testObject2);
            messenger.Broadcast(genericMessage2);
            Assert.AreEqual(this, recipient.Sender);
            Assert.IsNull(recipient.Content);
            Assert.AreEqual(testObject1, recipient.ObjectContent1);
            Assert.AreEqual(testObject2, recipient.ObjectContent2);

            const string TestString = "Hello world";
            var message = new OldTestMessage(this, TestString);
            messenger.Broadcast(message);
            Assert.AreEqual(this, recipient.Sender);
            Assert.AreEqual(TestString, recipient.Content);
            Assert.AreEqual(testObject1, recipient.ObjectContent1);
            Assert.AreEqual(testObject2, recipient.ObjectContent2);
        }

        [TestMethod]
        public void TestMultipleRecipients()
        {
            var messenger = new Messenger();
            var recipient1 = new OldTestRecipient();
            var recipient2 = new OldTestRecipient();
            var recipient3 = new OldTestRecipient();

            messenger.Register(recipient1, typeof(OldTestMessage));
            messenger.Register(recipient2, typeof(OldTestMessage));
            messenger.Register(recipient3, typeof(OldTestMessage));

            Assert.IsNull(recipient1.Sender);
            Assert.IsNull(recipient1.Content);
            Assert.IsNull(recipient2.Content);
            Assert.IsNull(recipient2.Sender);
            Assert.IsNull(recipient3.Content);
            Assert.IsNull(recipient3.Sender);

            const string TestString = "Hello world";
            var message = new OldTestMessage(this, TestString);
            messenger.Broadcast(message);

            Assert.AreEqual(TestString, recipient1.Content);
            Assert.AreEqual(this, recipient1.Sender);
            Assert.AreEqual(TestString, recipient2.Content);
            Assert.AreEqual(this, recipient2.Sender);
            Assert.AreEqual(TestString, recipient3.Content);
            Assert.AreEqual(this, recipient3.Sender);
        }

        [TestMethod]
        public void TestMultipleRecipientsWithObjects()
        {
            var messenger = new Messenger();
            var recipient1 = new OldTestRecipient();
            var recipient2 = new OldTestRecipient();
            var recipient3 = new OldTestRecipient();

            messenger.Register(recipient1, typeof(GenericMessage<InvalidOperationException>));
            messenger.Register(recipient2, typeof(GenericMessage<InvalidOperationException>));
            messenger.Register(recipient3, typeof(GenericMessage<InvalidOperationException>));

            Assert.IsNull(recipient1.Sender);
            Assert.IsNull(recipient1.Content);
            Assert.IsNull(recipient2.Content);
            Assert.IsNull(recipient2.Sender);
            Assert.IsNull(recipient3.Content);
            Assert.IsNull(recipient3.Sender);

            var testContent = new InvalidOperationException();
            var message = new GenericMessage<InvalidOperationException>(this, testContent);
            messenger.Broadcast(message);

            Assert.AreEqual(this, recipient1.Sender);
            Assert.AreEqual(testContent, recipient1.ObjectContent1);
            Assert.AreEqual(this, recipient2.Sender);
            Assert.AreEqual(testContent, recipient2.ObjectContent1);
            Assert.AreEqual(this, recipient3.Sender);
            Assert.AreEqual(testContent, recipient3.ObjectContent1);
        }

        [TestMethod]
        public void TestPropertyChangedMessage()
        {
            Messenger.Reset();

            var recipient1 = new OldTestRecipient();
            Messenger.Default.Register(recipient1, typeof(PropertyChangedMessage<DateTime>));
            Assert.AreEqual(DateTime.MinValue, recipient1.DateTimeContent);

            var testVm = new OldTestViewModel();
            var now = DateTime.Now;
            testVm.LastChanged2 = now;

            Assert.AreEqual(testVm, recipient1.Sender);
            Assert.AreEqual(now, recipient1.DateTimeContent);
        }

        [TestMethod]
        public void TestRegister()
        {
            var messenger = new Messenger();
            var recipient = new OldTestRecipient();

            messenger.Register(recipient, typeof(OldTestMessage));

            Assert.IsNull(recipient.Content);

            const string TestString = "Hello world";
            var message = new OldTestMessage(this, TestString);
            messenger.Broadcast(message);

            Assert.AreEqual(this, recipient.Sender);
            Assert.AreEqual(TestString, recipient.Content);
        }

        [TestMethod]
        public void TestRegisterForSubclasses1()
        {
            Messenger.Reset();
            var recipientForSubclasses = new OldTestRecipient();
            var recipientNoSubclasses = new OldTestRecipient();
            Messenger.Default.Register(recipientForSubclasses, typeof(MessageBase), true);
            Messenger.Default.Register(recipientNoSubclasses, typeof(MessageBase));

            var ex1 = new InvalidOperationException();
            var message = new OldInvalidOperationExceptionMessage(this, ex1);
            Messenger.Default.Broadcast(message);

            Assert.AreEqual(ex1, recipientForSubclasses.ObjectContent1);
            Assert.AreEqual(this, recipientForSubclasses.Sender);
            Assert.AreEqual(null, recipientNoSubclasses.ObjectContent1);
            Assert.AreEqual(null, recipientNoSubclasses.Sender);
        }

        [TestMethod]
        public void TestRegisterForSubclasses2()
        {
            Messenger.Reset();
            var recipientForSubclasses = new OldTestRecipient();
            var recipientNoSubclasses = new OldTestRecipient();
            Messenger.Default.Register(recipientForSubclasses, typeof(GenericMessage<>), true);
            Messenger.Default.Register(recipientNoSubclasses, typeof(GenericMessage<>));

            var ex1 = new InvalidOperationException();
            var message = new GenericMessage<InvalidOperationException>(this, ex1);
            Messenger.Default.Broadcast(message);

            Assert.AreEqual(ex1, recipientForSubclasses.ObjectContent1);
            Assert.AreEqual(this, recipientForSubclasses.Sender);
            Assert.AreEqual(null, recipientNoSubclasses.ObjectContent1);
            Assert.AreEqual(null, recipientNoSubclasses.Sender);
        }

        [TestMethod]
        public void TestRegisterForSubclasses3()
        {
            Messenger.Reset();
            var recipientForSubclasses = new OldTestRecipient();
            var recipientNoSubclasses = new OldTestRecipient();
            Messenger.Default.Register(recipientForSubclasses, typeof(MessageBase), true);
            Messenger.Default.Register(recipientNoSubclasses, typeof(MessageBase), true);

            var message = new MessageBase(this);
            Messenger.Default.Broadcast(message);

            Assert.AreEqual(this, recipientForSubclasses.Sender);
            Assert.AreEqual(message, recipientForSubclasses.Message);
            Assert.AreEqual(this, recipientNoSubclasses.Sender);
            Assert.AreEqual(message, recipientNoSubclasses.Message);
        }

        [TestMethod]
        public void TestRegisterForSubclasses4()
        {
            Messenger.Reset();
            var recipientForSubclasses = new OldTestRecipient();
            var recipientNoSubclasses = new OldTestRecipient();
            Messenger.Default.Register(recipientForSubclasses, typeof(OldTestMessage), true);
            Messenger.Default.Register(recipientNoSubclasses, typeof(OldTestMessage));

            var ex1 = new InvalidOperationException();
            var message = new GenericMessage<InvalidOperationException>(this, ex1);
            Messenger.Default.Broadcast(message);

            Assert.AreEqual(null, recipientForSubclasses.Sender);
            Assert.AreEqual(null, recipientForSubclasses.ObjectContent1);
            Assert.AreEqual(null, recipientNoSubclasses.Sender);
            Assert.AreEqual(null, recipientNoSubclasses.ObjectContent1);
        }

        [TestMethod]
        public void TestRegisterForSubclasses5()
        {
            Messenger.Reset();
            var recipientForSubclasses = new OldTestRecipient();
            var recipientNoSubclasses = new OldTestRecipient();
            Messenger.Default.Register(recipientForSubclasses, typeof(GenericMessage<>), true);
            Messenger.Default.Register(recipientNoSubclasses, typeof(GenericMessage<>));

            var message = new OldTestMessage(this, "Test string");
            Messenger.Default.Broadcast(message);

            Assert.AreEqual(null, recipientForSubclasses.Sender);
            Assert.AreEqual(null, recipientForSubclasses.ObjectContent1);
            Assert.AreEqual(null, recipientNoSubclasses.Sender);
            Assert.AreEqual(null, recipientNoSubclasses.ObjectContent1);
        }

        [TestMethod]
        public void TestRegisterForSubclasses6()
        {
            Messenger.Reset();
            var recipientForSubclasses = new OldTestRecipient();
            var recipientNoSubclasses = new OldTestRecipient();
            Messenger.Default.Register(recipientForSubclasses, typeof(PropertyChangedMessage<>), true);
            Messenger.Default.Register(recipientNoSubclasses, typeof(PropertyChangedMessage<>));

            var message = new GenericMessage<string>(this, "Test string");
            Messenger.Default.Broadcast(message);

            Assert.AreEqual(null, recipientForSubclasses.Sender);
            Assert.AreEqual(null, recipientForSubclasses.ObjectContent1);
            Assert.AreEqual(null, recipientNoSubclasses.Sender);
            Assert.AreEqual(null, recipientNoSubclasses.ObjectContent1);
        }

        [TestMethod]
        public void TestRegisterForSubclasses7()
        {
            Messenger.Reset();
            var recipientForSubclasses = new OldTestRecipient();
            var recipientNoSubclasses = new OldTestRecipient();
            Messenger.Default.Register(recipientForSubclasses, typeof(GenericMessage<object>), true);
            Messenger.Default.Register(recipientNoSubclasses, typeof(GenericMessage<object>));

            var message = new GenericMessage<string>(this, "Test string");
            Messenger.Default.Broadcast(message);

            Assert.AreEqual(null, recipientForSubclasses.Sender);
            Assert.AreEqual(null, recipientForSubclasses.ObjectContent1);
            Assert.AreEqual(null, recipientNoSubclasses.Sender);
            Assert.AreEqual(null, recipientNoSubclasses.ObjectContent1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRegisterInvalidType()
        {
            Messenger.Reset();
            var recipient1 = new OldTestRecipient();
            Messenger.Default.Register(recipient1, typeof(OldMessengerTest));
        }

        [TestMethod]
        public void TestSendToAll()
        {
            Messenger.Reset();

            const string TestString = "Hello world";

            var recipient = new OldTestRecipient();
            Messenger.Default.Register(recipient, typeof(GenericMessage<string>), false);

            var recipient2 = new OldTestRecipient2();
            Messenger.Default.Register(recipient2, typeof(GenericMessage<string>), false);

            var message = new GenericMessage<string>(this, TestString);
            Messenger.Default.Broadcast(message);

            Assert.AreEqual(TestString, recipient.Content);
            Assert.AreEqual(TestString, recipient2.Content);
        }

        [TestMethod]
        public void TestSendToTargetByInstance()
        {
            Messenger.Reset();

            const string TestString = "Hello world";

            var recipient = new OldTestRecipient();
            Messenger.Default.Register(recipient, typeof(GenericMessage<string>), false);

            var recipient2 = new OldTestRecipient2();
            Messenger.Default.Register(recipient2, typeof(GenericMessage<string>), false);

            var message = new GenericMessage<string>(this, recipient, TestString);
            Messenger.Default.Broadcast(message);

            Assert.AreEqual(TestString, recipient.Content);
            Assert.IsNull(recipient2.Content);
        }

        [TestMethod]
        public void TestSendToTargetByType()
        {
            Messenger.Reset();

            const string TestString = "Hello world";

            var recipient = new OldTestRecipient();
            Messenger.Default.Register(recipient, typeof(GenericMessage<string>), false);

            var recipient2 = new OldTestRecipient2();
            Messenger.Default.Register(recipient2, typeof(GenericMessage<string>), false);

            var message = new GenericMessage<string>(this, recipient.GetType(), TestString);
            Messenger.Default.Broadcast(message);

            Assert.AreEqual(TestString, recipient.Content);
            Assert.IsNull(recipient2.Content);
        }

        [TestMethod]
        public void TestStaticMessenger()
        {
            Messenger.Reset();

            var recipient1 = new OldTestRecipient();
            var recipient2 = new OldTestRecipient();

            Messenger.Default.Register(recipient1, typeof(OldTestMessage));
            Messenger.Default.Register(recipient2, typeof(OldTestMessage));

            Assert.IsNull(recipient1.Sender);
            Assert.IsNull(recipient2.Sender);
            Assert.IsNull(recipient1.Content);
            Assert.IsNull(recipient2.Content);

            const string TestString = "Hello world";
            Messenger.Default.Broadcast(new OldTestMessage(this, TestString));

            Assert.AreEqual(this, recipient1.Sender);
            Assert.AreEqual(TestString, recipient1.Content);
            Assert.AreEqual(this, recipient2.Sender);
            Assert.AreEqual(TestString, recipient2.Content);
        }

        [TestMethod]
        public void TestStaticMessengerNoRecipient()
        {
            Messenger.Reset();

            const string TestString = "Hello world";
            Messenger.Default.Broadcast(new OldTestMessage(this, TestString));
        }

        [TestMethod]
        public void TestUnregisterForAllTypes()
        {
            Messenger.Reset();

            const string TestString1 = "Hello world";
            const string TestString2 = "Another message";
            var now = DateTime.Now;
            var later = DateTime.Now + TimeSpan.FromDays(1);

            var recipient = new OldTestRecipient();
            Messenger.Default.Register(recipient, typeof(GenericMessage<string>), false);
            Messenger.Default.Register(recipient, typeof(CommandMessage<DateTime>), false);

            var recipient2 = new OldTestRecipient();
            Messenger.Default.Register(recipient2, typeof(GenericMessage<string>), false);
            Messenger.Default.Register(recipient2, typeof(CommandMessage<DateTime>), false);

            var message1 = new GenericMessage<string>(this, TestString1);
            Messenger.Default.Broadcast(message1);

            var message2 = new CommandMessage<DateTime>(this, now, OldTestCommandHost.SaveCommand);
            Messenger.Default.Broadcast(message2);

            Assert.AreEqual(TestString1, recipient.Content);
            Assert.AreEqual(TestString1, recipient2.Content);
            Assert.AreEqual(now, recipient.DateTimeContent);
            Assert.AreEqual(now, recipient2.DateTimeContent);

            Messenger.Default.Unregister(recipient);

            var message3 = new GenericMessage<string>(this, TestString2);
            Messenger.Default.Broadcast(message3);

            var message4 = new CommandMessage<DateTime>(this, later, OldTestCommandHost.SaveCommand);
            Messenger.Default.Broadcast(message4);

            Assert.AreEqual(TestString1, recipient.Content);
            Assert.AreEqual(TestString2, recipient2.Content);
            Assert.AreEqual(now, recipient.DateTimeContent);
            Assert.AreEqual(later, recipient2.DateTimeContent);
        }

        [TestMethod]
        public void TestUnregisterForOneType()
        {
            Messenger.Reset();

            const string TestString1 = "Hello world";
            const string TestString2 = "Another message";
            var now = DateTime.Now;
            var later = DateTime.Now + TimeSpan.FromDays(1);

            var recipient = new OldTestRecipient();
            Messenger.Default.Register(recipient, typeof(GenericMessage<string>), false);
            Messenger.Default.Register(recipient, typeof(CommandMessage<DateTime>), false);

            var recipient2 = new OldTestRecipient();
            Messenger.Default.Register(recipient2, typeof(GenericMessage<string>), false);
            Messenger.Default.Register(recipient2, typeof(CommandMessage<DateTime>), false);

            var message1 = new GenericMessage<string>(this, TestString1);
            Messenger.Default.Broadcast(message1);

            var message2 = new CommandMessage<DateTime>(this, now, OldTestCommandHost.SaveCommand);
            Messenger.Default.Broadcast(message2);

            Assert.AreEqual(TestString1, recipient.Content);
            Assert.AreEqual(TestString1, recipient2.Content);
            Assert.AreEqual(now, recipient.DateTimeContent);
            Assert.AreEqual(now, recipient2.DateTimeContent);

            Messenger.Default.Unregister(recipient, typeof(GenericMessage<string>));

            var message3 = new GenericMessage<string>(this, TestString2);
            Messenger.Default.Broadcast(message3);

            var message4 = new CommandMessage<DateTime>(this, later, OldTestCommandHost.SaveCommand);
            Messenger.Default.Broadcast(message4);

            Assert.AreEqual(TestString1, recipient.Content);
            Assert.AreEqual(TestString2, recipient2.Content);
            Assert.AreEqual(later, recipient.DateTimeContent);
            Assert.AreEqual(later, recipient2.DateTimeContent);
        }
    }
}