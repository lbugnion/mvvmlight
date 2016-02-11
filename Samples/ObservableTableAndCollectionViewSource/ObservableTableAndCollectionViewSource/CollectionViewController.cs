using System.Collections.Generic;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using ObservableTableAndCollectionViewSource.Layout;
using ObservableTableAndCollectionViewSource.Model;
using ObservableTableAndCollectionViewSource.ViewModel;
using UIKit;

namespace ObservableTableAndCollectionViewSource
{
    partial class CollectionViewController : UICollectionViewController
    {
        private const string CellId = "AnimalCell";
        private static readonly NSString HeaderId = new NSString("Header");
        private readonly List<Binding> _bindings = new List<Binding>();
        private HeaderForCollectionView _headerView;
        private ObservableCollectionViewSource<DataItem, TestCollectionViewCell> _source;

        private MainViewModel Vm
        {
            get
            {
                return Application.Locator.Main;
            }
        }

        public CollectionViewController(UICollectionViewLayout layout)
            : base(layout)
        {
        }

        public UICollectionReusableView GetViewForSupplementaryElement(NSString elementKind, NSIndexPath indexPath)
        {
            if (_headerView == null)
            {
                _headerView =
                    (HeaderForCollectionView)
                        CollectionView.DequeueReusableSupplementaryView(elementKind, HeaderId, indexPath);

                _bindings.Add(
                    this.SetBinding(
                        () => _source.SelectedItem.Title,
                        () => _headerView.SelectedItemLabel.Text,
                        fallbackValue: "Nothing yet"));
            }

            return _headerView;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            CollectionView.RegisterClassForSupplementaryView(
                // Needed if you want to provide a header or footer
                typeof (HeaderForCollectionView),
                UICollectionElementKindSection.Header,
                HeaderId);

            CollectionView.BackgroundColor = UIColor.White;

            _source = Vm.Items.GetCollectionViewSource<DataItem, TestCollectionViewCell>(
                BindCell,
                GetViewForSupplementaryElement,
                // Optional, for header and footer
                CellId,
                // Reuse Cell ID
                () => new CollectionViewSourceEx());
                // Last argument is optional, provides a way to define your own derived class and extend it.

            CollectionView.Source = _source;

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

        private void BindCell(TestCollectionViewCell collectionViewCell, DataItem item, NSIndexPath path)
        {
            collectionViewCell.Text = item.Title;
        }
    }

    public class CollectionViewSourceEx : ObservableCollectionViewSource<DataItem, TestCollectionViewCell>
    {
        public override UICollectionViewCell GetCell(UICollectionView view, NSIndexPath indexPath)
        {
            var cell = base.GetCell(view, indexPath);
            cell.ContentView.BackgroundColor = UIColor.White;
            return cell;
        }

        public override void ItemDeselected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            SelectedItem = null;
            var cell = collectionView.CellForItem(indexPath);
            cell.ContentView.BackgroundColor = UIColor.White;
        }

        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var item = GetItem(indexPath);
            SelectedItem = item;

            var cell = collectionView.CellForItem(indexPath);
            cell.ContentView.BackgroundColor = UIColor.Green;
        }
    }
}