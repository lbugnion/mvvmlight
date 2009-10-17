using System;
using GalaSoft.MvvmLight.Messaging;

namespace GalaSoft.MvvmLight.Test.Messaging
{
    public class OldTestViewModel : ViewModelBase, IMessageRecipient
    {
        public const string LastChanged1PropertyName = "LastChanged1";

        public const string LastChanged2PropertyName = "LastChanged2";

        private DateTime _lastChanged1;

        private DateTime _lastChanged2;

        public OldTestViewModel()
        {
        }

        public OldTestViewModel(Messenger messenger)
            : base(messenger)
        {
        }

        public DateTime LastChanged1
        {
            get
            {
                return _lastChanged1;
            }
            set
            {
                if (_lastChanged1 == value)
                {
                    return;
                }

                _lastChanged1 = value;
                RaisePropertyChanged(LastChanged1PropertyName);
            }
        }

        public DateTime LastChanged2
        {
            get
            {
                return _lastChanged2;
            }
            set
            {
                if (_lastChanged2 == value)
                {
                    return;
                }
                _lastChanged2 = value;
                RaisePropertyChanged(LastChanged2PropertyName, value, true);
            }
        }

        public string ReceivedContent
        {
            get;
            private set;
        }

        public void ReceiveMessage(MessageBase message)
        {
            var casted = message as OldTestMessage;

            if (casted != null)
            {
                ReceivedContent = casted.Content;
            }
        }
    }
}