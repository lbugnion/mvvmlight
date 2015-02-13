using Flowers.Data.ViewModel;
using Xamarin.Forms;

namespace Flowers.Forms
{
    public partial class ShowCommentsPage : ContentPage
    {
        public ShowCommentsPage(FlowerViewModel flower)
        {
            InitializeComponent();
            BindingContext = flower;
        }
    }
}
