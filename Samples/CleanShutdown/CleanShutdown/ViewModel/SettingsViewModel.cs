// ****************************************************************************
// <copyright file="SettingsViewModel.cs" company="GalaSoft Laurent Bugnion">
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
using CleanShutdown.Messaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace CleanShutdown.ViewModel
{
    public class SettingsViewModel : ViewModelBase
    {
        /// <summary>
        /// The <see cref="Blue" /> property's name.
        /// </summary>
        public const string BluePropertyName = "Blue";

        /// <summary>
        /// The <see cref="Green" /> property's name.
        /// </summary>
        public const string GreenPropertyName = "Green";

        /// <summary>
        /// The <see cref="Red" /> property's name.
        /// </summary>
        public const string RedPropertyName = "Red";

        private readonly bool _isLoading;

        private readonly SettingsFileHandler _settingsFile;

        private byte _blue;

        private byte _green;

        private byte _red;

        public SettingsViewModel()
        {
            if (!IsInDesignMode)
            {
                Messenger.Default.Register<CommandMessage>(
                    this,
                    m =>
                    {
                        if (m.Command
                            == Notifications.NotifyShutdown)
                        {
                            SaveSettings();
                        }
                    });

                _settingsFile = new SettingsFileHandler();

                var savedSettings = _settingsFile.LoadSettings();
                Messenger.Default.Send<Brush, MainViewModel>(
                    savedSettings.ApplicationBackgroundBrush);

                _isLoading = true;

                var solidBrush
                    = savedSettings.ApplicationBackgroundBrush as SolidColorBrush;
                if (solidBrush != null)
                {
                    Red = solidBrush.Color.R;
                    Green = solidBrush.Color.G;
                    Blue = solidBrush.Color.B;
                }

                _isLoading = false;
            }
        }

        /// <summary>
        /// Gets the Blue property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public byte Blue
        {
            get
            {
                return _blue;
            }

            set
            {
                if (_blue == value)
                {
                    return;
                }

                _blue = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(BluePropertyName);

                SendBrushUpdate();
            }
        }

        /// <summary>
        /// Gets the Green property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public byte Green
        {
            get
            {
                return _green;
            }

            set
            {
                if (_green == value)
                {
                    return;
                }

                _green = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(GreenPropertyName);

                SendBrushUpdate();
            }
        }

        /// <summary>
        /// Gets the Red property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public byte Red
        {
            get
            {
                return _red;
            }

            set
            {
                if (_red == value)
                {
                    return;
                }

                _red = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(RedPropertyName);

                SendBrushUpdate();
            }
        }

        protected virtual void SaveSettings()
        {
            var settings = new Settings
            {
                ApplicationBackgroundBrush = GetCurrentBrush()
            };

            _settingsFile.SaveSettings(settings);
        }

        private Brush GetCurrentBrush()
        {
            return new SolidColorBrush(
                Color.FromArgb(255, Red, Green, Blue));
        }

        private void SendBrushUpdate()
        {
            if (_isLoading)
            {
                return;
            }

            Messenger.Default.Send<Brush, MainViewModel>(
                GetCurrentBrush());
        }
    }
}