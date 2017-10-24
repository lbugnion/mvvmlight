using DispatcherHelperSampleStd.Data.Helpers;
using DispatcherHelperSampleStd.Helpers;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using System.Windows;

namespace DispatcherHelperSampleStd
{
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
            SimpleIoc.Default.Register<IDispatcherHelper, DispatcherHelperEx>();
        }
    }
}
