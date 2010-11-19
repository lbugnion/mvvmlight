// ****************************************************************************
// <copyright file="EventToCommand.SL.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2010
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>3.11.2009</date>
// <project>GalaSoft.MvvmLight.Extras</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// <LastBaseLevel>BL0001</LastBaseLevel>
// ****************************************************************************
// This partial class contains the Silverlight-only implementation. See
// EventToCommand.cs for the shared implementation, and EventToCommand.WPF.cs
// for the WPF-only implementation.
// ****************************************************************************

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Expression.Samples.Interactivity.DataHelpers;

namespace GalaSoft.MvvmLight.Command
{
    /// <summary>
    /// This <see cref="System.Windows.Interactivity.TriggerAction" /> can be
    /// used to bind any event on any FrameworkElement to an <see cref="ICommand" />.
    /// Typically, this element is used in XAML to connect the attached element
    /// to a command located in a ViewModel. This trigger can only be attached
    /// to a FrameworkElement or a class deriving from FrameworkElement.
    /// </summary>
    public partial class EventToCommand
    {
        /// <summary>
        /// Identifies the <see cref="CommandParameter" /> dependency property
        /// </summary>
        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register(
            "CommandParameter",
            typeof(Binding),
            typeof(EventToCommand),
            new PropertyMetadata(
                null,
                (s, e) =>
                {
                    var sender = s as EventToCommand;
                    if (sender != null)
                    {
                        sender._listenerParameter.Binding = e.NewValue as Binding;
                    }
                }));

        /// <summary>
        /// Identifies the <see cref="Command" /> dependency property
        /// </summary>
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command",
            typeof(Binding),
            typeof(EventToCommand),
            new PropertyMetadata(
                null,
                (s, e) =>
                {
                    var sender = s as EventToCommand;
                    if (sender != null)
                    {
                        sender._listenerCommand.Binding = e.NewValue as Binding;
                    }
                }));

        /// <summary>
        /// Identifies the <see cref="MustToggleIsEnabled" /> dependency property
        /// </summary>
        public static readonly DependencyProperty MustToggleIsEnabledProperty = DependencyProperty.Register(
            "MustToggleIsEnabled",
            typeof(Binding),
            typeof(EventToCommand),
            new PropertyMetadata(
                null,
                (s, e) =>
                {
                    var sender = s as EventToCommand;
                    if (sender != null)
                    {
                        sender._listenerToggle.Binding = e.NewValue as Binding;
                    }
                }));

        private readonly BindingListener _listenerCommand;

        private readonly BindingListener _listenerParameter;

        private readonly BindingListener _listenerToggle;

        private object _commandParameterValue;

        private bool? _mustToggleValue;

        /// <summary>
        /// Initializes a new instance of the EventToCommand class.
        /// </summary>
        public EventToCommand()
        {
            _listenerCommand = new BindingListener(
                this,
                (s, e) =>
                {
                    var sender = s as BindingListener;
                    if (sender != null)
                    {
                        OnCommandChanged(
                            sender.Context as EventToCommand,
                            e.EventArgs);
                    }
                });

            _listenerParameter = new BindingListener(
                this,
                (s, e) => CheckEnableDisable(s as BindingListener));

            _listenerToggle = new BindingListener(
                this,
                (s, e) => CheckEnableDisable(s as BindingListener));
        }

        /// <summary>
        /// Gets or sets the ICommand that this trigger is bound to. This
        /// is a DependencyProperty.
        /// </summary>
        public Binding Command
        {
            get
            {
                return (Binding) GetValue(CommandProperty);
            }

            set
            {
                SetValue(CommandProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets an object that will be passed to the <see cref="Command" />
        /// attached to this trigger. This is a DependencyProperty. Because of limitations
        /// of Silverlight, you can only set databindings on this property. If you
        /// wish to use hard coded values, use the <see cref="CommandParameterValue" />
        /// property.
        /// </summary>
        public Binding CommandParameter
        {
            get
            {
                return (Binding) this.GetValue(CommandParameterProperty);
            }

            set
            {
                this.SetValue(CommandParameterProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets an object that will be passed to the <see cref="Command" />
        /// attached to this trigger. This is NOT a DependencyProperty. Use this
        /// property if you want to set a hard coded value.
        /// For databinding, use the <see cref="CommandParameter" /> property.
        /// </summary>
        public object CommandParameterValue
        {
            get
            {
                if (_commandParameterValue != null)
                {
                    return _commandParameterValue;
                }

                return this._listenerParameter.Value;
            }

            set
            {
                if (_listenerParameter.Value != null)
                {
                    throw new InvalidOperationException(
                        "Cannot set CommandParameterValue when CommandParameter is already set");
                }

                _commandParameterValue = value;
                EnableDisableElement();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the attached element must be
        /// disabled when the <see cref="Command" /> property's CanExecuteChanged
        /// event fires. If this property is true, and the command's CanExecute 
        /// method returns false, the element will be disabled. If this property
        /// is false, the element will not be disabled when the command's
        /// CanExecute method changes.
        /// If the attached element is not a <see cref="Control" />, this property
        /// has no effect. 
        /// This is a DependencyProperty.
        /// Because of limitations of Silverlight, you can only set databindings 
        /// on this property. If you wish to use hard coded values, use 
        /// the <see cref="CommandParameterValue" /> property.
        /// </summary>
        public Binding MustToggleIsEnabled
        {
            get
            {
                return (Binding) this.GetValue(MustToggleIsEnabledProperty);
            }

            set
            {
                this.SetValue(MustToggleIsEnabledProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the attached element must be
        /// disabled when the <see cref="Command" /> property's CanExecuteChanged
        /// event fires. If this property is true, and the command's CanExecute 
        /// method returns false, the element will be disabled.
        /// If the attached element is not a <see cref="Control" />, this property
        /// has no effect. 
        /// This property is here for compatibility with the Silverlight version. 
        /// This is NOT a DependencyProperty.
        /// Use this property if you want to set a hard coded value.
        /// For databinding, use the <see cref="MustToggleIsEnabled" /> property.
        /// </summary>
        public bool MustToggleIsEnabledValue
        {
            get
            {
                if (_mustToggleValue != null)
                {
                    return _mustToggleValue.Value;
                }

                if (_listenerToggle.Value != null)
                {
                    return (bool) _listenerToggle.Value;
                }

                return false;
            }

            set
            {
                if (_listenerToggle.Value != null)
                {
                    throw new InvalidOperationException(
                        "Cannot set MustToggleIsEnabledValue when MustToggleIsEnabled is already set");
                }

                _mustToggleValue = value;
                EnableDisableElement();
            }
        }

        /// <summary>
        /// Called when this trigger is attached to a FrameworkElement.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();

            _listenerCommand.Element = this.AssociatedObject;
            _listenerParameter.Element = this.AssociatedObject;
            _listenerToggle.Element = this.AssociatedObject;

            EnableDisableElement();
        }

        /// <summary>
        /// Called when this trigger is detached from its associated object.
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();

            _listenerCommand.Element = null;
            _listenerParameter.Element = null;
            _listenerToggle.Element = null;
        }

        private static void CheckEnableDisable(BindingListener listener)
        {
            if (listener == null)
            {
                return;
            }

            var thisObject = listener.Context as EventToCommand;
            if (thisObject != null)
            {
                thisObject.EnableDisableElement();
            }
        }

        private Control GetAssociatedObject()
        {
            return AssociatedObject as Control;
        }

        private ICommand GetCommand()
        {
            return _listenerCommand.Value as ICommand;
        }
    }
}