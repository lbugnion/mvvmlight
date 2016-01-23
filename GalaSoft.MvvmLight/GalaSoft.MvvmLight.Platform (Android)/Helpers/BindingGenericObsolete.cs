using System;

namespace GalaSoft.MvvmLight.Helpers
{
    // These methods are obsoleted and will be removed in a future version.
    public partial class Binding<TSource, TTarget> : Binding
    {
        /// <summary>
        /// Define when the binding should be evaluated when the bound source object
        /// is a control. Because Xamarin controls are not DependencyObjects, the
        /// bound property will not automatically update the binding attached to it. Instead,
        /// use this method to define which of the control's events should be observed.
        /// </summary>
        /// <param name="eventName">The name of the event that should be observed
        /// to update the binding's value.</param>
        /// <returns>The Binding instance.</returns>
        /// <exception cref="InvalidOperationException">When this method is called
        /// on a OneTime binding. Such bindings cannot be updated. This exception can
        /// also be thrown when the source object is null or has already been
        /// garbage collected before this method is called.</exception>
        /// <exception cref="ArgumentNullException">When the eventName parameter is null
        /// or is an empty string.</exception>
        /// <exception cref="ArgumentException">When the requested event does not exist on the
        /// source control.</exception>
        [Obsolete("This method will be removed in a future version. Please use ObserveSourceEvent instead.")]
        public Binding<TSource, TTarget> UpdateSourceTrigger(string eventName)
        {
            return ObserveSourceEvent(eventName);
        }

        /// <summary>
        /// Define when the binding should be evaluated when the bound source object
        /// is a control. Because Xamarin controls are not DependencyObjects, the
        /// bound property will not automatically update the binding attached to it. Instead,
        /// use this method to define which of the control's events should be observed.
        /// </summary>
        /// <remarks>Use this method when the event requires a specific EventArgs type
        /// instead of the standard EventHandler.</remarks>
        /// <typeparam name="TEventArgs">The type of the EventArgs used by this control's event.</typeparam>
        /// <param name="eventName">The name of the event that should be observed
        /// to update the binding's value.</param>
        /// <returns>The Binding instance.</returns>
        /// <exception cref="InvalidOperationException">When this method is called
        /// on a OneTime binding. Such bindings cannot be updated. This exception can
        /// also be thrown when the source object is null or has already been
        /// garbage collected before this method is called.</exception>
        /// <exception cref="ArgumentNullException">When the eventName parameter is null
        /// or is an empty string.</exception>
        /// <exception cref="ArgumentException">When the requested event does not exist on the
        /// source control.</exception>
        [Obsolete("This method will be removed in a future version. Please use ObserveSourceEvent instead.")]
        public Binding<TSource, TTarget> UpdateSourceTrigger<TEventArgs>(string eventName)
            where TEventArgs : EventArgs
        {
            return ObserveSourceEvent<TEventArgs>(eventName);
        }

        /// <summary>
        /// Define when the binding should be evaluated when the bound target object
        /// is a control. Because Xamarin controls are not DependencyObjects, the
        /// bound property will not automatically update the binding attached to it. Instead,
        /// use this method to define which of the control's events should be observed.
        /// </summary>
        /// <param name="eventName">The name of the event that should be observed
        /// to update the binding's value.</param>
        /// <returns>The Binding instance.</returns>
        /// <exception cref="InvalidOperationException">When this method is called
        /// on a OneTime or a OneWay binding. This exception can
        /// also be thrown when the source object is null or has already been
        /// garbage collected before this method is called.</exception>
        /// <exception cref="ArgumentNullException">When the eventName parameter is null
        /// or is an empty string.</exception>
        /// <exception cref="ArgumentException">When the requested event does not exist on the
        /// target control.</exception>
        [Obsolete("This method will be removed in a future version. Please use ObserveTargetEvent instead.")]
        public Binding<TSource, TTarget> UpdateTargetTrigger(string eventName)
        {
            return ObserveTargetEvent(eventName);
        }

        /// <summary>
        /// Define when the binding should be evaluated when the bound target object
        /// is a control. Because Xamarin controls are not DependencyObjects, the
        /// bound property will not automatically update the binding attached to it. Instead,
        /// use this method to define which of the control's events should be observed.
        /// </summary>
        /// <remarks>Use this method when the event requires a specific EventArgs type
        /// instead of the standard EventHandler.</remarks>
        /// <typeparam name="TEventArgs">The type of the EventArgs used by this control's event.</typeparam>
        /// <param name="eventName">The name of the event that should be observed
        /// to update the binding's value.</param>
        /// <returns>The Binding instance.</returns>
        /// <exception cref="InvalidOperationException">When this method is called
        /// on a OneTime or OneWay binding. This exception can
        /// also be thrown when the target object is null or has already been
        /// garbage collected before this method is called.</exception>
        /// <exception cref="ArgumentNullException">When the eventName parameter is null
        /// or is an empty string.</exception>
        /// <exception cref="ArgumentException">When the requested event does not exist on the
        /// target control.</exception>
        [Obsolete("This method will be removed in a future version. Please use ObserveTargetEvent instead.")]
        public Binding<TSource, TTarget> UpdateTargetTrigger<TEventArgs>(string eventName)
            where TEventArgs : EventArgs
        {
            return ObserveTargetEvent<TEventArgs>(eventName);
        }
    }
}