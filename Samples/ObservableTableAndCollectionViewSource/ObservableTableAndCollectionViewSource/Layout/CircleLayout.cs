using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace ObservableTableAndCollectionViewSource.Layout
{
    public class CircleLayout : UICollectionViewLayout
    {
        private const float ItemSize = 70.0f;
        private static readonly NSString MyDecorationViewId = new NSString("MyDecorationView");
        private int _cellCount = 20;
        private CGPoint _center;
        private float _radius;

        public override CGSize CollectionViewContentSize
        {
            get
            {
                return CollectionView.Frame.Size;
            }
        }

        public CircleLayout()
        {
            RegisterClassForDecorationView(typeof (MyDecorationView), MyDecorationViewId);
        }

        public override UICollectionViewLayoutAttributes[] LayoutAttributesForElementsInRect(CGRect rect)
        {
            var attributes = new UICollectionViewLayoutAttributes[_cellCount + 1];

            for (int i = 0; i < _cellCount; i++)
            {
                NSIndexPath indexPath = NSIndexPath.FromItemSection(i, 0);
                attributes[i] = LayoutAttributesForItem(indexPath);
            }

            var decorationAttribs = UICollectionViewLayoutAttributes.CreateForDecorationView(
                MyDecorationViewId,
                NSIndexPath.FromItemSection(0, 0));

            decorationAttribs.Size = CollectionView.Frame.Size;
            decorationAttribs.Center = CollectionView.Center;
            decorationAttribs.ZIndex = -1;
            attributes[_cellCount] = decorationAttribs;

            return attributes;
        }

        public override UICollectionViewLayoutAttributes LayoutAttributesForItem(NSIndexPath path)
        {
            UICollectionViewLayoutAttributes attributes = UICollectionViewLayoutAttributes.CreateForCell(path);
            attributes.Size = new CGSize(ItemSize, ItemSize);
            attributes.Center = new CGPoint(
                _center.X + _radius * (float)Math.Cos(2 * path.Row * Math.PI / _cellCount),
                _center.Y + _radius * (float)Math.Sin(2 * path.Row * Math.PI / _cellCount));
            return attributes;
        }

        public override void PrepareLayout()
        {
            base.PrepareLayout();

            CGSize size = CollectionView.Frame.Size;
            _cellCount = (int)CollectionView.NumberOfItemsInSection(0);
            _center = new CGPoint(size.Width / 2.0f, size.Height / 2.0f);
            _radius = (float)Math.Min(size.Width, size.Height) / 2.5f;
        }

        public override bool ShouldInvalidateLayoutForBoundsChange(CGRect newBounds)
        {
            return true;
        }
    }

    public class MyDecorationView : UICollectionReusableView
    {
        [Export("initWithFrame:")]
        public MyDecorationView(CGRect frame)
            : base(frame)
        {
            BackgroundColor = UIColor.Red;
        }
    }
}