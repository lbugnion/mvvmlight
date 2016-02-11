using System;
using System.Collections.Generic;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using ObservableTableAndCollectionViewSource.Layout;
using ObservableTableAndCollectionViewSource.Model;
using ObservableTableAndCollectionViewSource.ViewModel;
using UIKit;

namespace ObservableTableAndCollectionViewSource
{
    partial class MainViewController : UIViewController
    {
        // Keep track of bindings to avoid premature garbage collection
        private readonly List<Binding> _bindings = new List<Binding>();

	    private MainViewModel Vm
        {
            get
            {
                return Application.Locator.Main;
            }
        }

        public NavigationService Nav
        {
            get
            {
                return (NavigationService)ServiceLocator.Current.GetInstance<INavigationService>();
            }
        }

        public MainViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ControllerInCodeButton.TouchUpInside += (s, e) =>
            {
                var c = Vm.Items.GetController(CreateCell, BindCell);
                Nav.NavigationController.PushViewController(c, true);
            };

            TableSourceWithCreateCellButton.TouchUpInside += (s, e) =>
            {
                Nav.NavigateTo(ViewModelLocator.SecondPageKey, true);
            };

            TableSourceWithReuseIdButton.TouchUpInside += (s, e) =>
            {
                Nav.NavigateTo(ViewModelLocator.SecondPageKey, false);
            };

            CollectionViewGridButton.TouchUpInside += (s, e) =>
            {
                var controller = new CollectionViewController(new GridLayout());
                Nav.NavigationController.PushViewController(controller, true);
            };

            CollectionViewCircleButton.TouchUpInside += (s, e) =>
            {
                var controller = new CollectionViewController(new CircleLayout());
                Nav.NavigationController.PushViewController(controller, true);
            };
        }

        private void BindCell(UITableViewCell cell, DataItem item, NSIndexPath path)
        {
            cell.TextLabel.Text = item.Title;
        }

        private UITableViewCell CreateCell(NSString reuseId)
        {
            return new UITableViewCell(UITableViewCellStyle.Default, reuseId);
        }
    }
}
