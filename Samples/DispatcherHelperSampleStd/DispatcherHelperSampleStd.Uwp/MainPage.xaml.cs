using DispatcherHelperSampleStd.Data.ViewModel;
using Windows.UI.Xaml.Controls;

namespace DispatcherHelperSampleStd.Uwp
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel Vm => (MainViewModel)DataContext;

        public MainPage()
        {
            InitializeComponent();

            Loaded += (s, e) => Vm.StartClock();
            Unloaded += (s, e) => Vm.StopClock();
        }
    }
}
