using Flowers.Data.ViewModel;

namespace Flowers.Forms
{
    public partial class MainPage
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

            BindingContext = App.Locator.Main;

            FlowersList.ItemTapped += (s, e) =>
            {
                Vm.ShowDetailsCommand.Execute(e.Item);
            };
        }
    }
}
