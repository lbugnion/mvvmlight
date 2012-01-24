namespace GalaSoft.MvvmLight.Test.Stubs
{
    public class TestViewModelWithBooleanSource : ViewModelBase
    {
        /// <summary>
        /// The <see cref="MyBoolean" /> property's name.
        /// </summary>
        public const string MyBooleanPropertyName = "MyBoolean";

        private bool _myBoolean = false;

        /// <summary>
        /// Gets the MyBoolean property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool MyBoolean
        {
            get
            {
                return _myBoolean;
            }

            set
            {
                if (_myBoolean == value)
                {
                    return;
                }

                _myBoolean = value;
                RaisePropertyChanged(MyBooleanPropertyName);
            }
        }
    }
}