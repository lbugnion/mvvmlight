using CoreGraphics;
using UIKit;

namespace ObservableTableAndCollectionViewSource.Layout
{
    public class HeaderForTableView : UICollectionReusableView
    {
        public UILabel SelectedItemLabel
        {
            get;
            private set;
        }

        public HeaderForTableView()
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