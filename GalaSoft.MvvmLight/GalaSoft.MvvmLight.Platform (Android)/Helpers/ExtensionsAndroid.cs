// ****************************************************************************
// <copyright file="ExtensionsAndroid.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2016
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>19.01.2016</date>
// <project>GalaSoft.MvvmLight</project>
// <web>http://www.mvvmlight.net</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Android.Views;
using Android.Widget;

namespace GalaSoft.MvvmLight.Helpers
{
    /// <summary>
    /// Defines extension methods for Android only.
    /// </summary>
    ////[ClassInfo(typeof(Binding))]
    public static class ExtensionsAndroid
    {
        /// <summary>
        /// Creates a new <see cref="ObservableAdapter{T}"/> for a given <see cref="ObservableCollection{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the items contained in the <see cref="ObservableCollection{T}"/>.</typeparam>
        /// <param name="collection">The collection that the adapter will be created for.</param>
        /// <param name="getTemplateDelegate">A method taking an item's position in the list, the item itself,
        /// and a recycled Android View, and returning an adapted View for this item. Note that the recycled
        /// view might be null, in which case a new View must be inflated by this method.</param>
        /// <returns>A View adapted for the item passed as parameter.</returns>
        public static ObservableAdapter<T> GetAdapter<T>(
            this ObservableCollection<T> collection,
            Func<int, T, View, View> getTemplateDelegate)
        {
            return new ObservableAdapter<T>
            {
                DataSource = collection,
                GetTemplateDelegate = getTemplateDelegate
            };
        }

        /// <summary>
        /// Creates a new <see cref="ObservableAdapter{T}"/> for a given <see cref="IList{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the items contained in the <see cref="IList{T}"/>.</typeparam>
        /// <param name="list">The list that the adapter will be created for.</param>
        /// <param name="getTemplateDelegate">A method taking an item's position in the list, the item itself,
        /// and a recycled Android <see cref="View"/>, and returning an adapted View for this item. Note that the recycled
        /// View might be null, in which case a new View must be inflated by this method.</param>
        /// <returns>An adapter adapted to the collection passed in parameter..</returns>
        public static ObservableAdapter<T> GetAdapter<T>(
            this IList<T> list,
            Func<int, T, View, View> getTemplateDelegate)
        {
            return new ObservableAdapter<T>
            {
                DataSource = list,
                GetTemplateDelegate = getTemplateDelegate
            };
        }

        internal static string GetDefaultEventNameForControl(this Type type)
        {
            string eventName = null;

            if (type == typeof (CheckBox)
                || typeof (CheckBox).IsAssignableFrom(type))
            {
                eventName = "CheckedChange";
            }
            else if (type == typeof (Button)
                     || typeof (Button).IsAssignableFrom(type))
            {
                eventName = "Click";
            }

            return eventName;
        }
    }
}