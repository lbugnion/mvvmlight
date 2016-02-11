using CoreGraphics;
using Foundation;
using UIKit;

namespace ObservableTableAndCollectionViewSource.Layout
{
    public class HeaderForCollectionView : UICollectionReusableView
    {
        public UILabel SelectedItemLabel
        {
            get;
            private set;
        }

        [Export("initWithFrame:")]
        public HeaderForCollectionView(CGRect frame)
            : base(frame)
        {
            BackgroundColor = UIColor.Red;

            var titleLabel = new UILabel
            {
                Frame = new CGRect(10, -10, 300, 50),
                Text = "Selected item:"
            };

            SelectedItemLabel = new UILabel
            {
                Frame = new CGRect(10, 10, 300, 50),
            };

            AddSubview(titleLabel);
            AddSubview(SelectedItemLabel);
        }
    }
}