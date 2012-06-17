namespace GalaSoft.MvvmLight.Test.ViewModel
{
    public class ViewModelStub : ViewModelBase
    {
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

        public const string PropertyWithSetBroadcastPropertyName = "PropertyWithSetBroadcast";
        private int _propertyWithSetBroadcast;
        public int PropertyWithSetBroadcast
        {
            get
            {
                return _propertyWithSetBroadcast;
            }
            set
            {
                Set(() => PropertyWithSetBroadcast, ref _propertyWithSetBroadcast, value, true);
            }
        }

        public const string PropertyWithStringSetBroadcastPropertyName = "PropertyWithStringSetBroadcast";
        private int _propertyWithStringSetBroadcast;
        public int PropertyWithStringSetBroadcast
        {
            get
            {
                return _propertyWithStringSetBroadcast;
            }
            set
            {
                Set(PropertyWithStringSetBroadcastPropertyName, ref _propertyWithStringSetBroadcast, value, true);
            }
        }

        public const string PropertyWithSetNoBroadcastPropertyName = "PropertyWithSetNoBroadcast";
        private int _propertyWithSetNoBroadcast;
        public int PropertyWithSetNoBroadcast
        {
            get
            {
                return _propertyWithSetNoBroadcast;
            }
            set
            {
                Set(() => PropertyWithSetNoBroadcast, ref _propertyWithSetNoBroadcast, value, false);
            }
        }

        public const string PropertyWithStringSetNoBroadcastPropertyName = "PropertyWithStringSetNoBroadcast";
        private int _propertyWithStringSetNoBroadcast;
        public int PropertyWithStringSetNoBroadcast
        {
            get
            {
                return _propertyWithStringSetNoBroadcast;
            }
            set
            {
                Set(PropertyWithStringSetNoBroadcastPropertyName, ref _propertyWithStringSetNoBroadcast, value, false);
            }
        }

        public new void RaisePropertyChanged(string propertyName)
        {
            base.RaisePropertyChanged(propertyName);
        }
    }
}