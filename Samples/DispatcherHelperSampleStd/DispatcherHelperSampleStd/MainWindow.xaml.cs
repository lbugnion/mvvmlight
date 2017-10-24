using DispatcherHelperSampleStd.Data.ViewModel;
using System.Windows;

namespace DispatcherHelperSampleStd
{
    public partial class MainWindow : Window
    {
        public MainViewModel Vm=> (MainViewModel)DataContext;

        public MainWindow()
        {
            InitializeComponent();

            Loaded += (s, e) => Vm.StartClock();
            Unloaded += (s, e) => Vm.StopClock();
        }
    }
}
