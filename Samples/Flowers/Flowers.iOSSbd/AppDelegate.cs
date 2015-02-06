using Flowers.Data.ViewModel;
using Foundation;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using UIKit;

namespace Flowers.iOSSbd
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        public const string SeeCommentsPageKey = "SeeComments";

        public override UIWindow Window
        {
            get;
            set;
        }

        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            var nav = new NavigationService();
            nav.Configure(
                ViewModelLocator.DetailsPageKey,
                "Details");
            nav.Configure(
                SeeCommentsPageKey,
                "SeeComments");
            nav.Configure(
                ViewModelLocator.AddCommentPageKey,
                "AddComment");

            nav.Initialize(Window.RootViewController as UINavigationController);

            SimpleIoc.Default.Register<INavigationService>(() => nav);
            SimpleIoc.Default.Register<IDialogService, DialogService>();

            return true;
        }
    }
}