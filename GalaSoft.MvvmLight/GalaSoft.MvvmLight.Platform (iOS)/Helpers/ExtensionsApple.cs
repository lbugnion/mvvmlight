// ****************************************************************************
// <copyright file="ExtensionsApple.cs" company="GalaSoft Laurent Bugnion">
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
using Foundation;
using UIKit;

namespace GalaSoft.MvvmLight.Helpers
{
    /// <summary>
    /// Defines extension methods for iOS only.
    /// </summary>
    ////[ClassInfo(typeof(Binding))]
    public static class ExtensionsApple
    {
        /// <summary>
        /// Creates a new <see cref="ObservableTableViewController{T}"/> for a given <see cref="ObservableCollection{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the items contained in the collection.</typeparam>
        /// <param name="collection">The collection that the adapter will be created for.</param>
        /// <param name="createCellDelegate">A delegate to a method creating or reusing a <see cref="UITableViewCell"/>.
        /// The cell will then be passed to the bindCellDelegate
        /// delegate to set the elements' properties.</param>
        /// <param name="bindCellDelegate">A delegate to a method taking a <see cref="UITableViewCell"/>
        /// and setting its elements' properties according to the item passed as second parameter.
        /// The cell must be created first in the createCellDelegate delegate, unless a <see cref="reuseId"/> is passed to the method.</param>
        /// <param name="reuseId">A reuse identifier for the TableView's cells.</param>
        /// <returns>A controller adapted to the collection passed in parameter.</returns>
        public static ObservableTableViewController<T> GetController<T>(
            this ObservableCollection<T> collection,
            Func<NSString, UITableViewCell> createCellDelegate,
            Action<UITableViewCell, T, NSIndexPath> bindCellDelegate,
            string reuseId = null)
        {
            return new ObservableTableViewController<T>
            {
                DataSource = collection,
                CreateCellDelegate = createCellDelegate,
                BindCellDelegate = bindCellDelegate,
                ReuseId = reuseId,
            };
        }

        /// <summary>
        /// Creates a new <see cref="ObservableTableViewController{T}"/> for a given <see cref="IList{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the items contained in the list.</typeparam>
        /// <param name="list">The list that the adapter will be created for.</param>
        /// <param name="createCellDelegate">A delegate to a method creating or reusing a <see cref="UITableViewCell"/>.
        /// The cell will then be passed to the bindCellDelegate
        /// delegate to set the elements' properties.</param>
        /// <param name="bindCellDelegate">A delegate to a method taking a <see cref="UITableViewCell"/>
        /// and setting its elements' properties according to the item passed as second parameter.
        /// The cell must be created first in the createCellDelegate delegate, unless a <see cref="reuseId"/> is passed to the method.</param>
        /// <param name="reuseId">A reuse identifier for the TableView's cells.</param>
        /// <returns>A controller adapted to the collection passed in parameter.</returns>
        public static ObservableTableViewController<T> GetController<T>(
            this IList<T> list,
            Func<NSString, UITableViewCell> createCellDelegate,
            Action<UITableViewCell, T, NSIndexPath> bindCellDelegate,
            string reuseId = null)
        {
            return new ObservableTableViewController<T>
            {
                DataSource = list,
                CreateCellDelegate = createCellDelegate,
                BindCellDelegate = bindCellDelegate,
                ReuseId = reuseId,
            };
        }

        internal static string GetDefaultEventNameForControl(this Type type)
        {
            string eventName = null;

            if (type == typeof (UIButton)
                || typeof (UIButton).IsAssignableFrom(type))
            {
                eventName = "TouchUpInside";
            }
            else if (type == typeof (UIBarButtonItem)
                     || typeof (UIBarButtonItem).IsAssignableFrom(type))
            {
                eventName = "Clicked";
            }

            return eventName;
        }
    }
}