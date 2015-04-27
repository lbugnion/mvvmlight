using System;
using System.Diagnostics;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using $safeprojectname$.Model;

namespace $safeprojectname$.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The <see cref="Clock" /> property's name.
        /// </summary>
        public const string ClockPropertyName = "Clock";

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private readonly IDataService _dataService;
        private readonly INavigationService _navigationService;
        private string _clock = "Starting...";
        private RelayCommand _incrementCommand;
        private int _index;
        private RelayCommand<string> _navigateCommand;
        private bool _runClock;
        private RelayCommand<string> _showDialogCommand;
        private string _welcomeTitle = "Hello MVVM";

        /// <summary>
        /// Sets and gets the Clock property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// Use the "mvvminpc*" snippet group to create more such properties.
        /// </summary>
        public string Clock
        {
            get
            {
                return _clock;
            }
            set
            {
                Set(ref _clock, value);
            }
        }

        /// <summary>
        /// Gets the IncrementCommand.
        /// Use the "mvvmr*" snippet group to create more such commands.
        /// </summary>
        public RelayCommand IncrementCommand
        {
            get
            {
                return _incrementCommand
                       ?? (_incrementCommand = new RelayCommand(
                           () =>
                           {
                               WelcomeTitle = string.Format("Clicked {0} time(s)", ++_index);
                           }));
            }
        }

        /// <summary>
        /// Gets the NavigateCommand.
        /// Goes to the second page, using the navigation service.
        /// Use the "mvvmr*" snippet group to create more such commands.
        /// </summary>
        public RelayCommand<string> NavigateCommand
        {
            get
            {
                return _navigateCommand
                       ?? (_navigateCommand = new RelayCommand<string>(
                           parameter => _navigationService.NavigateTo(
                               ViewModelLocator.SecondPageKey, 
                               parameter)));
            }
        }

        /// <summary>
        /// Gets the ShowDialogCommand.
        /// Use the "mvvmr*" snippet group to create more such commands.
        /// </summary>
        public RelayCommand<string> ShowDialogCommand
        {
            get
            {
                return _showDialogCommand
                       ?? (_showDialogCommand = new RelayCommand<string>(
                           async text =>
                           {
                               var dialogService = ServiceLocator.Current.GetInstance<IDialogService>();
                               await dialogService.ShowMessage(
                                   "This is a message displayed by the dialog service | " + text,
                                   "Dialog sample",
                                   "OK",
                                   () =>
                                   {
                                       Debug.WriteLine("This code is only executed after the dialog closes (1)");
                                   });

                               Debug.WriteLine("This code is only executed after the dialog closes (2)");
                           },
                           text => !string.IsNullOrEmpty(text))); // This line disables the button if the text is null or empty
            }
        }

        /// <summary>
        /// Sets and gets the WelcomeTitle property.
        /// Changes to this property's value raise the PropertyChanged event.
        /// Use the "mvvminpc*" snippet group to create more such properties.
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(
            IDataService dataService,
            INavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;

            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });
        }

        /// <summary>
        /// This method demonstrates how to use the DispatcherHelper to
        /// dispatch an instruction from a background thread
        /// back to the main thread.
        /// </summary>
        public void StartClock()
        {
            _runClock = true;

            Task.Run(
                async () =>
                {
                    while (_runClock)
                    {
                        DispatcherHelper.CheckBeginInvokeOnUI(
                            () =>
                            {
                                Clock = DateTime.Now.ToString("HH:mm:ss");
                            });

                        await Task.Delay(1000);
                    }
                });
        }

        public void StopClock()
        {
            _runClock = false;
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}

        private RelayCommand _sendMessageCommand;

        /// <summary>
        /// Gets the SendMessageCommand.
        /// </summary>
        public RelayCommand SendMessageCommand
        {
            get
            {
                return _sendMessageCommand
                    ?? (_sendMessageCommand = new RelayCommand(
                    () =>
                    {
                        // Any object can send messages.
                        // For this simple demo, the message is received by App.xaml.cs
                        // (see line 98).
                        // This message type also allows a reply to be sent.

                        Messenger.Default.Send(
                            new NotificationMessageAction<string>(
                                "AnyNotification",
                                reply =>
                                {
                                    WelcomeTitle = reply;
                                }));
                    }));
            }
        }
    }
}