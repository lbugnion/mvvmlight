using Flowers.Data.ViewModel;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SDWebImage;

namespace Flowers
{
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        private Binding<string, string> _lastLoadedBinding;

        public static UINavigationController MainNavigationController
        {
            get;
            private set;
        }

        public MainViewModel Vm
        {
            get
            {
                return Application.Locator.Main;
            }
        }

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            ListController = Vm.Flowers.GetController(
                CreateFlowerCell,
                BindFlowerCell);

            InitializeComponent();

            var nav = (NavigationService)ServiceLocator.Current.GetInstance<INavigationService>();
            nav.Initialize(MainNavigationController);

            RefreshButton.SetCommand("Clicked", Vm.RefreshCommand);

            _lastLoadedBinding = this.SetBinding(
                () => Vm.LastLoadedFormatted,
                () => LastLoadedText.Text);

            ListController.SelectionChanged +=
                (s, e) => Vm.ShowDetailsCommand.Execute(ListController.SelectedItem);

            _window.MakeKeyAndVisible();
            return true;
        }

        private UITableViewCell CreateFlowerCell(NSString reuseId)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Subtitle, null);
            cell.TextLabel.TextColor = Application.Colors.HighlightColor;
            return cell;
        }

        private void BindFlowerCell(UITableViewCell cell, FlowerViewModel flower, NSIndexPath path)
        {
            cell.TextLabel.Text = flower.Model.Name;
            cell.DetailTextLabel.Text = flower.Model.Description;
            cell.ImageView.SetImage(
                new NSUrl(flower.ImageUri.AbsoluteUri),
                UIImage.FromBundle("flower_256_magenta.png"));
        }
    }
}