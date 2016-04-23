// ****************************************************************************
// <copyright file="ObservableRecyclerAdapter.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2016
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>17.04.2016</date>
// <project>GalaSoft.MvvmLight</project>
// <web>http://www.mvvmlight.net</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Threading;
using Android.App;
using Android.Support.V7.Widget;
using Android.Views;

namespace GalaSoft.MvvmLight.Helpers
{
    /// <summary>
    /// A <see cref="RecyclerView.Adapter"/> that automatically updates the associated <see cref="RecyclerView"/> when its 
    /// data source changes. Note that the changes are only observed if the data source 
    /// implements <see cref="INotifyCollectionChanged"/>.
    /// </summary>
    /// <typeparam name="TItem">The type of the items in the data source.</typeparam>
    /// <typeparam name="THolder">The type of the <see cref="RecyclerView.ViewHolder"/> used in the RecyclerView.
    /// For better results and simpler implementation, you can use a <see cref="CachingViewHolder"/> or
    /// provide your own implementation.</typeparam>
    ////[ClassInfo(typeof(ObservableAdapter<T>)]
    public class ObservableRecyclerAdapter<TItem, THolder> : RecyclerView.Adapter, INotifyPropertyChanged
        where THolder : RecyclerView.ViewHolder
    {
        /// <summary>
        /// The <see cref="SelectedItem" /> property's name.
        /// </summary>
        public const string SelectedItemPropertyName = "SelectedItem";

        private IList<TItem> _dataSource;
        private INotifyCollectionChanged _notifier;
        private int _oldPosition = -1;
        private View _oldView;
        private TItem _selectedItem;

        /// <summary>
        /// A delegate to a method taking a <see cref="RecyclerView.ViewHolder"/>
        /// and setting its View's properties according to the item
        /// passed as second parameter.
        /// </summary>
        public Action<THolder, TItem, int> BindViewHolderDelegate
        {
            get;
            set;
        }

        /// <summary>
        /// The Resource ID of the AXML file we should use to create
        /// cells for the RecyclerView. Alternatively you can use the
        /// <see cref="CreateViewHolderDelegate"/> property.
        /// </summary>
        public int CellLayoutId
        {
            get;
            set;
        }

        /// <summary>
        /// A delegate to a callback that will be called when an item
        /// in the list is clicked (or tapped) by the user. This can be used
        /// to perform UI operations such as changing the background color, etc.
        /// </summary>
        public Action<int, View, int, View> ClickCallback
        {
            get;
            set;
        }

        /// <summary>
        /// A delegate to a method taking an item's position and 
        /// a <see cref="RecyclerView.ViewHolder"/> and creating and returning
        /// a cell for the RecyclerView. Alternatively you can use the
        /// <see cref="CellLayoutId"/> property.
        /// </summary>
        public Func<ViewGroup, int, THolder> CreateViewHolderDelegate
        {
            get;
            set;
        }

        /// <summary>
        /// The data source of this list adapter.
        /// </summary>
        public IList<TItem> DataSource
        {
            get
            {
                return _dataSource;
            }

            set
            {
                if (Equals(_dataSource, value))
                {
                    return;
                }

                if (_notifier != null)
                {
                    _notifier.CollectionChanged -= HandleCollectionChanged;
                }

                _dataSource = value;
                _notifier = value as INotifyCollectionChanged;

                if (_notifier != null)
                {
                    _notifier.CollectionChanged += HandleCollectionChanged;
                }

                NotifyDataSetChanged(); // Reload everything
            }
        }

        /// <summary>
        /// Gets the number of items in the data source.
        /// </summary>
        public override int ItemCount
        {
            get
            {
                return _dataSource == null ? 0 : _dataSource.Count;
            }
        }

        /// <summary>
        /// Gets the RecyclerView's selected item. You can use one-way databinding on this property.
        /// </summary>
        public TItem SelectedItem
        {
            get
            {
                return _selectedItem;
            }

            protected set
            {
                if (Equals(_selectedItem, value))
                {
                    return;
                }

                _selectedItem = value;
                RaisePropertyChanged(SelectedItemPropertyName);
                RaiseSelectionChanged();
            }
        }

        /// <summary>
        /// Gets an item corresponding to a given row position.
        /// </summary>
        /// <param name="row">The row position of the item.</param>
        /// <returns>An item corresponding to a given row position.</returns>
        public TItem GetItem(int row)
        {
            return _dataSource[row];
        }

        /// <summary>
        /// Called when the View should be bound to the represented Item.
        /// </summary>
        /// <param name="holder">The <see cref="RecyclerView.ViewHolder"/> for this item.</param>
        /// <param name="position">The position of the item in the data source.</param>
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (BindViewHolderDelegate == null)
            {
                throw new InvalidOperationException(
                    "OnBindViewHolder was called but no BindViewHolderDelegate was found");
            }

            BindViewHolderDelegate((THolder)holder, _dataSource[position], position);
        }

