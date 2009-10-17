using System;
using GalaSoft.MvvmLight.Messaging;

namespace GalaSoft.MvvmLight.Test.Messaging
{
    public class OldTestRecipient : IMessageRecipient
    {
        public string Content
        {
            get;
            private set;
        }

        public DateTime DateTimeContent
        {
            get;
            private set;
        }

        public MessageBase Message
        {
            get;
            private set;
        }

        public InvalidOperationException ObjectContent1
        {
            get;
            private set;
        }

        public MissingMethodException ObjectContent2
        {
            get;
            private set;
        }

        public object Sender
        {
            get;
            private set;
        }

        public void ReceiveMessage(MessageBase message)
        {
            Sender = message.Sender;

            if (message is OldTestMessage)
            {
                ReceiveTestMessage(message as OldTestMessage);
                return;
            }

            if (message is GenericMessage<InvalidOperationException>)
            {
                ReceiveGenericMessage(message as GenericMessage<InvalidOperationException>);
                return;
            }

            if (message is GenericMessage<MissingMethodException>)
            {
                ReceiveGenericMessage(message as GenericMessage<MissingMethodException>);
                return;
            }

            if (message is PropertyChangedMessage<DateTime>)
            {
                ReceivePropertyChangedMessage(message as PropertyChangedMessage<DateTime>);
                return;
            }

            if (message is CommandMessage<DateTime>)
            {
                ReceiveCommandMessage(message as CommandMessage<DateTime>);
                return;
            }

            if (message is GenericMessage<string>)
            {
                ReceiveGenericStringMessage(message as GenericMessage<string>);
                return;
            }

            ReceiveMessageBase(message);
        }

        private void ReceiveCommandMessage(CommandMessage<DateTime> message)
        {
            if (message.Command
                == OldTestCommandHost.SaveCommand)
            {
                DateTimeContent = message.Content;
            }
        }

        private void ReceiveGenericMessage(GenericMessage<InvalidOperationException> message)
        {
            ObjectContent1 = message.Content;
        }

        private void ReceiveGenericMessage(GenericMessage<MissingMethodException> message)
        {
            ObjectContent2 = message.Content;
        }

        private void ReceiveGenericStringMessage(GenericMessage<string> genericMessage)
        {
            Content = genericMessage.Content;
        }

        private void ReceiveMessageBase(MessageBase message)
        {
            Message = message;
        }

        private void ReceivePropertyChangedMessage(PropertyChangedMessage<DateTime> message)
        {
            if (message.PropertyName
                == OldTestViewModel.LastChanged2PropertyName)
            {
                DateTimeContent = message.Content;
            }
        }

        private void ReceiveTestMessage(OldTestMessage message)
        {
            Content = message.Content;
        }
    }
}