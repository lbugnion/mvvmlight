using Flowers.Data.ViewModel;
using Xamarin.Forms;

namespace Flowers.Forms
{
    public partial class AddCommentPage : ContentPage
    {
        public FlowerViewModel Vm
        {
            get
            {
                return (FlowerViewModel)BindingContext;
            }
        }

        public AddCommentPage(FlowerViewModel flower)
        {
            InitializeComponent();
            BindingContext = flower;
        }
    }
}
