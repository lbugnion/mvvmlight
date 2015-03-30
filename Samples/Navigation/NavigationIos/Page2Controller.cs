using System;
using System.Diagnostics;
using System.Drawing;

using Foundation;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using UIKit;

namespace NavigationIos
{
    public partial class Page2Controller : UIViewController
    {
        public Page2Controller()
            : base("Page2Controller", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Page 2";
            View.BackgroundColor = UIColor.White;

            var button = UIButton.FromType(UIButtonType.RoundedRect);
            button.SetTitle("Go to page 3 with parameter", UIControlState.Normal);
            button.Frame = new CoreGraphics.CGRect(20, 80, 200, 50);
            View.Add(button);

            button.TouchUpInside += (s, e) =>
            {
                var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                nav.NavigateTo(
                    AppDelegate.Page3Key,
                    "Hello Xamarin " + DateTime.Now.ToString("HH:mm:ss"));
            };
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            Debug.WriteLine(
              "Current page key: "
              + ServiceLocator.Current
                .GetInstance<INavigationService>()
                .CurrentPageKey);
        }
    }
}