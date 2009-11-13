using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Media;
using System;
using System.Windows.Input;
using System.Windows;

namespace EventToCommand.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public Brushes Brushes
        {
            get;
            private set;
        }

        /// <summary>
        /// The <see cref="LastUsedBrush" /> property's name.
        /// </summary>
        public const string LastUsedBrushPropertyName = "LastUsedBrush";

        private Brush _lastUsedBrush;

        /// <summary>
        /// Gets the LastUsedBrush property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Brush LastUsedBrush
        {
            get
            {
                return _lastUsedBrush;
            }

            private set
            {
                if (_lastUsedBrush == value)
                {
                    return;
                }

                _lastUsedBrush = value;
                // Update bindings, no broadcast
                RaisePropertyChanged(LastUsedBrushPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Status" /> property's name.
        /// </summary>
        public const string StatusPropertyName = "Status";

        private string _status = "Initialized...";

        /// <summary>
        /// Gets the Status property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Status
        {
            get
            {
                return _status;
            }

            private set
            {
                if (_status == value)
                {
                    return;
                }

                _status = value;
                // Update bindings, no broadcast
                RaisePropertyChanged(StatusPropertyName);
            }
        }

        public RelayCommand ResetCommand
        {
            get;
            private set;
        }
        
        public RelayCommand SimpleCommand
        {
            get;
            private set;
        }

        public RelayCommand<string> ParameterCommand1
        {
            get;
            private set;
        }

        public RelayCommand<string> ParameterCommand2
        {
            get;
            private set;
        }

        public RelayCommand<string> DisablableCommand
        {
            get;
            private set;
        }

        public RelayCommand<MouseEventArgs> MoveMouseCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Brushes = new Brushes();
            LastUsedBrush = Brushes.None;

            ResetCommand = new RelayCommand(() =>
            {
                Status = "Activate a Command";
                LastUsedBrush = Brushes.None;
            });

            SimpleCommand = new RelayCommand(() =>
            {
                Status = "Simple command executed";
                LastUsedBrush = Brushes.Brush1;
            });

            ParameterCommand1 = new RelayCommand<string>(p =>
            {
                Status = string.Format("Parameter command executed ({0})", p);
                LastUsedBrush = Brushes.Brush2;
            });

            ParameterCommand2 = new RelayCommand<string>(p =>
            {
                Status = string.Format("Parameter command executed ({0})", p);
                LastUsedBrush = Brushes.Brush3;
            });

            DisablableCommand = new RelayCommand<string>(p =>
            {
                Status = string.Format("Disablable command executed ({0})", p);
                LastUsedBrush = Brushes.Brush4;
            },
            p => p != "Hello");

            MoveMouseCommand = new RelayCommand<MouseEventArgs>(e =>
            {
                var element = e.OriginalSource as UIElement;
                var point = e.GetPosition(element);

                Status = string.Format("Position: {0}x{1}", point.X, point.Y);
                LastUsedBrush = Brushes.Brush5;
            });
        }
    }
}