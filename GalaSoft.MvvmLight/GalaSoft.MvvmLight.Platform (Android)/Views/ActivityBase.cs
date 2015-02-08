// ****************************************************************************
// <copyright file="ActivityBase.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2015
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>02.10.2014</date>
// <project>GalaSoft.MvvmLight</project>
// <web>http://www.mvvmlight.net</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using Android.App;

namespace GalaSoft.MvvmLight.Views
{
    /// <summary>
    /// A base class for Activities that allow the <see cref="NavigationService"/>
    /// to keep track of the navigation journal.
    /// </summary>
    ////[ClassInfo(typeof(INavigationService))]
    public class ActivityBase : Activity
    {
        /// <summary>
        /// The activity that is currently in the foreground.
        /// </summary>
        public static ActivityBase CurrentActivity
        {
            get;
            private set;
        }

        /// <summary>
        /// If possible, discards the current page and displays the previous page
        /// on the navigation stack.
        /// </summary>
        public static void GoBack()
        {
            if (CurrentActivity != null)
            {
                CurrentActivity.OnBackPressed();
            }
        }

        /// <summary>
        /// Overrides <see cref="Activity.OnDestroy"/>. If you override
        /// this method in your own Activities, make sure to call
        /// base.OnDestroy to allow the <see cref="NavigationService"/>
        /// to work properly.
        /// </summary>
        protected override void OnDestroy()
        {
            base.OnDestroy();
            Cleanup();
        }

        /// <summary>
        /// Overrides <see cref="Activity.OnPause"/>. If you override
        /// this method in your own Activities, make sure to call
        /// base.OnPause to allow the <see cref="NavigationService"/>
        /// to work properly.
        /// </summary>
        protected override void OnPause()
        {
            base.OnPause();
            Cleanup();
        }

        /// <summary>
        /// Overrides <see cref="Activity.OnResume"/>. If you override
        /// this method in your own Activities, make sure to call
        /// base.OnResume to allow the <see cref="NavigationService"/>
        /// to work properly.
        /// </summary>
        protected override void OnResume()
        {
            CurrentActivity = this;

            if (string.IsNullOrEmpty(ActivityKey))
            {
                ActivityKey = NextPageKey;
                NextPageKey = null;
            }

            base.OnResume();
        }

        private void Cleanup()
        {
            if (CurrentActivity == this)
            {
                CurrentActivity = null;
            }
        }

        internal string ActivityKey
        {
            get;
            private set;
        }

        internal static string NextPageKey
        {
            get;
            set;
        }
    }
}