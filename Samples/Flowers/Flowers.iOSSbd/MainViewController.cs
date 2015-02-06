using System;
using Flowers.Data.ViewModel;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using SDWebImage;
using UIKit;

namespace Flowers.iOSSbd
{
    partial class MainViewController : UIViewController
    {
        private Binding<string, string> _lastLoadedBinding;
        private ObservableTableViewController<FlowerViewModel> _tableViewController;

        private MainViewModel Vm
        {
            get
            {
                return Application.Locator.Main;
            }
        }

        public MainViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            _lastLoadedBinding = this.SetBinding(
                () => Vm.LastLoadedFormatted,
                () => LastLoadedText.Text);

            RefreshButton.SetCommand(
                "Clicked",
                Vm.RefreshCommand);

            _tableViewController = Vm.Flowers.GetController(
                CreateFlowerCell,
                BindFlowerCell);

            _tableViewController.TableView = FlowersTableView;

            _tableViewController.SelectionChanged +=
                (s, e) => Vm.ShowDetailsCommand.Execute(_tableViewController.SelectedItem);

            base.ViewDidLoad();
        }

        private void BindFlowerCell(UITableViewCell cell, FlowerViewModel flower, NSIndexPath path)
        {
            cell.TextLabel.Text = flower.Model.Name;
            cell.DetailTextLabel.Text = flower.Model.Description;
            cell.ImageView.SetImage(
                new NSUrl(flower.ImageUri.AbsoluteUri),
                UIImage.FromBundle("flower_256_magenta.png"));
        }

        private UITableViewCell CreateFlowerCell(NSString reuseId)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Subtitle, null);
            cell.TextLabel.TextColor = Application.Colors.HighlightColor;
            return cell;
        }
    }
}