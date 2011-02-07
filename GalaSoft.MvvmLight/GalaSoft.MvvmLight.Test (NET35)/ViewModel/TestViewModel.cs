using System;
using GalaSoft.MvvmLight.Messaging;

namespace GalaSoft.MvvmLight.Test.ViewModel
{
    public class TestViewModel : ViewModelBase
    {
        public bool CleanupWasCalled
        {
            get;
            private set;
        }

        public const string ReceivedContentPropertyName = "ReceivedContent";

        private string _receivedContent;

        public string ReceivedContent
        {
            get
            {
                return _receivedContent;
            }

            private set
            {
                if (_receivedContent == value)
                {
                    return;
                }

                _receivedContent = value;
                RaisePropertyChanged(ReceivedContentPropertyName);
            }
        }

        public const string LastChanged1PropertyName = "LastChanged1";

        private DateTime _lastChanged1;

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

                var oldValue = _lastChanged1;
                _lastChanged1 = value;

                // Update bindings and broadcast change using GalaSoft.Utility.Messenging
                RaisePropertyChanged(LastChanged1PropertyName, oldValue, value, true);
            }
        }

        /// <summary>
        /// The <see cref="LastChanged2" /> property's name.
        /// </summary>
        public const string LastChanged2PropertyName = "LastChanged2";

        private DateTime _lastChanged2;

        /// <summary>
        /// Gets the LastChanged2 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
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

                // Update bindings, no broadcast
                RaisePropertyChanged(LastChanged2PropertyName);
            }
        }

        internal void HandleStringMessage(string message)
        {
            ReceivedContent = message;
        }

        public TestViewModel()
        {
            
        }

        public TestViewModel(IMessenger messenger)
            : base(messenger)
        {
        }

        public override void Cleanup()
        {
            CleanupWasCalled = true;
            base.Cleanup();
        }
    }
}