        /// <summary>
        /// Called when the View should be created.
        /// </summary>
        /// <param name="parent">The parent for the view.</param>
        /// <param name="viewType">The resource ID (unused).</param>
        /// <returns></returns>
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            if (CellLayoutId != 0)
            {
                var viewHolderType = typeof (THolder);

                // The user has specified a ViewHolder type --> auto create the ViewHolder.
                var constructor = viewHolderType.GetConstructor(
                    new[]
                    {
                        typeof (View)
                    });

                if (constructor == null)
                {
                    throw new InvalidOperationException(
                        "No suitable constructor find for " + viewHolderType.FullName);
                }

                var view = LayoutInflater.From(parent.Context).Inflate(CellLayoutId, parent, false);
                var holder = constructor.Invoke(
                    new object[]
                    {
                        view
                    }) as RecyclerView.ViewHolder;

                var castedHolder = holder as CachingViewHolder;
                if (castedHolder != null)
                {
                    castedHolder.ClickCallback = OnItemClick;
                }

                return holder;
            }

            if (CreateViewHolderDelegate == null)
            {
                throw new InvalidOperationException(
                    "OnCreateViewHolder was called but no CreateViewHolderDelegate was found");
            }

            // No ViewHolderType specified --> Call the delegate
            return CreateViewHolderDelegate(parent, viewType);
        }

        /// <summary>
        /// Called when an item is clicked (or tapped) in the list.
        /// </summary>
        /// <param name="newPosition">The position of the clicked item.</param>
        /// <param name="newView">The view representing the clicked item.</param>
        public void OnItemClick(int newPosition, View newView)
        {
            if (ClickCallback != null)
            {
                ClickCallback(_oldPosition, _oldView, newPosition, newView);
                _oldPosition = newPosition;
                _oldView = newView;
            }

            if (_dataSource != null
                && _dataSource.Count >= newPosition)
            {
                SelectedItem = _dataSource[newPosition];
            }
        }

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void HandleCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Action act = () =>
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                    {
                        var count = e.NewItems.Count;
                        for (var i = 0; i < count; i++)
                        {
                            NotifyItemInserted(e.NewStartingIndex + i);
                        }
                    }
                        break;

                    case NotifyCollectionChangedAction.Remove:
                    {
                        var count = e.OldItems.Count;
                        Console.WriteLine($"Count: {count}");
                        for (var i = 0; i < count; i++)
                        {
                            NotifyItemRemoved(e.OldStartingIndex + i);

                            var item = e.OldItems[i];

                            if (Equals(SelectedItem, item))
                            {
                                SelectedItem = default(TItem);
                            }
                        }
                    }
                        break;

                    default:
                        NotifyDataSetChanged();
                        break;
                }
            };

            act();
        }

        private void RaiseSelectionChanged()
        {
            var handler = SelectionChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Occurs when a property of this instance changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Occurs when a new item gets selected in the UICollectionView.
        /// </summary>
        public event EventHandler SelectionChanged;
    }
}