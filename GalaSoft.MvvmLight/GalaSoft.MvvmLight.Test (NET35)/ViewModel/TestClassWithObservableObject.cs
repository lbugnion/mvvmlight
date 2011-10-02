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

        public const string PropertyWithSetPropertyName = "PropertyWithSet";
        private int _propertyWithSet;
        public int PropertyWithSet
        {
            get
            {
                return _propertyWithSet;
            }
            set
            {
                Set(() => PropertyWithSet, ref _propertyWithSet, value);
            }
        }

        public const string PropertyWithStringSetPropertyName = "PropertyWithStringSet";
        private int _propertyWithStringSet;
        public int PropertyWithStringSet
        {
            get
            {
                return _propertyWithStringSet;
            }
            set
            {
                Set(PropertyWithStringSetPropertyName, ref _propertyWithStringSet, value);
            }
        }

        public void RaisePropertyChangedPublic(string propertyName)
        {
            RaisePropertyChanged(propertyName);
        }
    }
}
