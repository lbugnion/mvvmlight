using System;
using System.Drawing;

using Foundation;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using UIKit;

namespace NavigationIos
{
    public partial class MainViewController : UIViewController
    {
        public MainViewController()
            : base("MainViewController", null)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Main View";
            View.BackgroundColor = UIColor.White;

            var button = UIButton.FromType(UIButtonType.RoundedRect);
            button.SetTitle("Go to page 2", UIControlState.Normal);
            button.Frame = new CoreGraphics.CGRect(20, 80, 200, 50);
            View.Add(button);

            button.TouchUpInside += (s, e) =>
            {
                var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                nav.NavigateTo(AppDelegate.Page2Key);
            };
        }
    }
}