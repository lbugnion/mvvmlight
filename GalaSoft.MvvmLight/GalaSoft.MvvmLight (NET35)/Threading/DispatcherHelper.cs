// ****************************************************************************
// <copyright file="DispatcherHelper.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2013
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>29.11.2009</date>
// <project>GalaSoft.MvvmLight</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// <LastBaseLevel>BL0004</LastBaseLevel>
// ****************************************************************************

using System;
using System.Text;

#if NETFX_CORE
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.Foundation;
#else
using System.Windows.Threading;

#if SILVERLIGHT
using System.Windows;
#endif
#endif

////using GalaSoft.Utilities.Attributes;

namespace GalaSoft.MvvmLight.Threading
{
    /// <summary>
    /// Helper class for dispatcher operations on the UI thread.
    /// </summary>
    //// [ClassInfo(typeof(DispatcherHelper),
    ////  VersionString = "4.2.7",
    ////  DateString = "201309262235",
    ////  Description = "Helper class for dispatcher operations on the UI thread.",
    ////  UrlContacts = "http://www.galasoft.ch/contact_en.html",
    ////  Email = "laurent@galasoft.ch")]
    public static class DispatcherHelper
    {
        /// <summary>
        /// Gets a reference to the UI thread's dispatcher, after the
        /// <see cref="Initialize" /> method has been called on the UI thread.
        /// </summary>
#if NETFX_CORE
        public static CoreDispatcher UIDispatcher
#else
        public static Dispatcher UIDispatcher
#endif
        {
            get;
            private set;
        }

        /// <summary>
        /// Executes an action on the UI thread. If this method is called
        /// from the UI thread, the action is executed immendiately. If the
        /// method is called from another thread, the action will be enqueued
        /// on the UI thread's dispatcher and executed asynchronously.
        /// <para>For additional operations on the UI thread, you can get a
        /// reference to the UI thread's dispatcher thanks to the property
        /// <see cref="UIDispatcher" /></para>.
        /// </summary>
        /// <param name="action">The action that will be executed on the UI
        /// thread.</param>
        public static void CheckBeginInvokeOnUI(Action action)
        {
            if (action == null)
            {
                return;
            }

            CheckDispatcher();

#if NETFX_CORE
            if (UIDispatcher.HasThreadAccess)
#else
            if (UIDispatcher.CheckAccess())
#endif
            {
                action();
            }
            else
            {
#if NETFX_CORE
                UIDispatcher.RunAsync(CoreDispatcherPriority.Normal,  () => action());
#else
                UIDispatcher.BeginInvoke(action);
#endif
            }
        }

        private static void CheckDispatcher()
        {
            if (UIDispatcher == null)
            {
                var error = new StringBuilder("The DispatcherHelper is not initialized.");
                error.AppendLine();

#if SILVERLIGHT
#if WINDOWS_PHONE
                error.Append("Call DispatcherHelper.Initialize() at the end of App.InitializePhoneApplication.");
#else
                error.Append("Call DispatcherHelper.Initialize() in Application_Startup (App.xaml.cs).");
#endif
#elif NETFX_CORE
                error.Append("Call DispatcherHelper.Initialize() at the end of App.OnLaunched.");
#else
                error.Append("Call DispatcherHelper.Initialize() in the static App constructor.");
#endif

                throw new InvalidOperationException(error.ToString());
            }
        }

#if NETFX_CORE
        /// <summary>
        /// Invokes an action asynchronously on the UI thread.
        /// </summary>
        /// <param name="action">The action that must be executed.</param>
        /// <returns>The object that provides handlers for the completed async event dispatch.</returns>
        public static IAsyncAction RunAsync(Action action)
#else
        /// <summary>
        /// Invokes an action asynchronously on the UI thread.
        /// </summary>
        /// <param name="action">The action that must be executed.</param>
        /// <returns>An object, which is returned immediately after BeginInvoke is called, that can be used to interact
        ///  with the delegate as it is pending execution in the event queue.</returns>
        public static DispatcherOperation RunAsync(Action action)
#endif
        {
            CheckDispatcher();

#if NETFX_CORE
            return UIDispatcher.RunAsync(CoreDispatcherPriority.Normal, () => action());
#else
            return UIDispatcher.BeginInvoke(action);
#endif
        }

        /// <summary>
        /// This method should be called once on the UI thread to ensure that
        /// the <see cref="UIDispatcher" /> property is initialized.
        /// <para>In a Silverlight application, call this method in the
        /// Application_Startup event handler, after the MainPage is constructed.</para>
        /// <para>In WPF, call this method on the static App() constructor.</para>
        /// </summary>
        public static void Initialize()
        {
#if SILVERLIGHT
            if (UIDispatcher != null)
#else
#if NETFX_CORE
            if (UIDispatcher != null)
#else
            if (UIDispatcher != null
                && UIDispatcher.Thread.IsAlive)
#endif
#endif
            {
                return;
            }

#if NETFX_CORE
            UIDispatcher = Window.Current.Dispatcher;
#else
#if SILVERLIGHT
            UIDispatcher = Deployment.Current.Dispatcher;
#else
            UIDispatcher = Dispatcher.CurrentDispatcher;
#endif
#endif
        }

        /// <summary>
        /// Resets the class by deleting the <see cref="UIDispatcher"/>
        /// </summary>
        public static void Reset()
        {
            UIDispatcher = null;
        }
    }
}