using System.Windows;
using GalaSoft.MvvmLight.Threading;

namespace ProjectForTemplate
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            DispatcherExtensions.Initialize();
        }
    }
}
