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
using System.Linq;
using System.Reflection;
using MonoTouch.UIKit;

namespace GalaSoft.MvvmLight.Views
{
    /// <summary>
    /// Xamarin iOS implementation of <see cref="INavigationService"/>.
    /// This implementation can be used in Xamarin iOS applications (not Xamarin Forms).
    /// </summary>
    /// <remarks>For this navigation service to work properly, it should be initialized
    /// using the <see cref="Initialize"/> method, with the application's
    /// <see cref="UINavigationController"/>.</remarks>
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<string, TypeOrAction> _pagesByKey = new Dictionary<string, TypeOrAction>();
        private UINavigationController _navigation;

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
            _navigation.PopViewControllerAnimated(true);
        }

        /// <summary>
        /// Displays a new page corresponding to the given key. 
        /// Make sure to call the <see cref="Configure(string, Type)"/>
        /// or <see cref="Configure(string, Func{object,UIViewController})"/>
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
        /// and passes a parameter to the new page's constructor.
        /// Make sure to call the <see cref="Configure(string, Type)"/>
        /// or <see cref="Configure(string, Func{object,UIViewController})"/>
        /// method first.
        /// </summary>
        /// <param name="pageKey">The key corresponding to the page
        /// that should be displayed.</param>
        /// <param name="parameter">The parameter that should be passed
        /// to the new page's constructor.</param>
        /// <exception cref="ArgumentException">When this method is called for 
        /// a key that has not been configured earlier.</exception>
        /// <exception cref="InvalidOperationException">When this method is called for 
        /// a page that doesn't have a suitable constructor (i.e.
        /// a constructor with a parameter corresponding to the
        /// navigation parameter's type).</exception>
        public void NavigateTo(string pageKey, object parameter)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(pageKey))
                {
                    var item = _pagesByKey[pageKey];
                    UIViewController controller = null;

                    if (item.ControllerType != null)
                    {
                        controller = MakeController(item.ControllerType, parameter);

                        if (controller == null)
                        {
                            throw new InvalidOperationException(
                                "No suitable constructor found for page " + pageKey);
                        }
                    }

                    if (item.CreateControllerAction != null)
                    {
                        controller = item.CreateControllerAction(parameter);
                    }

                    _navigation.PushViewController(controller, true);
                    CurrentPageKey = pageKey;
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(
                            "No such page: {0}. Did you forget to call NavigationService.Configure?",
                            pageKey),
                        "pageKey");
                }
            }
        }

        /// <summary>
        /// Adds a key/page pair to the navigation service.
        /// This method will create a new controller on demand, using
        /// reflection. You can use <see cref="Configure(string, Func{object,UIViewController})"/>
        /// if you need more fine-grained control over the controller's creation.
        /// </summary>
        /// <param name="key">The key that will be used later
        /// in the <see cref="NavigateTo(string)"/> or <see cref="NavigateTo(string, object)"/> methods.</param>
        /// <param name="controllerType">The type of the controller corresponding to the key.</param>
        public void Configure(string key, Type controllerType)
        {
            lock (_pagesByKey)
            {
                var item = new TypeOrAction
                {
                    ControllerType = controllerType
                };

                if (_pagesByKey.ContainsKey(key))
                {
                    _pagesByKey[key] = item;
                }
                else
                {
                    _pagesByKey.Add(key, item);
                }
            }
        }

        /// <summary>
        /// Adds a key/page pair to the navigation service.
        /// This method allows the caller to have fine grained control over the controller's
        /// creation.
        /// </summary>
        /// <param name="key">The key that will be used later
        /// in the <see cref="NavigateTo(string)"/> or <see cref="NavigateTo(string, object)"/> methods.</param>
        /// <param name="createAction">A Func returning the controller corresponding
        /// to the given key.</param>
        public void Configure(string key, Func<object, UIViewController> createAction)
        {
            lock (_pagesByKey)
            {
                var item = new TypeOrAction
                {
                    CreateControllerAction = createAction
                };

                if (_pagesByKey.ContainsKey(key))
                {
                    _pagesByKey[key] = item;
                }
                else
                {
                    _pagesByKey.Add(key, item);
                }
            }
        }

        /// <summary>
        /// Initialized the navigation service. This method must be called
        /// before the <see cref="NavigateTo(string)"/> or
        /// <see cref="NavigateTo(string, object)"/> methods are called.
        /// </summary>
        /// <param name="navigation">The application's navigation controller.</param>
        public void Initialize(UINavigationController navigation)
        {
            _navigation = navigation;
        }

        private UIViewController MakeController(Type controllerType, object parameter)
        {
            ConstructorInfo constructor;
            object[] parameters;

            if (parameter == null)
            {
                constructor = controllerType.GetTypeInfo()
                    .DeclaredConstructors
                    .FirstOrDefault(c => !c.GetParameters().Any());

                parameters = new object[]
                {
                };
            }
            else
            {
                constructor = controllerType.GetTypeInfo()
                    .DeclaredConstructors
                    .FirstOrDefault(
                        c =>
                        {
                            var p = c.GetParameters();
                            return p.Count() == 1
                                   && p[0].ParameterType == parameter.GetType();
                        });

                parameters = new[]
                {
                    parameter
                };
            }

            if (constructor == null)
            {
                return null;
            }

            var controller = constructor.Invoke(parameters) as UIViewController;
            return controller;
        }

        private struct TypeOrAction
        {
            public Type ControllerType;
            public Func<object, UIViewController> CreateControllerAction;
        }
    }
}