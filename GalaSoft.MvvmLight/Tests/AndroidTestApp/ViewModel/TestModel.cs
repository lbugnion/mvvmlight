namespace GalaSoft.MvvmLight.Test.ViewModel
{
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