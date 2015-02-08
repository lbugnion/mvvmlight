// ****************************************************************************
// <copyright file="NavigationService.cs" company="GalaSoft Laurent Bugnion">
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
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using UIKit;

namespace GalaSoft.MvvmLight.Views
{
    /// <summary>
    /// Xamarin iOS implementation of <see cref="INavigationService"/>.
    /// This implementation can be used in Xamarin iOS applications (not Xamarin Forms).
    /// </summary>
    /// <remarks>For this navigation service to work properly, it should be initialized
    /// using the <see cref="Initialize"/> method, with the application's
    /// <see cref="UINavigationController"/>.</remarks>
    ////[ClassInfo(typeof(INavigationService))]
    public class NavigationService : INavigationService
    {
        /// <summary>
        /// The key that is returned by the <see cref="CurrentPageKey"/> property
        /// when the current UIViewController is the root controller.
        /// </summary>
        public const string RootPageKey = "-- ROOT --";

        /// <summary>
        /// The key that is returned by the <see cref="CurrentPageKey"/> property
        /// when the current UIViewController is not found.
        /// This can be the case when the navigation wasn't managed by this NavigationService,
        /// for example when it is directly triggered in the Storyboard.
        /// </summary>
        public const string UnknownPageKey = "-- UNKNOWN --";

        private readonly Dictionary<string, TypeActionOrKey> _pagesByKey = new Dictionary<string, TypeActionOrKey>();
        private UINavigationController _navigation;

        /// <summary>
        /// The key corresponding to the currently displayed page.
        /// </summary>
        public string CurrentPageKey
        {
            get
            {
                lock (_pagesByKey)
                {
                    if (_navigation.ViewControllers.Length == 0)
                    {
                        return UnknownPageKey;
                    }

                    if (_navigation.ViewControllers.Length == 1)
                    {
                        return RootPageKey;
                    }

                    var topController = _navigation.ViewControllers.Last();

                    var item = _pagesByKey.Values.FirstOrDefault(
                        i => i.ControllerType == topController.GetType());

                    if (item == null)
                    {
                        return UnknownPageKey;
                    }

                    var pair = _pagesByKey.First(i => i.Value == item);
                    return pair.Key;
                }
            }
        }

        /// <summary>
        /// If possible, discards the current page and displays the previous page
        /// on the navigation stack.
        /// </summary>
        public void GoBack()
        {
            _navigation.PopViewController(true);
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
                Exception creationException = null;
                var done = false;

                if (!_pagesByKey.ContainsKey(pageKey))
                {
                    throw new ArgumentException(
                        string.Format(
                            "No such page: {0}. Did you forget to call NavigationService.Configure?",
                            pageKey),
                        "pageKey");
                }

                var item = _pagesByKey[pageKey];
                UIViewController controller = null;

                if (item.CreateControllerAction != null)
                {
                    try
                    {
                        controller = item.CreateControllerAction(parameter);
                        done = true;
                    }
                    catch (Exception ex)
                    {
                        creationException = ex;
                    }
                }

                if (!string.IsNullOrEmpty(item.StoryboardControllerKey))
                {
                    if (_navigation == null)
                    {
                        throw new InvalidOperationException(
                            "Unable to navigate: Did you forget to call NavigationService.Initialize?");
                    }

                    if (_navigation.Storyboard == null)
                    {
                        throw new InvalidOperationException(
                            "Unable to navigate: No storyboard found");
                    }

                    try
                    {
                        controller = _navigation.Storyboard.InstantiateViewController(item.StoryboardControllerKey);
                        done = true;
                    }
                    catch (Exception ex)
                    {
                        creationException = ex;
                    }

                    if (parameter != null)
                    {
                        var casted = controller as ControllerBase;
                        if (casted != null)
                        {
                            casted.NavigationParameter = parameter;
                        }
                        else
                        {
                            throw new InvalidCastException(
                                string.Format(
                                    "Cannot cast {0} to {1}",
                                    controller.GetType().FullName,
                                    typeof(ControllerBase).FullName));
                        }
                    }
                }

                if (!done && item.ControllerType != null)
                {
                    try
                    {
                        controller = MakeController(item.ControllerType, parameter);

                        if (controller == null)
                        {
                            throw new InvalidOperationException(
                                "No suitable constructor found for page " + pageKey);
                        }
                    }
                    catch (Exception ex)
                    {
                        creationException = ex;
                    }
                }

                if (controller == null)
                {
                    throw new InvalidOperationException(
                        string.Format(
                            "Unable to create a controller for key {0}",
                            pageKey),
                            creationException);
                }

                if (item.ControllerType == null)
                {
                    item.ControllerType = controller.GetType();
                }

                _navigation.PushViewController(controller, true);
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
            var item = new TypeActionOrKey
            {
                ControllerType = controllerType
            };

            SaveConfigurationItem(key, item);
        }

        private void SaveConfigurationItem(string key, TypeActionOrKey item)
        {
            lock (_pagesByKey)
            {
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
            var item = new TypeActionOrKey
            {
                CreateControllerAction = createAction
            };

            SaveConfigurationItem(key, item);
        }

        /// <summary>
        /// Adds a key/page pair to the navigation service.
        /// This method should be used when working with Storyboard for the UI.
        /// </summary>
        /// <param name="key">The key that will be used later
        /// in the <see cref="NavigateTo(string)"/> or <see cref="NavigateTo(string, object)"/> methods.</param>
        /// <param name="storyboardId">The idea of the UIViewController
        /// in the Storyboard. Use the storyboardIdentifier/restorationIdentifier property
        /// in the *.storyboard document.</param>
        public void Configure(string key, string storyboardId)
        {
            var item = new TypeActionOrKey
            {
                StoryboardControllerKey = storyboardId
            };

            SaveConfigurationItem(key, item);
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

        private class TypeActionOrKey
        {
            public Type ControllerType;
            public Func<object, UIViewController> CreateControllerAction;
            public string StoryboardControllerKey;
        }
    }
}