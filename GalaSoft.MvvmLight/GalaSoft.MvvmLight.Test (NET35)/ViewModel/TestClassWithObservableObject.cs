using System;

namespace GalaSoft.MvvmLight.Test.Stubs
{
    public class TestClassWithObservableObject : ObservableObject
    {
        /// <summary>
        /// The <see cref="LastChanged" /> property's name.
        /// </summary>
        public const string LastChangedPropertyName = "LastChanged";

        private DateTime _lastChanged = DateTime.MinValue;

        /// <summary>
        /// Gets the LastChanged property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime LastChanged
        {
            get
            {
                return _lastChanged;
            }

            set
            {
                if (_lastChanged == value)
                {
                    return;
                }

                _lastChanged = value;
                RaisePropertyChanged(LastChangedPropertyName);
            }
        }

        private DateTime _lastChangedNoMagicString = DateTime.MinValue;

        /// <summary>
        /// Gets the LastChangedNoMagicString property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime LastChangedNoMagicString
        {
            get
            {
                return _lastChangedNoMagicString;
            }

            set
            {
                if (_lastChangedNoMagicString == value)
                {
                    return;
                }

                _lastChangedNoMagicString = value;
                RaisePropertyChanged(() => LastChangedNoMagicString);
            }
        }

        private DateTime _lastChangedInline = DateTime.MinValue;

        /// <summary>
        /// Gets the LastChangedInline property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime LastChangedInline
        {
            get
            {
                return _lastChangedInline;
            }

            set
            {
                if (_lastChangedInline == value)
                {
                    return;
                }

                _lastChangedInline = value;
                RaisePropertyChanged();
            }
        }

        public void RaisePropertyChangedInlineOutOfPropertySetter()
        {
            RaisePropertyChanged();
        }

        public void RaisePropertyChangedPublic(string propertyName)
        {
            RaisePropertyChanged(propertyName);
        }
    }
}
