using Flowers.Data.ViewModel;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace Flowers.Forms
{
    public partial class DetailsPage
    {
        public DetailsPage()
        {
        }

        public DetailsPage(FlowerViewModel flower)
        {
            InitializeComponent();

            BindingContext = flower;

            ShowCommentsButton.Clicked += (s, e) =>
            {
                var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                nav.NavigateTo(App.ShowCommentsPageKey, BindingContext);
            };
        }
    }
}
