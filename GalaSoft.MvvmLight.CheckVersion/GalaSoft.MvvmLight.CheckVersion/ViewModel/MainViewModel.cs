// ****************************************************************************
// <copyright file="MainViewModel.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>12.9.2009</date>
// <project>GalaSoft.MvvmLight.CheckVersion</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight.CheckVersion.Model;
using GalaSoft.MvvmLight.CheckVersion.Properties;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace GalaSoft.MvvmLight.CheckVersion.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The <see cref="IsIdle" /> property's name.
        /// </summary>
        public const string IsIdlePropertyName = "IsIdle";

        /// <summary>
        /// The <see cref="IsObsolete" /> property's name.
        /// </summary>
        public const string IsObsoletePropertyName = "IsObsolete";

        /// <summary>
        /// The <see cref="IsProcessing" /> property's name.
        /// </summary>
        public const string IsProcessingPropertyName = "IsProcessing";

        /// <summary>
        /// The <see cref="StatusMessage" /> property's name.
        /// </summary>
        public const string StatusMessagePropertyName = "StatusMessage";

        /// <summary>
        /// The <see cref="VersionOnClient" /> property's name.
        /// </summary>
        public const string VersionOnClientPropertyName = "VersionOnClient";

        /// <summary>
        /// The <see cref="VersionOnServer" /> property's name.
        /// </summary>
        public const string VersionOnServerPropertyName = "VersionOnServer";

        private readonly IVersionService _service;

        private bool _isProcessing;

        private string _statusMessage = "Not checked yet";

        private VersionViewModel _versionOnClient;

        private VersionViewModel _versionOnServer;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Usage", 
            "CA2214:DoNotCallOverridableMethodsInConstructors",
            Justification = "Raising PropertyChanged in base class")]
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                VersionOnServer = new VersionViewModel(new Version("1.1.1.1"));
                VersionOnClient = new VersionViewModel(new Version("1.1.1.1"));
            }
            else
            {
                _service = new VersionService();
                _service.GetVersionOnClient(v => VersionOnClient = new VersionViewModel(v));

                CheckServerCommand = new RelayCommand(() =>
                {
                    StatusMessage = "Checking server";
                    IsProcessing = true;
                    _service.GetVersionOnServer(v =>
                    {
                        VersionOnServer = new VersionViewModel(v);
                        IsProcessing = false;

                        if (IsObsolete == null)
                        {
                            StatusMessage = "Not checked yet";
                            return;
                        }

                        StatusMessage = IsObsolete.Value ? "You should update" : "Up to date";
                    });
                });

                ShutdownCommand = new RelayCommand(SendShutdown);

                NavigateToUrlCommand = new RelayCommand<string>(u => Process.Start(u));

                VersionOnServer = new VersionViewModel(VersionViewModel.Empty);
            }
        }

        public RelayCommand CheckServerCommand
        {
            get;
            private set;
        }

        [SuppressMessage(
            "Microsoft.Performance", 
            "CA1822:MarkMembersAsStatic",
            Justification = "This member is needed for binding")]
        public string GetStartedLocation
        {
            get
            {
                return Settings.Default.GetStartedLocation;
            }
        }

        public bool IsIdle
        {
            get
            {
                return !IsProcessing;
            }
        }

        /// <summary>
        /// Gets the IsObsolete property.
        /// </summary>
        public bool? IsObsolete
        {
            get
            {
                if (VersionOnServer == null
                    || VersionOnClient == null
                    || VersionOnServer.Model == null
                    || VersionOnClient.Model == null
                    || VersionOnServer.Model == VersionViewModel.Empty)
                {
                    return null;
                }

                return VersionOnClient.Model < VersionOnServer.Model;
            }
        }

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
                RaisePropertyChanged(IsIdlePropertyName);
            }
        }

        public RelayCommand<string> NavigateToUrlCommand
        {
            get;
            private set;
        }

        public RelayCommand ShutdownCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the StatusMessage property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public string StatusMessage
        {
            get
            {
                return _statusMessage;
            }

            private set
            {
                if (_statusMessage == value)
                {
                    return;
                }

                _statusMessage = value;

                RaisePropertyChanged(StatusMessagePropertyName);
            }
        }

        /// <summary>
        /// Gets the VersionOnClient property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public VersionViewModel VersionOnClient
        {
            get
            {
                return _versionOnClient;
            }

            private set
            {
                if (_versionOnClient == value)
                {
                    return;
                }

                _versionOnClient = value;

                RaisePropertyChanged(VersionOnClientPropertyName);
                RaisePropertyChanged(IsObsoletePropertyName);
            }
        }

        /// <summary>
        /// Gets the VersionOnServer property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public VersionViewModel VersionOnServer
        {
            get
            {
                return _versionOnServer;
            }

            private set
            {
                if (_versionOnServer == value)
                {
                    return;
                }

                _versionOnServer = value;

                RaisePropertyChanged(VersionOnServerPropertyName);
                RaisePropertyChanged(IsObsoletePropertyName);
            }
        }

        public bool CheckServer()
        {
            if (CheckServerCommand.CanExecute(null))
            {
                CheckServerCommand.Execute(null);
                return true;
            }

            return false;
        }

        private void SendShutdown()
        {
            var commandMessage = new CommandMessage(this, Commands.RequestShutdown);
            Messenger.Default.Send(commandMessage);
        }
    }
}