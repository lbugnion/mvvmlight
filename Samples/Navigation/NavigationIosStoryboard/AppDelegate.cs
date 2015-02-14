using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using UIKit;

namespace NavigationIosStoryboard
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations
        public override UIWindow Window
        {
            get;
            set;
        }

        public const string Page2Key = "Page2";
        public const string Page3Key = "Page3";

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var nav = new NavigationService();
            nav.Initialize((UINavigationController)Window.RootViewController);
            nav.Configure(Page2Key, "Page2Controller");
            nav.Configure(Page3Key, "Page3Controller");

            SimpleIoc.Default.Register<INavigationService>(() => nav);
            return true;
        }
    }
}