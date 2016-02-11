using CoreGraphics;
using Foundation;
using UIKit;

namespace ObservableTableAndCollectionViewSource.Layout
{
    public class GridLayout : UICollectionViewFlowLayout
    {
        public GridLayout ()
        {
            HeaderReferenceSize = new CGSize(100, 50);
        }

        public override bool ShouldInvalidateLayoutForBoundsChange (CGRect newBounds)
        {
            return true;
        }

        public override UICollectionViewLayoutAttributes LayoutAttributesForItem (NSIndexPath path)
        {
            return base.LayoutAttributesForItem (path);
        }
    }
}

