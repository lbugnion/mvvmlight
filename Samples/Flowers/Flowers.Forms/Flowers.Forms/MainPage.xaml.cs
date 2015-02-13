using Flowers.Data.ViewModel;
using Xamarin.Forms;

namespace Flowers.Forms
{
    public partial class MainPage : ContentPage
    {
        public MainViewModel Vm
        {
            get
            {
                return (MainViewModel)BindingContext;
            }
        }
        
        public MainPage()
        {
            InitializeComponent();

            BindingContext = ((ViewModelLocator)Application.Current.Resources["Locator"]).Main;

            FlowersList.ItemTapped += (s, e) =>
            {
                Vm.ShowDetailsCommand.Execute(e.Item);
            };
        }
    }
}
