// ****************************************************************************
// <copyright file="MainViewModel.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>15.10.2009</date>
// <project>CleanShutdown</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System.Windows.Media;
using CleanShutdown.Helpers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace CleanShutdown.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The <see cref="BackgroundBrush" /> property's name.
        /// </summary>
        public const string BackgroundBrushPropertyName = "BackgroundBrush";

        private Brush _background;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                BackgroundBrush = new SolidColorBrush(Colors.Orange);
            }
            else
            {
                Messenger.Default.Register<Brush>(this, true, m => BackgroundBrush = m);

                ShutdownCommand = new RelayCommand(ShutdownService.RequestShutdown);
            }
        }

        /// <summary>
        /// Gets the BackgroundBrush property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public Brush BackgroundBrush
        {
            get
            {
                return _background;
            }

            private set
            {
                if (_background == value)
                {
                    return;
                }

                _background = value;
                RaisePropertyChanged(BackgroundBrushPropertyName);
            }
        }

        public RelayCommand ShutdownCommand
        {
            get;
            private set;
        }
    }
}