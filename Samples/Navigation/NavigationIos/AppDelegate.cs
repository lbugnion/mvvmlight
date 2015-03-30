using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using UIKit;

namespace NavigationIos
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations
        UIWindow window;

        public const string Page2Key = "Page2";
        public const string Page3Key = "Page3";

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // create a new window instance based on the screen size
            window = new UIWindow(UIScreen.MainScreen.Bounds);

            // Add the Navigation Controller and initialize it
            var navController = new UINavigationController(new MainViewController());
            window.RootViewController = navController;

            // Initialize and register the Navigation Service
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var nav = new NavigationService();
            nav.Initialize(navController);
            nav.Configure(Page2Key, typeof(Page2Controller));
            nav.Configure(Page3Key, typeof(Page3Controller));

            SimpleIoc.Default.Register<INavigationService>(() => nav);

            // make the window visible
            window.MakeKeyAndVisible();

            return true;
        }
    }
}