namespace GalaSoft.MvvmLight.Test.ViewModel
{
    public class AccountModel : ObservableObject
    {
        private string _name = "Account name";

        public decimal Balance
        {
            get
            {
                return 26;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                Set(ref _name, value);
            }
        }
    }
}