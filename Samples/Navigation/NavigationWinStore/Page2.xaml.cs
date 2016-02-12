using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace NavigationWinStore
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();

            NavigateWithParameterButton.Click += (s, e) =>
            {
                var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                nav.NavigateTo(
                    App.Page3Key,
                    "Hello Xamarin " + DateTime.Now.ToString("HH:mm:ss"));
            };

            GoBackButton.Click += (s, e) =>
            {
                var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                nav.GoBack();
            };
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var nav = ServiceLocator.Current.GetInstance<INavigationService>();
            Debug.WriteLine("Current page: " + nav.CurrentPageKey);
        }
    }
}
