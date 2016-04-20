namespace GalaSoft.MvvmLight.Test.ViewModel
{
    /// <summary>
    /// Test class used for Unit test purposes.
    /// </summary>
    public class TestModel : ObservableObject
    {
        private string _myProperty;

        public string MyProperty
        {
            get
            {
                return _myProperty;
            }
            set
            {
                Set(ref _myProperty, value);
            }
        }
    }
}