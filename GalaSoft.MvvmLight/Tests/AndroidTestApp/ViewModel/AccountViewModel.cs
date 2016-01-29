using System;

namespace GalaSoft.MvvmLight.Test.ViewModel
{
    public class AccountViewModel : ViewModelBase
    {
        public const string EmptyText = "Empty";
        public const string NotEmptyText = "Not empty ";

        private AccountModel _accountDetails;
        private decimal _amount;

        public AccountModel AccountDetails
        {
            get
            {
                return _accountDetails;
            }
            set
            {
                if (Set(() => AccountDetails, ref _accountDetails, value))
                {
                    RaisePropertyChanged(() => FormattedOperation);
                    RaisePropertyChanged(() => AccountDetailsName);
                }
            }
        }

        public string AccountDetailsName
        {
            get
            {
                return AccountDetails == null ? EmptyText : AccountDetails.Name;
            }
        }

        public decimal Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                if (Set(() => Amount, ref _amount, value))
                {
                    RaisePropertyChanged(() => FormattedOperation);
                }
            }
        }

        public string FormattedOperation
        {
            get
            {
                return AccountDetails == null
                    ? EmptyText
                    : NotEmptyText + AccountDetails.Balance + Amount;
            }
        }

        public void SetAccount()
        {
            if (AccountDetails == null)
            {
                AccountDetails = new AccountModel();
            }
            else
            {
                AccountDetails.Name += "A";
            }

            RaisePropertyChanged(() => AccountDetailsName);
        }

        public void SetAmount()
        {
            Amount += 10;
        }
    }
}