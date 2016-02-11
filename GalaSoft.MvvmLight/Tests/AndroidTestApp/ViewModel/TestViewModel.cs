using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace GalaSoft.MvvmLight.Test.ViewModel
{
    public class TestViewModel : ViewModelBase
    {
        public const string ValueForCommand = "Command value";

        private DateTime _date;
        private TestModel _model;
        private TestViewModel _nested;
        private string _propertyValue;
        private RelayCommand<string> _setPropertyCommand;
        private RelayCommand _setPropertyWithoutValueCommand;

        private string _targetPropertyObservable;
        private ICommand _testCommandImpl;

        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                Set(ref _date, value);
            }
        }

        public ObservableCollection<TestItem> ItemsCollection
        {
            get;
            set;
        }

        public List<TestItem> ItemsList
        {
            get;
            set;
        }

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

        public string TargetPropertyObservable
        {
            get
            {
                return _targetPropertyObservable;
            }
            set
            {
                Set(ref _targetPropertyObservable, value);
            }
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