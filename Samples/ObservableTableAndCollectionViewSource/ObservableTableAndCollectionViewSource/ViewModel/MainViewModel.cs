using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ObservableTableAndCollectionViewSource.Model;

namespace ObservableTableAndCollectionViewSource.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<DataItem> Items
        {
            get;
            private set;
        }

        public MainViewModel()
        {
            Items = new ObservableCollection<DataItem>
            {
                new DataItem("123"),
                new DataItem("234"),
                new DataItem("345"),
                new DataItem("456"),
                new DataItem("567"),
            };
        }

        private RelayCommand _addCommand;

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand
                    ?? (_addCommand = new RelayCommand(
                    () =>
                    {
                        Items.Add(new DataItem(_random.Next(0, 1000).ToString()));
                    }));
            }
        }

        private RelayCommand<DataItem> _deleteCommand;
        private readonly Random _random = new Random();

        public RelayCommand<DataItem> DeleteCommand
        {
            get
            {
                return _deleteCommand
                    ?? (_deleteCommand = new RelayCommand<DataItem>(
                    item =>
                    {
                        if (Items.Contains(item))
                        {
                            Items.Remove(item);
                        }
                    },
                    item => item != null));
            }
        }
    }
}