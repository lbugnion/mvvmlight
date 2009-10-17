using System;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GalaSoft.MvvmLight.Test.Messaging
{
    [TestClass]
    public class CommandMessageTest
    {
        private static readonly string DummyCommand1 = Guid.NewGuid().ToString();

        private static readonly string DummyCommand2 = Guid.NewGuid().ToString();

        public void ExecuteTestGeneric(object sender, object target)
        {
            var testContent1 = new InvalidOperationException();
            var testContent2 = new InvalidCastException();

            Exception receivedContent1 = null;
            Exception receivedContent2 = null;

            object receivedSender = null;
            object receivedTarget = null;

            Messenger.Reset();

            Messenger.Default.Register<CommandMessage<Exception>>(this,
                                                                  m =>
                                                                  {
                                                                      receivedSender = m.Sender;
                                                                      receivedTarget = m.Target;

                                                                      if (m.Command == DummyCommand1)
                                                                      {
                                                                          receivedContent1 = testContent1;
                                                                          return;
                                                                      }

                                                                      if (m.Command == DummyCommand2)
                                                                      {
                                                                          receivedContent2 = testContent2;
                                                                          return;
                                                                      }
                                                                  });

            Assert.AreEqual(null, receivedContent1);
            Assert.AreEqual(null, receivedContent2);

            CommandMessage<Exception> commandMessage1;
            CommandMessage<Exception> commandMessage2;

            if (sender == null)
            {
                commandMessage1 = new CommandMessage<Exception>(testContent1, DummyCommand1);
                commandMessage2 = new CommandMessage<Exception>(testContent2, DummyCommand2);
            }
            else
            {
                if (target == null)
                {
                    commandMessage1 = new CommandMessage<Exception>(sender, testContent1, DummyCommand1);
                    commandMessage2 = new CommandMessage<Exception>(sender, testContent2, DummyCommand2);
                }
                else
                {
                    commandMessage1 = new CommandMessage<Exception>(sender, target, testContent1, DummyCommand1);
                    commandMessage2 = new CommandMessage<Exception>(sender, target, testContent2, DummyCommand2);
                }
            }

            Messenger.Default.Send(commandMessage1);

            Assert.AreEqual(sender, receivedSender);
            Assert.AreEqual(target, receivedTarget);
            Assert.AreEqual(testContent1, receivedContent1);
            Assert.AreEqual(null, receivedContent2);

            receivedSender = null;
            receivedTarget = null;

            Messenger.Default.Send(commandMessage2);

            Assert.AreEqual(sender, receivedSender);
            Assert.AreEqual(target, receivedTarget);
            Assert.AreEqual(testContent1, receivedContent1);
            Assert.AreEqual(testContent2, receivedContent2);
        }

        [TestMethod]
        public void TestCommandGenericMessage()
        {
            ExecuteTestGeneric(null, null);
        }

        [TestMethod]
        public void TestCommandGenericMessageWithSender()
        {
            ExecuteTestGeneric(this, null);
        }

        [TestMethod]
        public void TestCommandGenericMessageWithTarget()
        {
            ExecuteTestGeneric(this, this);
        }

        [TestMethod]
        public void TestCommandMessage()
        {
            ExecuteTest(null, null);
        }

        [TestMethod]
        public void TestCommandMessageWithSender()
        {
            ExecuteTest(this, null);
        }

        [TestMethod]
        public void TestCommandMessageWithSenderAndTarget()
        {
            ExecuteTest(this, this);
        }

        private void ExecuteTest(object sender, object target)
        {
            const string TestContent1 = "abcd";
            const string TestContent2 = "efgh";

            string receivedContent1 = null;
            string receivedContent2 = null;

            object receivedSender = null;
            object receivedTarget = null;

            Messenger.Reset();

            Messenger.Default.Register<CommandMessage>(this,
                                                       m =>
                                                       {
                                                           receivedSender = m.Sender;
                                                           receivedTarget = m.Target;

                                                           if (m.Command == DummyCommand1)
                                                           {
                                                               receivedContent1 = TestContent1;
                                                               return;
                                                           }

                                                           if (m.Command == DummyCommand2)
                                                           {
                                                               receivedContent2 = TestContent2;
                                                               return;
                                                           }
                                                       });

            Assert.AreEqual(null, receivedContent1);
            Assert.AreEqual(null, receivedContent2);

            CommandMessage commandMessage1;
            CommandMessage commandMessage2;

            if (sender == null)
            {
                commandMessage1 = new CommandMessage(DummyCommand1);
                commandMessage2 = new CommandMessage(DummyCommand2);
            }
            else
            {
                if (target == null)
                {
                    commandMessage1 = new CommandMessage(sender, DummyCommand1);
                    commandMessage2 = new CommandMessage(sender, DummyCommand2);
                }
                else
                {
                    commandMessage1 = new CommandMessage(sender, target, DummyCommand1);
                    commandMessage2 = new CommandMessage(sender, target, DummyCommand2);
                }
            }

            Messenger.Default.Send(commandMessage1);

            Assert.AreEqual(sender, receivedSender);
            Assert.AreEqual(target, receivedTarget);
            Assert.AreEqual(TestContent1, receivedContent1);
            Assert.AreEqual(null, receivedContent2);

            receivedTarget = null;
            receivedSender = null;

            Messenger.Default.Send(commandMessage2);

            Assert.AreEqual(sender, receivedSender);
            Assert.AreEqual(target, receivedTarget);
            Assert.AreEqual(TestContent1, receivedContent1);
            Assert.AreEqual(TestContent2, receivedContent2);
        }
    }
}