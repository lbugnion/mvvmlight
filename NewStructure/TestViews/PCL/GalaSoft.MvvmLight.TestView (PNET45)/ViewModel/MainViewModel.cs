using System.Diagnostics;
using System.Windows;

namespace GalaSoft.MvvmLight.TestView.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Debug.WriteLine(IsInDesignMode);
        }
    }
}