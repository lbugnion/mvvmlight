using System;
using GalaSoft.MvvmLight.Messaging;

namespace GalaSoft.MvvmLight.Test.ViewModel
{
    public class TestViewModelInlinePropertyChanged : ViewModelBase
    {
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
                RaisePropertyChanged();
            }
        }

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

                _lastChanged1 = value;

                // Update bindings and broadcast change using GalaSoft.Utility.Messenging
                RaisePropertyChanged();
            }
        }

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
                RaisePropertyChanged();
            }
        }

        public TestViewModelInlinePropertyChanged()
        {

        }

        public TestViewModelInlinePropertyChanged(IMessenger messenger)
            : base(messenger)
        {
        }

        public void RaisePropertyChangedInlineOutOfPropertySetter()
        {
            RaisePropertyChanged();
        }
    }
}