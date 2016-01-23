using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace GalaSoft.MvvmLight.Test.ViewModel
{
    public class TestViewModel : ViewModelBase
    {
        public const string ValueForCommand = "Command value";
        private TestModel _model;
        private TestViewModel _nested;
        private string _propertyValue;
        private RelayCommand<string> _setPropertyCommand;
        private RelayCommand _setPropertyWithoutValueCommand;
        private ICommand _testCommandImpl;

        public TestModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                Set(ref _model, value);
            }
        }

        public TestViewModel Nested
        {
            get
            {
                return _nested;
            }
            set
            {
                Set(ref _nested, value);
            }
        }

        public RelayCommand<string> SetPropertyCommand
        {
            get
            {
                return _setPropertyCommand
                       ?? (_setPropertyCommand = new RelayCommand<string>(
                           p =>
                           {
                               TargetProperty = p;
                           }));
            }
        }

        public RelayCommand SetPropertyWithoutValueCommand
        {
            get
            {
                return _setPropertyWithoutValueCommand
                       ?? (_setPropertyWithoutValueCommand = new RelayCommand(
                           () =>
                           {
                               TargetProperty = _propertyValue;
                           }));
            }
        }

        public string TargetProperty
        {
            get;
            set;
        }

        public ICommand TestCommandImpl
        {
            get
            {
                return _testCommandImpl
                       ?? (_testCommandImpl = new CommandImpl(ValueForCommand));
            }
        }

        public void Configure(string propertyValue)
        {
            _propertyValue = propertyValue;
        }
    }
}