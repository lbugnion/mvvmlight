using System;
using System.Collections.ObjectModel;
using Flowers.Data.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace Flowers.Data.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public const string LastLoadedPropertyName = "LastLoaded";

        private readonly IFlowersService _flowersService;
        private readonly INavigationService _navigationService;
        private bool _isLoading;
        private DateTime _lastLoaded = DateTime.MinValue;
        private RelayCommand _refreshCommand;
        private RelayCommand<FlowerViewModel> _showDetailsCommand;

        public ObservableCollection<FlowerViewModel> Flowers
        {
            get;
            private set;
        }

        public DateTime LastLoaded
        {
            get
            {
                return _lastLoaded;
            }
            set
            {
                if (Set(() => LastLoaded, ref _lastLoaded, value))
                {
                    RaisePropertyChanged(() => LastLoadedFormatted);
                }
            }
        }

        public string LastLoadedFormatted
        {
            get
            {
                return _isLoading
                    ? "Loading..."
                    : "Last loaded: " + (LastLoaded == DateTime.MinValue ? "Never" : LastLoaded.ToString());
            }
        }

        public RelayCommand RefreshCommand
        {
            get
            {
                return _refreshCommand
                    ?? (_refreshCommand = new RelayCommand(
                    async () =>
                    {
                        Flowers.Clear();

                        _isLoading = true;
                        RefreshCommand.RaiseCanExecuteChanged();
                        RaisePropertyChanged(() => LastLoadedFormatted);

                        Exception error = null;

                        try
                        {
                            var list = await _flowersService.Refresh();

                            foreach (var flower in list)
                            {
                                Flowers.Add(new FlowerViewModel(_flowersService, flower));
                            }

                            _isLoading = false;
                            LastLoaded = DateTime.Now;
                        }
                        catch (Exception ex)
                        {
                            error = ex;
                        }

                        if (error != null)
                        {
                            var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                            await dialog.ShowError(error, "Error when refreshing", "OK", null);
                        }

                        _isLoading = false;
                        RefreshCommand.RaiseCanExecuteChanged();
                        RaisePropertyChanged(() => LastLoadedFormatted);
                    },
                    
                    () => !_isLoading));
            }
        }

        public RelayCommand<FlowerViewModel> ShowDetailsCommand
        {
            get
            {
                return _showDetailsCommand
                       ?? (_showDetailsCommand = new RelayCommand<FlowerViewModel>(
                           flower =>
                           {
                               if (!ShowDetailsCommand.CanExecute(flower))
                               {
                                   return;
                               }

                               _navigationService.NavigateTo(ViewModelLocator.DetailsPageKey, flower);
                           },
                           flower => flower != null));
            }
        }

        public MainViewModel(
            IFlowersService flowersService,
            INavigationService navigationService)
        {
            _flowersService = flowersService;
            _navigationService = navigationService;
            Flowers = new ObservableCollection<FlowerViewModel>();

            if (IsInDesignMode)
            {
                RefreshCommand.Execute(null);
            }
        }
    }
}