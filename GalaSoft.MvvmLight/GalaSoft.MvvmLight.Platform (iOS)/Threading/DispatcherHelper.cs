// ****************************************************************************
// <copyright file="DispatcherHelper.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2015
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>25.03.2015</date>
// <project>GalaSoft.MvvmLight</project>
// <web>http://www.mvvmlight.net</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// <LastBaseLevel>BL0004</LastBaseLevel>
// ****************************************************************************

using System;
using System.Text;

////using GalaSoft.Utilities.Attributes;
using Foundation;

namespace GalaSoft.MvvmLight.Threading
{
    /// <summary>
    /// Helper class for dispatcher operations on the UI thread in Android.
    /// </summary>
    //// [ClassInfo(typeof(DispatcherHelper))]
    public static class DispatcherHelper
    {
        /// <summary>
        /// Gets a reference to a NSObject running on the UI thread, after the
        /// <see cref="Initialize" /> method has been called on that thread.
        /// </summary>
        public static NSObject MainThreadContext
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
        /// <see cref="MainThreadContext" /></para>.
        /// </summary>
        /// <param name="action">The action that will be executed on the UI
        /// thread.</param>
        // ReSharper disable InconsistentNaming
        public static void CheckBeginInvokeOnUI(Action action)
        // ReSharper restore InconsistentNaming
        {
            if (action == null)
            {
                return;
            }

            CheckDispatcher();
            MainThreadContext.InvokeOnMainThread(action);
        }

        private static void CheckDispatcher()
        {
            if (MainThreadContext == null)
            {
                var error = new StringBuilder("The DispatcherHelper is not initialized.");
                error.AppendLine();
                error.Append("Call DispatcherHelper.Initialize(app) at the end of AppDelegate.FinishedLaunching.");

                throw new InvalidOperationException(error.ToString());
            }
        }

        /// <summary>
        /// This method should be called once on the UI thread to ensure that
        /// the <see cref="MainThreadContext" /> property is initialized.
        /// </summary>
        public static void Initialize(NSObject mainThreadObject)
        {
            if (MainThreadContext != null)
            {
                return;
            }

            MainThreadContext = mainThreadObject;
        }

        /// <summary>
        /// Resets the class by deleting the <see cref="MainThreadContext"/>
        /// </summary>
        public static void Reset()
        {
            MainThreadContext = null;
        }
    }
}