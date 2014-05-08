using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace GalaSoft.MvvmLight.Test.Command
{
    public class TestViewModel : ViewModelBase
    {
        public bool CommandExecuted
        {
            get;
            set;
        }

        public string ParameterReceived
        {
            get;
            private set;
        }

        public ICommand SimpleCommand
        {
            get;
            private set;
        }

        public ICommand ParameterCommand
        {
            get;
            private set;
        }

        public ICommand ToggledCommand
        {
            get;
            private set;
        }

        public ICommand ToggledCommandWithParameter
        {
            get;
            private set;
        }

        public readonly RelayCommand<EventArgs> CommandWithEventArgs;

        public readonly RelayCommand<string> CommandWithEventArgsConverted;

        private bool _enableToggledCommand;
        public bool EnableToggledCommand
        {
            private get
            {
                return _enableToggledCommand;
            }
            set
            {
                _enableToggledCommand = value;
                ((RelayCommand)ToggledCommand).RaiseCanExecuteChanged();
            }
        }

        public TestViewModel()
        {
            SimpleCommand = new RelayCommand(() => CommandExecuted = true);

            ParameterCommand = new RelayCommand<string>(p =>
            {
                CommandExecuted = true;
                ParameterReceived = p;
            });

            ToggledCommand = new RelayCommand(
                () => CommandExecuted = true,
                () => EnableToggledCommand);

            ToggledCommandWithParameter = new RelayCommand<string>(
                p =>
                {
                    CommandExecuted = true;
                    ParameterReceived = p;
                },
                p => (p != null && p.StartsWith("Hello")));

            CommandWithEventArgs = new RelayCommand<EventArgs>(e =>
            {
                CommandExecuted = true;
                ParameterReceived = ((StringEventArgs)e).Parameter;
            });

            CommandWithEventArgsConverted = new RelayCommand<string>(e =>
            {
                CommandExecuted = true;
                ParameterReceived = e;
            });
        }
    }
}