using CoreGraphics;
using UIKit;

namespace Flowers
{
    public partial class AddCommentViewController : UIViewController
    {
        public UITextView CommentText
        {
            get;
            private set;
        }

        public UIBarButtonItem SaveCommentButton
        {
            get;
            private set;
        }

        private void InitializeComponent()
        {
            View.BackgroundColor = Application.Colors.MainBackgroundColor;

            SaveCommentButton = new UIBarButtonItem(UIBarButtonSystemItem.Save, null);
            NavigationItem.SetRightBarButtonItem(SaveCommentButton, false);

            CommentText = new UITextView(new CGRect(10, 0, 300, 470))
            {
                BackgroundColor = Application.Colors.TextInputBackgroundColor,
                TextColor = UIColor.Black
            };
            View.Add(CommentText);
        }
    }
}