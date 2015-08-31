using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace NavigationDroid
{
    [Activity(Label = "Page2")]
    public class Page2Activity : ActivityBase
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Page2);

            var button = FindViewById<Button>(Resource.Id.NavigateButton);
            button.Click += (s, e) =>
            {
                var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                nav.NavigateTo(
                    MainActivity.Page3Key,
                    "Hello Xamarin " + DateTime.Now.ToString("HH:mm:ss"));
            };
        }

        protected override void OnResume()
        {
            base.OnResume();
            var nav = ServiceLocator.Current.GetInstance<INavigationService>();
            Console.WriteLine("Current page key: " + nav.CurrentPageKey);
        }
    }
}