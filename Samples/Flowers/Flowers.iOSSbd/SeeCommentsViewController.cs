using System;
using Flowers.Data.Model;
using Flowers.Data.ViewModel;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using UIKit;

namespace Flowers.iOSSbd
{
    partial class SeeCommentsViewController : ControllerBase
    {
        private ObservableTableViewController<Comment> _tableController;

        public UIBarButtonItem AddCommentButton
        {
            get;
            private set;
        }

        public FlowerViewModel Vm
        {
            get;
            set;
        }

        public SeeCommentsViewController(IntPtr handle)
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

            _tableController = Vm.Model.Comments.GetController(
                CreateCommentCell,
                BindCommentCell);

            _tableController.TableView = CommentsTableView;

            AddCommentButton = new UIBarButtonItem(UIBarButtonSystemItem.Add, null);
            NavigationItem.SetRightBarButtonItem(AddCommentButton, false);
            AddCommentButton.SetCommand("Clicked", Vm.AddCommentCommand);

            base.ViewDidLoad();
        }

        private void BindCommentCell(UITableViewCell cell, Comment comment, NSIndexPath path)
        {
            cell.TextLabel.Text = comment.Text;
            cell.DetailTextLabel.Text = comment.InputDate.ToString();
        }

        private UITableViewCell CreateCommentCell(NSString reuseId)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Subtitle, null);
            cell.TextLabel.LineBreakMode = UILineBreakMode.TailTruncation;
            return cell;
        }
    }
}