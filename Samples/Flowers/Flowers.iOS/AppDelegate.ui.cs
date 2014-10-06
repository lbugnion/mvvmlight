using System.Drawing;
using Flowers.Data.ViewModel;
using GalaSoft.MvvmLight.Helpers;
using MonoTouch.UIKit;

namespace Flowers
{
    public partial class AppDelegate
    {
        private UIWindow _window;

        public UILabel LastLoadedText
        {
            get;
            private set;
        }

        public ObservableTableViewController<FlowerViewModel> ListController
        {
            get;
            private set;
        }

        public UIBarButtonItem RefreshButton
        {
            get;
            private set;
        }

        public void InitializeComponent()
        {
            _window = new UIWindow(UIScreen.MainScreen.Bounds);

            RefreshButton = new UIBarButtonItem(
                "Refresh",
                UIBarButtonItemStyle.Plain,
                null);

            ListController.GetHeightForHeaderDelegate = (table, section) => 20;

            LastLoadedText = new UILabel(new RectangleF(15, 0, 300, 20))
            {
                Font = Application.Fonts.TinyFont,
                BackgroundColor = Application.Colors.MainBackgroundColor
            };

            ListController.GetViewForHeaderDelegate = (table, section) => LastLoadedText;

            ListController.NavigationItem.SetRightBarButtonItem(RefreshButton, false);
            ListController.Title = "Flowers";

            MainNavigationController = new UINavigationController(ListController);
            _window.RootViewController = MainNavigationController;
        }
    }
}