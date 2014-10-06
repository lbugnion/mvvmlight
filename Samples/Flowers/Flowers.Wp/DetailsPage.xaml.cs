using System.Windows.Navigation;

namespace Flowers
{
    public partial class DetailsPage
    {
        public DetailsPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            DataContext = GlobalNavigation.GetAndRemoveParameter(NavigationContext);
        }
    }
}