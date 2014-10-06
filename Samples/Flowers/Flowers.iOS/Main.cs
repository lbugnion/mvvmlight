using Flowers.Data.ViewModel;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using MonoTouch.UIKit;

namespace Flowers
{
    public class Application
    {
        private static ViewModelLocator _locator;

        public static ViewModelLocator Locator
        {
            get
            {
                if (_locator == null)
                {
                    // First time initialization
                    var nav = new NavigationService();
                    nav.Configure(
                        ViewModelLocator.DetailsPageKey,
                        typeof(DetailsViewController));
                    nav.Configure(
                        ViewModelLocator.AddCommentPageKey,
                        typeof(AddCommentViewController));

                    SimpleIoc.Default.Register<INavigationService>(() => nav);
                    SimpleIoc.Default.Register<IDialogService, DialogService>();

                    _locator = new ViewModelLocator();
                }
                
                return _locator;
            }
        }

        private static void Main(string[] args)
        {
            UIApplication.Main(args, null, "AppDelegate");
        }

        public static class Colors
        {
            public static readonly UIColor HighlightColor = UIColor.FromRGB(250, 40, 212);
            public static readonly UIColor MainBackgroundColor = UIColor.White;
            public static readonly UIColor TextInputBackgroundColor = UIColor.FromRGB(200, 200, 200);
        }

        public static class Fonts
        {
            public static readonly UIFont TinyFont = UIFont.FromName(UIFont.PreferredBody.Name, 12);
            public static readonly UIFont TitleFont = UIFont.FromName(UIFont.PreferredBody.Name, 24);
        }
    }
}