using CoreGraphics;
using Flowers.Data.Model;
using Flowers.Data.ViewModel;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using SDWebImage;
using UIKit;

namespace Flowers
{
    [Register("DetailsViewController")]
    public partial class DetailsViewController
    {
        public FlowerViewModel Vm
        {
            get;
            private set;
        }

        public DetailsViewController(FlowerViewModel flower)
        {
            Vm = flower;
        }

        public override void ViewDidLoad()
        {
            View = new UniversalView();
            base.ViewDidLoad();
            InitializeComponent();

            Title = "Details";

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
                        DescriptionText.Frame = new CGRect(0, 0, 300, DescriptionText.Bounds.Height);

                        Scroll.ContentSize = new CGSize(300, DescriptionText.Bounds.Height);
                        Scroll.SetNeedsLayout();
                    });

            SeeCommentButton.Clicked += (s, e) =>
            {
                // iOS is the only framework where we decided to split the comments
                // on a different page. This is a good example that you can easily
                // have different UI experience even though the ViewModel and Model are the same

                var controller = Vm.Model.Comments.GetController(
                    CreateCommentCell,
                    BindCommentCell);
                controller.Title = "Comments";

                var addCommentButton = new UIBarButtonItem(UIBarButtonSystemItem.Add, null);
                addCommentButton.SetCommand("Clicked", Vm.AddCommentCommand);
                controller.NavigationItem.SetRightBarButtonItem(addCommentButton, false);

                AppDelegate.MainNavigationController.PushViewController(controller, true);
            };
        }

        private void BindCommentCell(UITableViewCell cell, Comment comment, NSIndexPath path)
        {
            cell.TextLabel.Text = comment.Text;
            cell.DetailTextLabel.Text = comment.InputDate.ToString();
        }

        private UITableViewCell CreateCommentCell(NSString reuseId)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Subtitle, null);
            cell.TextLabel.LineBreakMode = UILineBreakMode.WordWrap;
            return cell;
        }
    }
}