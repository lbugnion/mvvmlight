using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace ObservableTableAndCollectionViewSource.Layout
{
    public class TestTableViewCell : UITableViewCell
    {
        private readonly UILabel _label;

        public string Text
        {
            set
            {
                _label.Text = value;
            }
        }

        public TestTableViewCell(IntPtr handle)
            : base(handle)
        {
            BackgroundView = new UIView
            {
                BackgroundColor = UIColor.Orange
            };

            SelectedBackgroundView = new UIView
            {
                BackgroundColor = UIColor.Green
            };

            ContentView.Layer.BorderColor = UIColor.LightGray.CGColor;
            ContentView.Layer.BorderWidth = 2.0f;
            ContentView.BackgroundColor = UIColor.White;

            _label = new UILabel
            {
                Frame = new CGRect(5, 0, 50, 50),
                BackgroundColor = UIColor.FromRGBA(0, 0, 0, 0)
            };

            ContentView.AddSubview(_label);
        }
    }
}