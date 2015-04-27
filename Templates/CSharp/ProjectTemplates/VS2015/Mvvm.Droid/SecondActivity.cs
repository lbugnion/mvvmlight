using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace $safeprojectname$
{
    [Activity(Label = "Second Page")]
    public partial class SecondActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "Second" layout resource
            SetContentView(Resource.Layout.Second);

            // Retrieve navigation parameter and set as current "DataContext"
            var nav = (NavigationService)ServiceLocator.Current.GetInstance<INavigationService>();
            var p = nav.GetAndRemoveParameter<string>(Intent);

            if (string.IsNullOrEmpty(p))
            {
                NavigationParameterText.Text = "No navigation parameter";
            }
            else
            {
                NavigationParameterText.Text = "Navigation parameter: " + p;
            }

            GoBackButton.Click += (s, e) => nav.GoBack();
        }
    }
}