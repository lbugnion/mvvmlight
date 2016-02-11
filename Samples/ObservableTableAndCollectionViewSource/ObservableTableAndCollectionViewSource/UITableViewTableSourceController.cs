using Foundation;
using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using ObservableTableAndCollectionViewSource.Layout;
using ObservableTableAndCollectionViewSource.Model;
using ObservableTableAndCollectionViewSource.ViewModel;
using UIKit;

namespace ObservableTableAndCollectionViewSource
{
    // ReSharper disable once InconsistentNaming
	partial class UITableViewTableSourceController : UITableViewController
	{
	    private const string ReuseId = "SampleID";

        private readonly List<Binding> _bindings = new List<Binding>();
        private ObservableTableViewSource<DataItem> _source;
        private HeaderForTableView _headerView;

        private MainViewModel Vm
        {
            get
            {
                return Application.Locator.Main;
            }
        }

        public UITableViewTableSourceController (IntPtr handle) : base (handle)
		{
		}

	    public override void ViewDidLoad()
	    {
            base.ViewDidLoad();

	        var nav = (NavigationService)ServiceLocator.Current.GetInstance<INavigationService>();
            var useCreateCell = (bool?)nav.GetAndRemoveParameter(this);

            if (useCreateCell == null || useCreateCell.Value)
            {
                _source = Vm.Items.GetTableViewSource(
                CreateCell,
                BindUiTableViewCell,
                factory: () => new TableViewSourceEx());
            }
            else
            {
                _source = Vm.Items.GetTableViewSource(
                    BindTestTableViewCell,
                    ReuseId,
                    factory: () => new TableViewSourceEx());

                TableView.RegisterClassForCellReuse(typeof(TestTableViewCell), new NSString(ReuseId));
            }

            _source.GetHeightForHeaderDelegate = () => 50;
            _source.GetViewForHeaderDelegate = () =>
            {
                _headerView = new HeaderForTableView();

                _bindings.Add(
                    this.SetBinding(
                        () => _source.SelectedItem.Title,
                        () => _headerView.SelectedItemLabel.Text,
                        fallbackValue: "Nothing yet"));

                return _headerView;
            };

            TableView.Source = _source;

            var addButton = new UIBarButtonItem
            {
                Title = "Add"
            };
            addButton.SetCommand(Vm.AddCommand);

            var delButton = new UIBarButtonItem
            {
                Title = "Del"
            };

            var selectedItemBinding = this.SetBinding(() => _source.SelectedItem);
            _bindings.Add(selectedItemBinding);
            delButton.SetCommand(Vm.DeleteCommand, selectedItemBinding);

            NavigationItem.RightBarButtonItems = new[]
            {
                delButton,
                addButton,
            };
        }

        private void BindUiTableViewCell(UITableViewCell cell, DataItem item, NSIndexPath path)
        {
            cell.TextLabel.Text = item.Title;
        }

        private void BindTestTableViewCell(UITableViewCell cell, DataItem item, NSIndexPath path)
        {
            ((TestTableViewCell)cell).Text = item.Title;
        }

        private UITableViewCell CreateCell(NSString reuseId)
        {
            return new UITableViewCell(UITableViewCellStyle.Default, reuseId);
        }
    }

    public class TableViewSourceEx : ObservableTableViewSource<DataItem>
    {
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            base.RowSelected(tableView, indexPath);
            var cell = tableView.CellAt(indexPath);
            cell.ContentView.BackgroundColor = UIColor.Green;
        }

        public override void RowDeselected(UITableView tableView, NSIndexPath indexPath)
        {
            base.RowDeselected(tableView, indexPath);
            var cell = tableView.CellAt(indexPath);
            cell.ContentView.BackgroundColor = UIColor.White;
        }

        public override UITableViewCell GetCell(UITableView view, NSIndexPath indexPath)
        {
            var cell = base.GetCell(view, indexPath);
            cell.ContentView.BackgroundColor = UIColor.White;
            return cell;
        }
    }
}
