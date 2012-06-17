using System;

namespace GalaSoft.MvvmLight.Test.ViewModel
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

                RaisePropertyChanging(LastChangedPropertyName);
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

                RaisePropertyChanging(() => LastChangedNoMagicString);
                _lastChangedNoMagicString = value;
                RaisePropertyChanged(() => LastChangedNoMagicString);
            }
        }

        public bool SetRaisedPropertyChangedEvent
        {
            get;
            set;
        }

        public const string PropertyWithSetPropertyName = "PropertyWithSet";
        private int _propertyWithSet = -1;
        public int PropertyWithSet
        {
            get
            {
                return _propertyWithSet;
            }
            set
            {
                SetRaisedPropertyChangedEvent = false;
                SetRaisedPropertyChangedEvent = Set(() => PropertyWithSet, ref _propertyWithSet, value);
            }
        }

        public const string PropertyWithStringSetPropertyName = "PropertyWithStringSet";
        private int _propertyWithStringSet = -1;
        public int PropertyWithStringSet
        {
            get
            {
                return _propertyWithStringSet;
            }
            set
            {
                SetRaisedPropertyChangedEvent = false;
                SetRaisedPropertyChangedEvent = Set(PropertyWithStringSetPropertyName, ref _propertyWithStringSet, value);
            }
        }

        public void RaisePropertyChangedPublic(string propertyName)
        {
            RaisePropertyChanged(propertyName);
        }

        public void RaisePropertyChangingPublic(string propertyName)
        {
            RaisePropertyChanging(propertyName);
        }
    }
}
