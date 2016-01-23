using System.Reflection;
using Foundation;
using MonoTouch.NUnit.UI;
using UIKit;

namespace GalaSoft.MvvmLight.Test
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        private TouchRunner _runner;

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            _runner = new TouchRunner(Window);

            // register every tests included in the main application/assembly
            _runner.Add(Assembly.GetExecutingAssembly());

            Window.RootViewController = new UINavigationController(_runner.GetViewController());

            // make the window visible
            Window.MakeKeyAndVisible();

            return true;
        }
    }
}