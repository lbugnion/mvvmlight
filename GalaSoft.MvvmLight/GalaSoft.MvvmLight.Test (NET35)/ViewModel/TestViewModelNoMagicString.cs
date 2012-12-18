using System;
using System.Linq.Expressions;
using GalaSoft.MvvmLight.Messaging;

namespace GalaSoft.MvvmLight.Test.ViewModel
{
    public class TestViewModelNoMagicString : ViewModelBase
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
                RaisePropertyChanged(() => ReceivedContent);
            }
        }

        private DateTime _lastChanged1 = DateTime.MaxValue;

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

#if !WP71
                RaisePropertyChanging(() => LastChanged1);
#endif

                var oldValue = _lastChanged1;
                _lastChanged1 = value;

                // Update bindings and broadcast change using GalaSoft.Utility.Messenging
                RaisePropertyChanged(() => LastChanged1, oldValue, value, true);
            }
        }

        private DateTime _lastChanged2 = DateTime.MaxValue;

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

#if !WP71
                RaisePropertyChanging(() => LastChanged2);
#endif

                _lastChanged2 = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(() => LastChanged2);
            }
        }

        public TestViewModelNoMagicString()
        {

        }

        public TestViewModelNoMagicString(IMessenger messenger)
            : base(messenger)
        {
        }

        public void RaisePropertyChangedPublic<T>(Expression<Func<T>> propertyExpression)
        {
            RaisePropertyChanged(propertyExpression);
        }

        public void RaisePropertyChangedPublic<T>(Expression<Func<T>> propertyExpression, T oldValue, T newValue, bool broadcast)
        {
            RaisePropertyChanged(propertyExpression, oldValue, newValue, broadcast);
        }

#if !WP71
        public void RaisePropertyChangingPublic<T>(Expression<Func<T>> propertyExpression)
        {
            RaisePropertyChanging(propertyExpression);
        }
#endif
    }
}