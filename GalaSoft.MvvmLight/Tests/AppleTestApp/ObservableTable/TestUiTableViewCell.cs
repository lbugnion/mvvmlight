using Foundation;
using UIKit;

namespace GalaSoft.MvvmLight.Test.ObservableTable
{
    public class TestUiTableViewCell : UITableViewCell
    {
        public NSString ReuseId
        {
            get;
            private set;
        }

        public TestUiTableViewCell(NSString reuseId)
        {
            ReuseId = reuseId;
        }
    }
}