using System.Diagnostics;
using Foundation;
using System;
using System.CodeDom.Compiler;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using UIKit;

namespace NavigationIosStoryboard
{
	partial class Page2Controller : UIViewController
	{
		public Page2Controller (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            GoToPage3Button.TouchUpInside += (s, e) =>
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
