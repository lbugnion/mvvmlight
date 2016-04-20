// ****************************************************************************
// <copyright file="BindingGenericApple.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2016
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>22.01.2016</date>
// <project>GalaSoft.MvvmLight</project>
// <web>http://www.mvvmlight.net</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using UIKit;

namespace GalaSoft.MvvmLight.Helpers
{
    // Partial class for Apple only.
    public partial class Binding<TSource, TTarget>
    {
        /// <summary>
        /// Define that the binding should be evaluated when the bound control's source property changes. 
        /// Because Xamarin controls are not DependencyObjects, the
        /// bound property will not automatically update the binding attached to it. Instead,
        /// use this method to specify that the binding must be updated when the property changes.
        /// </summary>
        /// <remarks>At this point, this method is inactive on iOS. Use
        /// <see cref="ObserveSourceEvent(string)"/> instead.</remarks>
        /// <returns>The Binding instance.</returns>
        /// <exception cref="InvalidOperationException">When this method is called
        /// on a OneTime binding. Such bindings cannot be updated. This exception can
        /// also be thrown when the source object is null or has already been
        /// garbage collected before this method is called.</exception>
        public Binding<TSource, TTarget> ObserveSourceEvent()
        {
            return ObserveSourceEvent(UpdateTriggerMode.PropertyChanged);
        }

        /// <summary>
        /// Define when the binding should be evaluated when the bound source object
        /// is a control. Because Xamarin controls are not DependencyObjects, the
        /// bound property will not automatically update the binding attached to it. Instead,
        /// use this method to define which of the control's events should be observed.
        /// </summary>
        /// <param name="mode">Defines the binding's update mode. Use 
        /// <see cref="UpdateTriggerMode.LostFocus"/> to update the binding when
        /// the source control loses the focus. You can also use
        /// <see cref="UpdateTriggerMode.PropertyChanged"/> to update the binding
        /// when the source control's property changes.
        /// NOTE: At this time the PropertyChanged mode is inactive on iOS. Use
        /// <see cref="ObserveSourceEvent(string)"/> instead.
        /// </param>
        /// <returns>The Binding instance.</returns>
        /// <exception cref="InvalidOperationException">When this method is called
        /// on a OneTime binding. Such bindings cannot be updated. This exception can
        /// also be thrown when the source object is null or has already been
        /// garbage collected before this method is called.</exception>
        public Binding<TSource, TTarget> ObserveSourceEvent(UpdateTriggerMode mode)
        {
            switch (mode)
            {
                case UpdateTriggerMode.LostFocus:
                    throw new ArgumentException(
                        "UpdateTriggerMode.LostFocus is only supported in Android at this time",
                        "mode");

                case UpdateTriggerMode.PropertyChanged:
                    return CheckControlSource();
            }

            return this;
        }

        /// <summary>
        /// Define that the binding should be evaluated when the bound control's target property changes. 
        /// Because Xamarin controls are not DependencyObjects, the
        /// bound property will not automatically update the binding attached to it. Instead,
        /// use this method to specify that the binding must be updated when the property changes.
        /// </summary>
        /// <remarks>At this point, this method is inactive on iOS. Use
        /// <see cref="ObserveTargetEvent(string)"/> instead.</remarks>
        /// <returns>The Binding instance.</returns>
        /// <exception cref="InvalidOperationException">When this method is called
        /// on a OneTime or a OneWay binding. This exception can
        /// also be thrown when the target object is null or has already been
        /// garbage collected before this method is called.</exception>
        public Binding<TSource, TTarget> ObserveTargetEvent()
        {
            return ObserveTargetEvent(UpdateTriggerMode.PropertyChanged);
        }

        /// <summary>
        /// Define when the binding should be evaluated when the bound target object
        /// is a control. Because Xamarin controls are not DependencyObjects, the
        /// bound property will not automatically update the binding attached to it. Instead,
        /// use this method to define which of the control's events should be observed.
        /// </summary>
        /// <param name="mode">Defines the binding's update mode. Use 
        /// <see cref="UpdateTriggerMode.LostFocus"/> to update the binding when
        /// the source control loses the focus. You can also use
        /// <see cref="UpdateTriggerMode.PropertyChanged"/> to update the binding
        /// when the source control's property changes.
        /// NOTE: At this time the PropertyChanged mode is inactive on iOS. Use
        /// <see cref="ObserveTargetEvent(string)"/> instead.
        /// </param>
        /// <returns>The Binding instance.</returns>
        /// <exception cref="InvalidOperationException">When this method is called
        /// on a OneTime or a OneWay binding. This exception can
        /// also be thrown when the source object is null or has already been
        /// garbage collected before this method is called.</exception>
        public Binding<TSource, TTarget> ObserveTargetEvent(UpdateTriggerMode mode)
        {
            switch (mode)
            {
                case UpdateTriggerMode.LostFocus:
                    throw new ArgumentException(
                        "UpdateTriggerMode.LostFocus is only supported in Android at this time",
                        "mode");

                case UpdateTriggerMode.PropertyChanged:
                    return CheckControlTarget();
            }

            return this;
        }

        private Binding<TSource, TTarget> CheckControlSource()
        {
            var textBox = _propertySource.Target as UITextView;
            if (textBox != null)
            {
                var binding = ObserveSourceEvent("Changed");
                binding._sourceHandlers["Changed"].IsDefault = true;
                return binding;
            }

            var textField = _propertySource.Target as UITextField;
            if (textField != null)
            {
                var binding = ObserveSourceEvent("EditingChanged");
                binding._sourceHandlers["EditingChanged"].IsDefault = true;
                return binding;
            }

            var checkbox = _propertySource.Target as UISwitch;
            if (checkbox != null)
            {
                var binding = ObserveSourceEvent("ValueChanged");
                binding._sourceHandlers["ValueChanged"].IsDefault = true;
                return binding;
            }

            return this;
        }

        private Binding<TSource, TTarget> CheckControlTarget()
        {
            if (Mode != BindingMode.TwoWay)
            {
                return this;
            }

            var textBox = _propertyTarget.Target as UITextView;
            if (textBox != null)
            {
                var binding = ObserveTargetEvent("Changed");
                binding._targetHandlers["Changed"].IsDefault = true;
                return binding;
            }

            var textField = _propertyTarget.Target as UITextField;
            if (textField != null)
            {
                var binding = ObserveTargetEvent("EditingChanged");
                binding._targetHandlers["EditingChanged"].IsDefault = true;
                return binding;
            }

            var checkbox = _propertyTarget.Target as UISwitch;
            if (checkbox != null)
            {
                var binding = ObserveTargetEvent("ValueChanged");
                binding._targetHandlers["ValueChanged"].IsDefault = true;
                return binding;
            }

            return this;
        }
    }
}