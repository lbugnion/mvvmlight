namespace GalaSoft.MvvmLight.Test.ViewModel
{
    public class ViewModelStub : ViewModelBase
    {
        public bool SetRaisedPropertyChangedEvent
        {
            get;
            set;
        }

        /// <summary>
        /// The <see cref="RealProperty" /> property's name.
        /// </summary>
        public const string RealPropertyPropertyName = "RealProperty";

        private bool _realProperty;

        /// <summary>
        /// Gets the RealProperty property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool RealProperty
        {
            get
            {
                return _realProperty;
            }

            set
            {
                if (_realProperty.Equals(value))
                {
                    return;
                }

                _realProperty = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(RealPropertyPropertyName);
            }
        }

#if !SL3
        public const string PropertyWithSetBroadcastPropertyName = "PropertyWithSetBroadcast";
        private int _propertyWithSetBroadcast = -1;
        public int PropertyWithSetBroadcast
        {
            get
            {
                return _propertyWithSetBroadcast;
            }
            set
            {
                SetRaisedPropertyChangedEvent = false;
                SetRaisedPropertyChangedEvent = Set(() => PropertyWithSetBroadcast, ref _propertyWithSetBroadcast, value, true);
            }
        }

        public const string PropertyWithStringSetBroadcastPropertyName = "PropertyWithStringSetBroadcast";
        private int _propertyWithStringSetBroadcast = -1;
        public int PropertyWithStringSetBroadcast
        {
            get
            {
                return _propertyWithStringSetBroadcast;
            }
            set
            {
                SetRaisedPropertyChangedEvent = false;
                SetRaisedPropertyChangedEvent = Set(PropertyWithStringSetBroadcastPropertyName, ref _propertyWithStringSetBroadcast, value, true);
            }
        }

        public const string PropertyWithSetNoBroadcastPropertyName = "PropertyWithSetNoBroadcast";
        private int _propertyWithSetNoBroadcast = -1;
        public int PropertyWithSetNoBroadcast
        {
            get
            {
                return _propertyWithSetNoBroadcast;
            }
            set
            {
                SetRaisedPropertyChangedEvent = false;
                SetRaisedPropertyChangedEvent = Set(() => PropertyWithSetNoBroadcast, ref _propertyWithSetNoBroadcast, value, false);
            }
        }

        public const string PropertyWithStringSetNoBroadcastPropertyName = "PropertyWithStringSetNoBroadcast";
        private int _propertyWithStringSetNoBroadcast = -1;
        public int PropertyWithStringSetNoBroadcast
        {
            get
            {
                return _propertyWithStringSetNoBroadcast;
            }
            set
            {
                SetRaisedPropertyChangedEvent = false;
                SetRaisedPropertyChangedEvent = Set(PropertyWithStringSetNoBroadcastPropertyName, ref _propertyWithStringSetNoBroadcast, value, false);
            }
        }
#endif

#if !WP71
        public new void RaisePropertyChanging(string propertyName)
        {
            base.RaisePropertyChanging(propertyName);
        }
#endif

        public new void RaisePropertyChanged(string propertyName)
        {
            base.RaisePropertyChanged(propertyName);
        }
    }
}