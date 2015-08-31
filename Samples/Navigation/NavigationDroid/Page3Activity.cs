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
    [Activity(Label = "Page3")]
    public class Page3Activity : ActivityBase
    {
        public NavigationService Nav
        {
            get
            {
                return (NavigationService)ServiceLocator.Current
                    .GetInstance<INavigationService>();
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Page3);

            var button = FindViewById<Button>(Resource.Id.GoBackButton);
            button.Click += (s, e) => Nav.GoBack();

            var label = FindViewById<TextView>(Resource.Id.DisplayText);
            var param = Nav.GetAndRemoveParameter<string>(Intent);
            label.Text = param;
        }
    }
}