using System;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GalaSoft.MvvmLight.Test.Messaging
{
    [TestClass]
    public class DialogMessageTest
    {
        public void ExecuteTest(object sender, object target)
        {
            Messenger.Reset();

            const string Text = "MessageBox Text";
            const string Caption = "MessageBox Caption";
            const MessageBoxButton Button = MessageBoxButton.OKCancel;
            const MessageBoxResult DefaultResult = MessageBoxResult.No;

#if !SILVERLIGHT
            const MessageBoxOptions Options = MessageBoxOptions.RightAlign;
            const MessageBoxImage Icon = MessageBoxImage.Asterisk;
#endif

            const MessageBoxResult ResultOK = MessageBoxResult.OK;
            const MessageBoxResult ResultCancel = MessageBoxResult.Cancel;

            var receivedMessage = false;
            var receivedCallback = false;
            object receivedSender = null;
            object receivedTarget = null;

            Messenger.Default.Register<DialogMessage>(this,
                                                      m =>
                                                      {
                                                          receivedMessage = true;
                                                          receivedSender = m.Sender;
                                                          receivedTarget = m.Target;

                                                          if (m.Callback != null
                                                              && m.Button == Button
                                                              && m.Caption == Caption
                                                              && m.Content == Text
#if !SILVERLIGHT
                                                              && m.Icon == Icon
                                                              && m.Options == Options
#endif
                                                              && m.DefaultResult == DefaultResult)
                                                          {
                                                              m.ProcessCallback(ResultOK);
                                                          }
                                                          else
                                                          {
                                                              m.ProcessCallback(ResultCancel);
                                                          }
                                                      });

            var result = MessageBoxResult.None;
            DialogMessage dialogMessage;
            Action<MessageBoxResult> callback = r =>
            {
                receivedCallback = true;
                result = r;
            };

            if (sender == null)
            {
                dialogMessage = new DialogMessage(Text, callback);
            }
            else
            {
                if (target == null)
                {
                    dialogMessage = new DialogMessage(sender, Text, callback);
                }
                else
                {
                    dialogMessage = new DialogMessage(sender, target, Text, callback);
                }
            }

            dialogMessage.Button = Button;
            dialogMessage.Caption = Caption;
            dialogMessage.DefaultResult = DefaultResult;
#if !SILVERLIGHT
            dialogMessage.Icon = Icon;
            dialogMessage.Options = Options;
#endif

            Messenger.Default.Send(dialogMessage);

            Assert.AreEqual(sender, receivedSender);
            Assert.AreEqual(target, receivedTarget);
            Assert.IsTrue(receivedMessage);
            Assert.IsTrue(receivedCallback);
            Assert.AreEqual(ResultOK, result);
        }

        [TestMethod]
        public void TestDialogMessage()
        {
            ExecuteTest(null, null);
        }

        [TestMethod]
        public void TestDialogMessageWithSender()
        {
            ExecuteTest(this, null);
        }

        [TestMethod]
        public void TestDialogMessageWithTarget()
        {
            ExecuteTest(this, this);
        }
    }
}