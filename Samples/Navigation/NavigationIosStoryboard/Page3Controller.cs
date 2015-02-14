using Foundation;
using System;
using System.CodeDom.Compiler;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using UIKit;

namespace NavigationIosStoryboard
{
    partial class Page3Controller : ControllerBase
    {
        public Page3Controller(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            GoBackButton.TouchUpInside += (s, e) =>
            {
                var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                nav.GoBack();
            };

            var param = (string)NavigationParameter;
            DisplayLabel.Text = param;
        }
    }

}
