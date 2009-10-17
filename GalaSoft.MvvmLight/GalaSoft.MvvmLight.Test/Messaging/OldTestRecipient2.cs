using System;
using GalaSoft.MvvmLight.Messaging;

namespace GalaSoft.MvvmLight.Test.Messaging
{
    public class OldTestRecipient2 : IMessageRecipient
    {
        public string Content
        {
            get;
            private set;
        }

        public MessageBase Message
        {
            get;
            private set;
        }

        public int ReceivedMessagesCount
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
            Message = message;

            var castedMessage = message as GenericMessage<string>;
            if (castedMessage != null)
            {
                Content = castedMessage.Content;
            }

            var propertyMessage = message as PropertyChangedMessage<DateTime>;
            if (propertyMessage != null
                && propertyMessage.PropertyName == OldTestViewModel.LastChanged2PropertyName)
            {
                ReceivedMessagesCount++;
            }
        }
    }
}