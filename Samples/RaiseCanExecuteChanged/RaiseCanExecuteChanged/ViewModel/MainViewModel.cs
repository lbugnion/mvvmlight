// ****************************************************************************
// <copyright file="MainViewModel.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>26.9.2009</date>
// <project>GalaSoft.Samples.RaiseCanExecuteChanged</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_ISC.txt
// </license>
// ****************************************************************************

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace GalaSoft.Samples.RaiseCanExecuteChanged.ViewModel
{
    /// <summary>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The <see cref="CanIncrement" /> property's name.
        /// </summary>
        public const string CanIncrementPropertyName = "CanIncrement";

        /// <summary>
        /// The <see cref="Counter" /> property's name.
        /// </summary>
        public const string CounterPropertyName = "Counter";

        private bool _canIncrement = true;

        private int _counter;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            IncreaseCounterCommand = new RelayCommand(
                () => Counter++,
                () => CanIncrement);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the counter can be
        /// incremented or not.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool CanIncrement
        {
            get
            {
                return _canIncrement;
            }

            set
            {
                if (_canIncrement == value)
                {
                    return;
                }

                _canIncrement = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(CanIncrementPropertyName);

                IncreaseCounterCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Gets the Counter property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Counter
        {
            get
            {
                return _counter;
            }

            private set
            {
                if (_counter == value)
                {
                    return;
                }

                _counter = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(CounterPropertyName);
            }
        }

        /// <summary>
        /// Gets the command used to increase the Counter property.
        /// </summary>
        public RelayCommand IncreaseCounterCommand
        {
            get;
            private set;
        }
    }
}