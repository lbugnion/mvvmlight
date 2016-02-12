using Foundation;
using System;
using System.CodeDom.Compiler;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using UIKit;

namespace NavigationIosStoryboard
{
    partial class Page3Controller : UIViewController
    {
        public NavigationService Nav
        {
            get
            {
                return (NavigationService)ServiceLocator.Current.GetInstance<INavigationService>();
            }
        }

        public Page3Controller(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            GoBackButton.TouchUpInside += (s, e) =>
            {
                Nav.GoBack();
            };

            GoToPage4Button.TouchUpInside += (s, e) =>
            {
                // Page4Key was never configured. However the storyboard ID
                // is equal to AppDelegate.Page4Key, so the NavigationService
                // will know how to navigate to it.
                Nav.NavigateTo(AppDelegate.Page4Key);
            };

            var param = (string)Nav.GetAndRemoveParameter(this);
            DisplayLabel.Text = param;
        }
    }

}
