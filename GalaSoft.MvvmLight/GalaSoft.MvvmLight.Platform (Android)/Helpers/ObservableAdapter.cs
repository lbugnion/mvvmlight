// ****************************************************************************
// <copyright file="ObservableAdapter.cs" company="GalaSoft Laurent Bugnion">
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
using System.Collections.Specialized;
using Android.Views;
using Android.Widget;

namespace GalaSoft.MvvmLight.Helpers
{
    /// <summary>
    /// A <see cref="BaseAdapter{T}"/> that can be used with an Android ListView. After setting
    /// the <see cref="DataSource"/> and the <see cref="GetTemplateDelegate"/> properties, the adapter is
    /// suitable for a list control. If the DataSource is an <see cref="INotifyCollectionChanged"/>,
    /// changes to the collection will be observed and the UI will automatically be updated.
    /// </summary>
    /// <typeparam name="T">The type of the items contained in the <see cref="DataSource"/>.</typeparam>
    ////[ClassInfo(typeof(ObservableAdapter<T>),
    ////    VersionString = "1.0.0",
    ////    DateString = "201410012233",
    ////    UrlContacts = "http://www.galasoft.ch/contact_en.html",
    ////    Email = "laurent@galasoft.ch")]
    public class ObservableAdapter<T> : BaseAdapter<T>
    {
        private IList<T> _list;
        private INotifyCollectionChanged _notifier;

        /// <summary>
        /// Gets the number of items in the DataSource.
        /// </summary>
        public override int Count
        {
            get
            {
                return _list == null ? 0 : _list.Count;
            }
        }

        /// <summary>
        /// Gets or sets the list containing the items to be represented in the list control.
        /// </summary>
        public IList<T> DataSource
        {
            get
            {
                return _list;
            }
            set
            {
                if (Equals(_list, value))
                {
                    return;
                }

                if (_notifier != null)
                {
                    _notifier.CollectionChanged -= NotifierCollectionChanged;
                }

                _list = value;
                _notifier = _list as INotifyCollectionChanged;

                if (_notifier != null)
                {
                    _notifier.CollectionChanged += NotifierCollectionChanged;
                }
            }
        }

        /// <summary>
        /// Gets and sets a method taking an item's position in the list, the item itself,
        /// and a recycled Android View, and returning an adapted View for this item. Note that the recycled
        /// view might be null, in which case a new View must be inflated by this method.
        /// </summary>
        public Func<int, T, View, View> GetTemplateDelegate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the item corresponding to the index in the DataSource.
        /// </summary>
        /// <param name="index">The index of the item that needs to be returned.</param>
        /// <returns>The item corresponding to the index in the DataSource</returns>
        public override T this[int index]
        {
            get
            {
                return _list == null ? default(T) : _list[index];
            }
        }

        /// <summary>
        /// Returns a unique ID for the item corresponding to the position parameter.
        /// In this implementation, the method always returns the position itself.
        /// </summary>
        /// <param name="position">The position of the item for which the ID needs to be returned.</param>
        /// <returns>A unique ID for the item corresponding to the position parameter.</returns>
        public override long GetItemId(int position)
        {
            return position;
        }

        /// <summary>
        /// Prepares the view (template) for the item corresponding to the position
        /// in the DataSource. This method calls the <see cref="GetTemplateDelegate"/> method so that the caller
        /// can create (if necessary) and adapt the template for the corresponding item.
        /// </summary>
        /// <param name="position">The position of the item in the DataSource.</param>
        /// <param name="convertView">A recycled view. If this parameter is null,
        /// a new view must be inflated.</param>
        /// <param name="parent">The view's parent.</param>
        /// <returns>A view adapted for the item at the corresponding position.</returns>
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (GetTemplateDelegate == null)
            {
                return convertView;
            }

            var item = _list[position];
            var view = GetTemplateDelegate(position, item, convertView);
            return view;
        }

        private void NotifierCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyDataSetChanged();
        }
    }
}