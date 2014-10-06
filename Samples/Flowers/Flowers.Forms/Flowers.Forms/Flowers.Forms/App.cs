using System;
using System.Threading.Tasks;
using Flowers.Data.ViewModel;
using Flowers.Forms.Helpers;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Xamarin.Forms;

namespace Flowers.Forms
{
    public class App
    {
        public const string ShowCommentsPageKey = "ShowCommentsPage";

        private static ViewModelLocator _locator;
        private static NavigationPage _navPage;

        public static ViewModelLocator Locator
        {
            get
            {
                return _locator ?? (_locator = new ViewModelLocator());
            }
        }

        public static Page GetMainPage()
        {
            if (_navPage == null)
            {
                // First time initialization
                var nav = new NavigationService();
                nav.Configure(ViewModelLocator.DetailsPageKey, typeof(DetailsPage));
                nav.Configure(ViewModelLocator.AddCommentPageKey, typeof(AddCommentPage));
                nav.Configure(App.ShowCommentsPageKey, typeof(ShowCommentsPage));
                SimpleIoc.Default.Register<INavigationService>(() => nav);

                var dialog = new DialogService();
                SimpleIoc.Default.Register<IDialogService>(() => dialog);

                _navPage = new NavigationPage(new MainPage());

                nav.Initialize(_navPage);
                dialog.Initialize(_navPage);
            }

            return _navPage;
        }
    }
}
