using CoreGraphics;
using UIKit;

namespace Flowers
{
    public partial class DetailsViewController : UIViewController
    {
        public UILabel DescriptionText
        {
            get;
            private set;
        }

        public UIImageView FlowerImage
        {
            get;
            set;
        }

        public UILabel NameText
        {
            get;
            private set;
        }

        public UIScrollView Scroll
        {
            get;
            set;
        }

        public UIBarButtonItem SeeCommentButton
        {
            get;
            set;
        }

        public UITableView Table
        {
            get;
            set;
        }

        private void InitializeComponent()
        {
            View.BackgroundColor = Application.Colors.MainBackgroundColor;

            FlowerImage = new UIImageView(new CGRect(10, 75, 120, 120));
            View.Add(FlowerImage);

            NameText = new UILabel(new CGRect(140, 75, 170, 30))
            {
                TextColor = Application.Colors.HighlightColor,
                Font = Application.Fonts.TitleFont,
                LineBreakMode = UILineBreakMode.WordWrap,
                Lines = 0,
            };
            View.Add(NameText);

            Scroll = new UIScrollView(new CGRect(10, 205, 300, 265));
            View.Add(Scroll);

            DescriptionText = new UILabel(new CGRect(0, 0, 300, 235))
            {
                LineBreakMode = UILineBreakMode.WordWrap,
                Lines = 0,
            };
            Scroll.Add(DescriptionText);

            SeeCommentButton = new UIBarButtonItem(
                "Comments",
                UIBarButtonItemStyle.Plain,
                null);

            NavigationItem.SetRightBarButtonItem(SeeCommentButton, false);
        }
    }
}