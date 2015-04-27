using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using $safeprojectname$.ViewModel;
using UIKit;

namespace $safeprojectname$
{
    public class Application
    {
        private static ViewModelLocator _locator;

        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }

        public static ViewModelLocator Locator
        {
            get
            {
                return _locator ?? (_locator = new ViewModelLocator());
            }
        }
    }
}