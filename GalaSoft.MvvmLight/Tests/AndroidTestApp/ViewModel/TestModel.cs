namespace GalaSoft.MvvmLight.Test.ViewModel
{
    /// <summary>
    /// Test class used for Unit test purposes.
    /// </summary>
    public class TestModel : ObservableObject
    {
        private string _stringProperty;

        public string StringProperty
        {
            get
            {
                return _stringProperty;
            }
            set
            {
                Set(ref _stringProperty, value);
            }
        }

        private double _doubleProperty = 0.0;

        public double DoubleProperty
        {
            get
            {
                return _doubleProperty;
            }
            set
            {
                Set(ref _doubleProperty, value);
            }
        }
    }
}