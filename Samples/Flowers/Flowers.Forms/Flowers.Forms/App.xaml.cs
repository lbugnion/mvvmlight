using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flowers.Data.ViewModel;
using Flowers.Forms.Helpers;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Xamarin.Forms;

namespace Flowers.Forms
{
    public partial class App : Application
    {
        public const string ShowCommentsPageKey = "ShowCommentsPage";

        public App()
        {
            InitializeComponent();

            // First time initialization
            var nav = new NavigationService();
            nav.Configure(ViewModelLocator.DetailsPageKey, typeof(DetailsPage));
            nav.Configure(ViewModelLocator.AddCommentPageKey, typeof(AddCommentPage));
            nav.Configure(App.ShowCommentsPageKey, typeof(ShowCommentsPage));
            SimpleIoc.Default.Register<INavigationService>(() => nav);

            var dialog = new DialogService();
            SimpleIoc.Default.Register<IDialogService>(() => dialog);

            var navPage = new NavigationPage(new MainPage());

            nav.Initialize(navPage);
            dialog.Initialize(navPage);

            // The root page of your application
            MainPage = navPage;
        }
    }
}
