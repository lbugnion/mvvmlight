using Foundation;
using System;
using System.CodeDom.Compiler;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using UIKit;

namespace $safeprojectname$
{
	partial class SecondViewController : ControllerBase
	{
		public SecondViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            BackButton.TouchUpInside += (s, e) =>
            {
                var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                nav.GoBack();
            };

            var p = (string)NavigationParameter;

            if (string.IsNullOrEmpty(p))
            {
                NavigationParameterText.Text = "No navigation parameter";
            }
            else
            {
                NavigationParameterText.Text = "Navigation parameter: " + p;
            }
        }
	}
}
