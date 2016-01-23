using System;
using System.Windows.Input;

namespace GalaSoft.MvvmLight.Test.ViewModel
{
    public class CommandImpl : ICommand
    {
        private readonly string _initialValue;

        public string Parameter
        {
            get;
            private set;
        }

        public CommandImpl(string initialValue)
        {
            _initialValue = initialValue;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Parameter = _initialValue;
        }

        public event EventHandler CanExecuteChanged;
    }
}