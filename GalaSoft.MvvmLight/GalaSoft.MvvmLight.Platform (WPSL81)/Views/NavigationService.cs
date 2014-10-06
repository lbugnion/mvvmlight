// ****************************************************************************
// <copyright file="NavigationService.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2014
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>02.10.2014</date>
// <project>GalaSoft.MvvmLight.Extras</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace GalaSoft.MvvmLight.Views
{
    /// <summary>
    /// Windows Phone Silverlight implementation of <see cref="INavigationService"/>.
    /// This implementation can be used in Windows Phone applications (not Xamarin Forms).
    /// </summary>
    public class NavigationService : INavigationService
    {
        /// <summary>
        /// Use this key name to retrieve the navigation parameter.
        /// </summary>
        public const string ParameterKeyName = "ParameterKey";

        private static readonly Dictionary<string, Uri> PagesByKey = new Dictionary<string, Uri>();
        private static readonly Dictionary<string, object> ParametersByKey = new Dictionary<string, object>();

        private PhoneApplicationFrame _mainFrame;

        /// <summary>
        /// Occurs when a page navigation has happened.
        /// </summary>
        public event NavigatedEventHandler Navigated;

        /// <summary>
        /// Occurs when a page navigation is going to happen.
        /// </summary>
        public event NavigatingCancelEventHandler Navigating;

        /// <summary>
        /// The key corresponding to the currently displayed page.
        /// </summary>
        public string CurrentPageKey
        {
            get
            {
                lock (PagesByKey)
                {
                    var currentUri = _mainFrame.CurrentSource;

                    if (PagesByKey.Any(p => p.Value == currentUri))
                    {
                        return PagesByKey.FirstOrDefault(p => p.Value == currentUri).Key;
                    }

                    return null;
                }
            }
        }

        /// <summary>
        /// If possible, discards the current page and displays the previous page
        /// on the navigation stack.
        /// </summary>
        public void GoBack()
        {
            if (EnsureMainFrame()
                && _mainFrame.CanGoBack)
            {
                _mainFrame.GoBack();
            }
        }

        /// <summary>
        /// Displays a new page corresponding to the given key.
        /// Make sure to call the <see cref="Configure"/> method first.
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
        /// Make sure to call the <see cref="Configure"/> method first.
        /// </summary>
        /// <param name="pageKey">The key corresponding to the page
        /// that should be displayed.</param>
        /// <param name="parameter">The parameter that should be passed
        /// to the new page.</param>
        /// <exception cref="ArgumentException">When this method is called for 
        /// a key that has not been configured earlier.</exception>
        public void NavigateTo(string pageKey, object parameter)
        {
            lock (PagesByKey)
            {
                Uri uri;

                if (PagesByKey.ContainsKey(pageKey))
                {
                    uri = PagesByKey[pageKey];
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(
                            "No such page: {0}. Did you forget to call NavigationService.Configure?",
                            pageKey),
                        "pageKey");
                }

                if (parameter != null)
                {
                    lock (ParametersByKey)
                    {
                        var guid = Guid.NewGuid().ToString();
                        ParametersByKey.Add(guid, parameter);

                        uri = uri.OriginalString.IndexOf("?", StringComparison.InvariantCulture) > -1 
                            ? new Uri(uri.OriginalString + "&" + ParameterKeyName + "=" + guid, UriKind.Relative) 
                            : new Uri(uri.OriginalString + "?" + ParameterKeyName + "=" + guid, UriKind.Relative);
                    }
                }

                NavigateTo(uri);
            }
        }

        /// <summary>
        /// Adds a key/page pair to the navigation service.
        /// </summary>
        /// <param name="key">The key that will be used later
        /// in the <see cref="NavigateTo(string)"/> or <see cref="NavigateTo(string, object)"/> methods.</param>
        /// <param name="targetUri">The URI of the page corresponding to the key.</param>
        public void Configure(string key, Uri targetUri)
        {
            lock (PagesByKey)
            {
                if (targetUri.OriginalString.IndexOf(
                    string.Format("?{0}=", ParameterKeyName),
                    StringComparison.InvariantCulture) > -1
                    || targetUri.OriginalString.IndexOf(
                        string.Format("&{0}=", ParameterKeyName),
                        StringComparison.InvariantCulture) > -1)
                {
                    throw new InvalidOperationException(ParameterKeyName + " is reserved for the NavigationService");
                }

                if (PagesByKey.ContainsKey(key))
                {
                    PagesByKey[key] = targetUri;
                }
                else
                {
                    PagesByKey.Add(key, targetUri);
                }
            }
        }

        /// <summary>
        /// Allows a caller to get the navigation parameter corresponding 
        /// to the NavigationContext parameter.
        /// </summary>
        /// <param name="context">The <see cref="System.Windows.Navigation.NavigationContext"/> 
        /// of the navigated page.</param>
        /// <returns>The navigation parameter. If no parameter is found,
        /// returns null.</returns>
        public object GetAndRemoveParameter(NavigationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context", "This method must be called with a valid NavigationContext");
            }

            if (!context.QueryString.ContainsKey(ParameterKeyName))
            {
                return null;
            }

            var key = context.QueryString[ParameterKeyName];
                
            lock (ParametersByKey)
            {
                if (ParametersByKey.ContainsKey(key))
                {
                    return ParametersByKey[key];
                }

                return null;
            }
        }

        /// <summary>
        /// Allows a caller to get the navigation parameter corresponding 
        /// to the NavigationContext parameter.
        /// </summary>
        /// <typeparam name="T">The type of the retrieved parameter.</typeparam>
        /// <param name="context">The <see cref="System.Windows.Navigation.NavigationContext"/> 
        /// of the navigated page.</param>
        /// <returns>The navigation parameter casted to the proper type.
        /// If no parameter is found, returns default(T).</returns>
        public T GetAndRemoveParameter<T>(NavigationContext context)
        {
            return (T)GetAndRemoveParameter(context);
        }

        private bool EnsureMainFrame()
        {
            if (_mainFrame != null)
            {
                return true;
            }

            _mainFrame = Application.Current.RootVisual as PhoneApplicationFrame;

            if (_mainFrame != null)
            {
                // Could be null if the app runs inside a design tool
                _mainFrame.Navigating += (s, e) =>
                {
                    var handler = Navigating;

                    if (handler != null)
                    {
                        handler(s, e);
                    }
                };

                _mainFrame.Navigated += (s, e) =>
                {
                    var handler = Navigated;

                    if (handler != null)
                    {
                        handler(s, e);
                    }
                };

                return true;
            }

            return false;
        }

        private void NavigateTo(Uri pageUri)
        {
            if (EnsureMainFrame())
            {
                _mainFrame.Navigate(pageUri);
            }
        }
    }
}