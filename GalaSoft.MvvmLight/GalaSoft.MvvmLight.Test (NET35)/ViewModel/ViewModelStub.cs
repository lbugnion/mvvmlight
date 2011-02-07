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

        public new void RaisePropertyChanged(string propertyName)
        {
            base.RaisePropertyChanged(propertyName);
        }
    }
}