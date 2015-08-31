using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace NavigationDroid
{
    [Activity(Label = "NavigationDroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ActivityBase
    {
        public const string Page2Key = "Page2";
        public const string Page3Key = "Page3";

        private static bool _initialized;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            if (!_initialized)
            {
                _initialized = true;

                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

                var nav = new NavigationService();
                nav.Configure(Page2Key, typeof(Page2Activity));
                nav.Configure(Page3Key, typeof(Page3Activity));

                SimpleIoc.Default.Register<INavigationService>(() => nav);
            }

            var button = FindViewById<Button>(Resource.Id.MyButton);
            button.Click += (s, e) =>
            {
                var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                nav.NavigateTo(Page2Key);
            };
        }
    }
}

