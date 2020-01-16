using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Input;
using AndroidX.RecyclerView.Widget;
using Android.Views;
using Android.Widget;

namespace GalaSoft.MvvmLight.Helpers
{
    /// <summary>
    /// Defines extension methods for Android only.
    /// </summary>
    ////[ClassInfo(typeof(ObservableAdapter<T>))]
    public static class ExtensionsAndroid2
    {
        /// <summary>
        /// Creates a new <see cref="ObservableRecyclerAdapter{TItem, THolder}"/> for a given <see cref="IList{TItem}"/>.
        /// </summary>
        /// <typeparam name="TItem">The type of the items contained in the <see cref="IList{TItem}"/>.</typeparam>
        /// <typeparam name="THolder">The type of the <see cref="RecyclerView.ViewHolder"/> used in the RecyclerView.
        /// For better results and simpler implementation, you can use a <see cref="CachingViewHolder"/> or
        /// provide your own implementation.</typeparam>
        /// <param name="list">The list that the adapter will be created for.</param>
        /// <param name="bindViewHolderDelegate">A delegate to the method used to bind the view to the corresponding item.</param>
        /// <param name="createViewHolderDelegate">A delegate to the method used to create the view for the corresponding item.</param>
        /// <param name="clickCallback">An optional delegate to a method called when an item is clicked or tapped.</param>
        /// <param name="getItemViewType">A delegate to the method used to decide the view type id.</param>
        /// <returns>The created <see cref="ObservableRecyclerAdapter{TItem, THolder}"/>.</returns>
        public static ObservableRecyclerAdapter<TItem, THolder> GetRecyclerAdapter<TItem, THolder>(
            this IList<TItem> list,
            Action<THolder, TItem, int> bindViewHolderDelegate,
            Func<ViewGroup, int, THolder> createViewHolderDelegate,
            Action<int, View, int, View> clickCallback = null,
            Func<int, int> getItemViewType = null)
            where THolder : RecyclerView.ViewHolder
        {
            return new ObservableRecyclerAdapter<TItem, THolder>
            {
                DataSource = list,
                BindViewHolderDelegate = bindViewHolderDelegate,
                CreateViewHolderDelegate = createViewHolderDelegate,
                GetItemViewTypeDelegate = getItemViewType,
                ClickCallback = clickCallback
            };
        }

        /// <summary>
        /// Creates a new <see cref="ObservableRecyclerAdapter{TItem, THolder}"/> for a given <see cref="IList{TItem}"/>.
        /// </summary>
        /// <typeparam name="TItem">The type of the items contained in the <see cref="IList{T}"/>.</typeparam>
        /// <param name="list">The list that the adapter will be created for.</param>
        /// <param name="bindViewHolderDelegate">A delegate to the method used to bind the view to the corresponding item.</param>
        /// <param name="cellLayoutId">The resource ID of the AXML file used to create the cell.</param>
        /// <param name="clickCallback">An optional delegate to a method called when an item is clicked or tapped.</param>
        /// <returns>The created <see cref="ObservableRecyclerAdapter{TItem, THolder}"/>.</returns>
        public static ObservableRecyclerAdapter<TItem, CachingViewHolder> GetRecyclerAdapter<TItem>(
            this IList<TItem> list,
            Action<CachingViewHolder, TItem, int> bindViewHolderDelegate,
            int cellLayoutId,
            Action<int, View, int, View> clickCallback = null)
        {
            return new ObservableRecyclerAdapter<TItem, CachingViewHolder>
            {
                DataSource = list,
                BindViewHolderDelegate = bindViewHolderDelegate,
                CellLayoutId = cellLayoutId,
                ClickCallback = clickCallback
            };
        }
    }
}
