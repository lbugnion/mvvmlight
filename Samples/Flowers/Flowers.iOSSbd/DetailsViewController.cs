using System;
using CoreGraphics;
using Flowers.Data.ViewModel;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using SDWebImage;
using UIKit;

namespace Flowers.iOSSbd
{
    partial class DetailsViewController : ControllerBase
    {
        public UILabel DescriptionText
        {
            get;
            private set;
        }

        private FlowerViewModel Vm
        {
            get;
            set;
        }

        public DetailsViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            if (NavigationParameter == null)
            {
                throw new InvalidOperationException("No parameter found after navigation");
            }

            Vm = (FlowerViewModel)NavigationParameter;

            DescriptionText = new UILabel(new CGRect(0, 0, 300, 235))
            {
                LineBreakMode = UILineBreakMode.WordWrap,
                Lines = 0,
            };
            Scroll.Add(DescriptionText);

            FlowerImage.SetImage(
                new NSUrl(Vm.ImageUri.AbsoluteUri),
                UIImage.FromBundle("flower_256_magenta.png"));

            this.SetBinding(
                () => Vm.Model.Name)
                .WhenSourceChanges(
                    () =>
                    {
                        // iOS is quite primitive and requires layout recalculation when the content
                        // of UI elements changes. This is a good place to do that.

                        NameText.Text = Vm.Model.Name;
                        NameText.SizeToFit();
                        NameText.Frame = new CGRect(140, 75, 170, NameText.Bounds.Height);
                    });

            this.SetBinding(
                () => Vm.Model.Description)
                .WhenSourceChanges(
                    () =>
                    {
                        DescriptionText.Text = Vm.Model.Description;
                        DescriptionText.SizeToFit();
                        DescriptionText.Frame = new CGRect(
                            0,
                            0,
                            Scroll.Bounds.Width - 20,
                            DescriptionText.Bounds.Height);

                        Scroll.ContentSize = new CGSize(Scroll.Bounds.Width - 20, DescriptionText.Bounds.Height + 20);
                        Scroll.SetNeedsLayout();
                    });

            SeeCommentsButton.TouchUpInside += (s, e) =>
            {
                var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                nav.NavigateTo(AppDelegate.SeeCommentsPageKey, Vm);
            };

            base.ViewDidLoad();
        }
    }
}