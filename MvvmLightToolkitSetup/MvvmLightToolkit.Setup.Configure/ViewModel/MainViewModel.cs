// ****************************************************************************
// <copyright file="MainViewModel.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>26.6.2009</date>
// <project>MvvmLightToolkit.Setup.Configure</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this project or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MvvmLightToolkit.Setup.Configure.Helpers;
using MvvmLightToolkit.Setup.Configure.Properties;

namespace MvvmLightToolkit.Setup.Configure.ViewModel
{
    /// <summary>
    /// Main view model for this application, bound to MainControl.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The <see cref="CanUninstall" /> property's name.
        /// </summary>
        public const string CanUninstallPropertyName = "CanUninstall";

        /// <summary>
        /// The <see cref="IsInstallPressed" /> property's name.
        /// </summary>
        public const string IsInstallPressedPropertyName = "IsInstallPressed";

        /// <summary>
        /// The <see cref="IsProcessing" /> property's name.
        /// </summary>
        public const string IsProcessingPropertyName = "IsProcessing";

        private const string BlendProcessName = "Blend";

        private readonly Installer _installer;

        private readonly CommandMessage _shutdownCommandMessage;

        private bool _canUninstall;

        private bool _isInstallPressed;

        private bool _isProcessing;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors",
            Justification = "Initialization needed for bindings")]
        public MainViewModel()
        {
            ViewModelLocator.SettingsStatic.InstalledVersion = Settings.Default.DllVersion;

            _shutdownCommandMessage = new CommandMessage(this, Commands.Shutdown);

            _installer = new Installer();

            InstallCommand = new RelayCommand(
                Install,
                () => !this.IsInstallPressed);

            ShutdownCommand = new RelayCommand(
                () => Messenger.Default.Broadcast(_shutdownCommandMessage));

            CanUninstall = ViewModelLocator.SettingsStatic.InstalledVersion
                           != SettingsFileHandler.NoInstalledVersion;
        }

        /// <summary>
        /// Gets a value indicating whether there is a current version that can be uninstalled.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool CanUninstall
        {
            get
            {
                return _canUninstall;
            }

            private set
            {
                if (_canUninstall == value)
                {
                    return;
                }

                _canUninstall = value;

                // Remove one of the two calls
                RaisePropertyChanged(CanUninstallPropertyName);
            }
        }

        /// <summary>
        /// Gets the command used to install the toolkit.
        /// </summary>
        public RelayCommand InstallCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a value indicating whether the installation was successful.
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public bool IsInstallPressed
        {
            get
            {
                return _isInstallPressed;
            }

            private set
            {
                if (_isInstallPressed == value)
                {
                    return;
                }

                _isInstallPressed = value;
                RaisePropertyChanged(IsInstallPressedPropertyName, value, true);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the Setup program is currently processing an operation.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsProcessing
        {
            get
            {
                return _isProcessing;
            }

            private set
            {
                if (_isProcessing == value)
                {
                    return;
                }

                _isProcessing = value;
                RaisePropertyChanged(IsProcessingPropertyName);
            }
        }

        /// <summary>
        /// Gets the instance of the <see cref="SettingsViewModel" /> class
        /// holding the settings for the setup.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic",
            Justification = "Non static member needed for binding")]
        public SettingsViewModel SettingsVM
        {
            get
            {
                return ViewModelLocator.SettingsStatic;
            }
        }

        /// <summary>
        /// Gets the command used to shut down the application.
        /// </summary>
        public RelayCommand ShutdownCommand
        {
            get;
            private set;
        }

        [SuppressMessage(
            "Microsoft.Performance", 
            "CA1822:MarkMembersAsStatic",
            Justification = "Member needed for binding.")]
        public string WindowTitle
        {
            get
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.WindowTitle,
                    Settings.Default.DllVersion);
            }
        }

        public void Uninstall()
        {
            IsProcessing = true;
            _installer.Uninstall(UninstallComplete, false, ViewModelLocator.SettingsStatic);
        }

        internal static void SendErrorMessage(Exception ex)
        {
            var errorMessage = new GenericMessage<Exception>(ex);
            Messenger.Default.Broadcast(errorMessage);
        }

        internal void Install()
        {
            IsProcessing = true;
            IsInstallPressed = true;

            CheckIfBlendIsRunning(MessageBoxResult.OK);
        }

        private void CheckIfBlendIsRunning(MessageBoxResult result)
        {
            if (result != MessageBoxResult.OK)
            {
                SendErrorMessage(new InvalidOperationException(Resources.BlendIsRunningException));
                return;
            }

            var blendProcesses = Process.GetProcessesByName(BlendProcessName);
            if (blendProcesses.Length > 0)
            {
                var message = new DialogMessage(
                    this,
                    Resources.BlendIsRunningMessage,
                    CheckIfBlendIsRunning)
                {
                    Caption = Resources.BlendIsRunningCaption,
                    Button = MessageBoxButton.OKCancel,
                    Icon = MessageBoxImage.Exclamation
                };
                Messenger.Default.Broadcast(message);
            }
            else
            {
                ContinueInstall();
            }
        }

        private void ContinueInstall()
        {
            if (CanUninstall)
            {
                _installer.Uninstall(
                    ex =>
                    {
                        if (ex == null)
                        {
                            MainWindow.Logger.Log("Uninstall successful, now installing");
                            _installer.Install(InstallComplete);
                        }
                        else
                        {
                            MainWindow.Logger.Log("Error when uninstalling", ex);
                            SendErrorMessage(ex);
                        }
                    },
                    true,
                    ViewModelLocator.OldSettings);
            }
            else
            {
                MainWindow.Logger.Log("Nothing to uninstall, now installing");
                _installer.Install(InstallComplete);
            }
        }

        private void InstallComplete(Exception ex)
        {
            IsProcessing = false;

            if (ex == null)
            {
                var settings = ViewModelLocator.SettingsStatic;
                settings.IsEnabled = false;

                CanUninstall = true;

                var message = new DialogMessage(
                    this,
                    Resources.SuccessInstall,
                    r => Messenger.Default.Broadcast(new CommandMessage(this, Commands.Shutdown)))
                {
                    Button = MessageBoxButton.OK,
                    Caption = Resources.SuccessTitle,
                    Icon = MessageBoxImage.Exclamation
                };

                Messenger.Default.Broadcast(message);
                MainWindow.Logger.Log("Install was successful");
            }
            else
            {
                SendErrorMessage(ex);
                MainWindow.Logger.Log("Install was NOT successful");
            }
        }

        private void UninstallComplete(Exception ex)
        {
            IsProcessing = false;

            if (ex == null)
            {
                CanUninstall = false;
                ViewModelLocator.SettingsStatic.InstalledVersion = SettingsFileHandler.NoInstalledVersion;
            }
            else
            {
                SendErrorMessage(ex);
            }
        }
    }
}