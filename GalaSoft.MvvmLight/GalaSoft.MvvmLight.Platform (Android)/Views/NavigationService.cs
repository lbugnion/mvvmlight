// ****************************************************************************
// <copyright file="NavigationService.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2014
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>02.10.2014</date>
// <project>GalaSoft.MvvmLight</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Collections.Generic;
using Android.Content;

namespace GalaSoft.MvvmLight.Views
{
    /// <summary>
    /// Xamarin Android implementation of <see cref="INavigationService"/>.
    /// This implementation can be used in Xamarin Android applications (not Xamarin Forms).
    /// </summary>
    /// <remarks>For this navigation service to work properly, your Activities
    /// should derive from the <see cref="ActivityBase"/> class.</remarks>
    public class NavigationService : INavigationService
    {
        private const string ParameterKeyName = "ParameterKey";

        private readonly Dictionary<string, Type> _pagesByKey = new Dictionary<string, Type>();
        private readonly Dictionary<string, object> _parametersByKey = new Dictionary<string, object>();

        /// <summary>
        /// The key corresponding to the currently displayed page.
        /// </summary>
        public string CurrentPageKey
        {
            get;
            private set;
        }

        /// <summary>
        /// If possible, discards the current page and displays the previous page
        /// on the navigation stack.
        /// </summary>
        public void GoBack()
        {
            ActivityBase.GoBack();
        }

        /// <summary>
        /// Displays a new page corresponding to the given key. 
        /// Make sure to call the <see cref="Configure"/>
        /// method first.
        /// </summary>
        /// <param name="pageKey">The key corresponding to the page
        /// that should be displayed.</param>
        /// <exception cref="ArgumentException">When this method is called for 
        /// a key that has not been configured earlier.</exception>
        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        /// <summary>
        /// Displays a new page corresponding to the given key,
        /// and passes a parameter to the new page.
        /// Make sure to call the <see cref="Configure"/>
        /// method first.
        /// </summary>
        /// <param name="pageKey">The key corresponding to the page
        /// that should be displayed.</param>
        /// <param name="parameter">The parameter that should be passed
        /// to the new page.</param>
        /// <exception cref="ArgumentException">When this method is called for 
        /// a key that has not been configured earlier.</exception>
        public void NavigateTo(string pageKey, object parameter)
        {
            if (ActivityBase.CurrentActivity == null)
            {
                throw new InvalidOperationException("No CurrentActivity found");
            }

            lock (_pagesByKey)
            {
                if (!_pagesByKey.ContainsKey(pageKey))
                {
                    throw new ArgumentException(
                        string.Format(
                            "No such page: {0}. Did you forget to call NavigationService.Configure?",
                            pageKey),
                        "pageKey");
                }

                var intent = new Intent(ActivityBase.CurrentActivity, _pagesByKey[pageKey]);

                if (parameter != null)
                {
                    lock (_parametersByKey)
                    {
                        var guid = Guid.NewGuid().ToString();
                        _parametersByKey.Add(guid, parameter);
                        intent.PutExtra(ParameterKeyName, guid);
                    }
                }

                ActivityBase.CurrentActivity.StartActivity(intent);
                CurrentPageKey = pageKey;
            }
        }

        /// <summary>
        /// Adds a key/page pair to the navigation service.
        /// </summary>
        /// <remarks>For this navigation service to work properly, your Activities
        /// should derive from the <see cref="ActivityBase"/> class.</remarks>
        /// <param name="key">The key that will be used later
        /// in the <see cref="NavigateTo(string)"/> or <see cref="NavigateTo(string, object)"/> methods.</param>
        /// <param name="activityType">The type of the activity (page) corresponding to the key.</param>
        public void Configure(string key, Type activityType)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(key))
                {
                    _pagesByKey[key] = activityType;
                }
                else
                {
                    _pagesByKey.Add(key, activityType);
                }
            }
        }

        /// <summary>
        /// Allows a caller to get the navigation parameter corresponding 
        /// to the Intent parameter.
        /// </summary>
        /// <param name="intent">The <see cref="Android.App.Activity.Intent"/> 
        /// of the navigated page.</param>
        /// <returns>The navigation parameter. If no parameter is found,
        /// returns null.</returns>
        public object GetAndRemoveParameter(Intent intent)
        {
            if (intent == null)
            {
                throw new ArgumentNullException("intent", "This method must be called with a valid Activity intent");
            }

            var key = intent.GetStringExtra(ParameterKeyName);

            if (string.IsNullOrEmpty(key))
            {
                return null;
            }

            lock (_parametersByKey)
            {
                if (_parametersByKey.ContainsKey(key))
                {
                    return _parametersByKey[key];
                }

                return null;
            }
        }

        /// <summary>
        /// Allows a caller to get the navigation parameter corresponding 
        /// to the Intent parameter.
        /// </summary>
        /// <typeparam name="T">The type of the retrieved parameter.</typeparam>
        /// <param name="intent">The <see cref="Android.App.Activity.Intent"/> 
        /// of the navigated page.</param>
        /// <returns>The navigation parameter casted to the proper type.
        /// If no parameter is found, returns default(T).</returns>
        public T GetAndRemoveParameter<T>(Intent intent)
        {
            return (T)GetAndRemoveParameter(intent);
        }
    }
}