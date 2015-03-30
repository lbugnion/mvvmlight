using System;
using System.Drawing;

using Foundation;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using UIKit;

namespace NavigationIos
{
    public partial class Page3Controller : UIViewController
    {
        private readonly string _passedParameter;

        public Page3Controller(string parameter)
            : base("Page3Controller", null)
        {
            _passedParameter = parameter;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Page 3";
            View.BackgroundColor = UIColor.White;

            var button = UIButton.FromType(UIButtonType.RoundedRect);
            button.SetTitle("Go back to page 2", UIControlState.Normal);
            button.Frame = new CoreGraphics.CGRect(20, 80, 200, 50);
            View.Add(button);

            button.TouchUpInside += (s, e) =>
            {
                var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                nav.GoBack();
            };

            var label = new UILabel(new CoreGraphics.CGRect(20, 150, 200, 100));
            View.Add(label);

            label.Text = _passedParameter;
        }
    }
}