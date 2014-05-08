// ****************************************************************************
// <copyright file="Extensions.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2014
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>18.03.2014</date>
// <project>GalaSoft.MvvmLight</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Linq.Expressions;
using GalaSoft.MvvmLight.Command;

namespace GalaSoft.MvvmLight.Android.Helpers
{
    // TODO Do we also need AddCommand<TEventArgs>?

    /// <summary>
    /// Defines extension methods used to add data bindings and commands between Xamarin
    /// Android and iOS elements.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Adds a data binding between two objects. If the source implements INotifyPropertyChanged, has observable properties
        /// and the BindingMode is OneWay or TwoWay, the target will be notified of changes to the source's properties. If
        /// the target implements INotifyPropertyChanged, has observable properties and the BindingMode is
        /// TwoWay, the source will also be notified of changes to the target's properties.
        /// </summary>
        /// <typeparam name="T">The type of the property that is being databound.</typeparam>
        /// <param name="target">The target of the binding. If this object implements INotifyPropertyChanged and the
        /// BindingMode is TwoWay, the source will be notified of changes to the source property.</param>
        /// <param name="targetPropertyExpression">An expression pointing to the target property. It can be
        /// a simple expression "() => [target].MyProperty" or a composed expression "() => [target].SomeObject.SomeOtherObject.SomeProperty".</param>
        /// <param name="source">The source of the binding. If this object implements INotifyPropertyChanged and the
        /// BindingMode is OneWay or TwoWay, the target will be notified of changes to the target property.</param>
        /// <param name="sourcePropertyExpression">An expression pointing to the source property. It can be
        /// a simple expression "() => [source].MyProperty" or a composed expression "() => [source].SomeObject.SomeOtherObject.SomeProperty".</param>
        /// <param name="mode">The mode of the binding. OneTime means that the target property will be set once (when the binding is
        /// created) but that subsequent changes will be ignored. OneWay means that the target property will be set, and
        /// if the PropertyChanged event is raised by the source, the target property will be updated. TwoWay means that the source
        /// property will also be updated if the target raises the PropertyChanged event. Default means OneWay if only the source
        /// implements INPC, and TwoWay if both the source and the target implement INPC.</param>
        /// <returns>The new Binding instance.</returns>
        public static Binding<T> AddBinding<T>(
            this object source,
            Expression<Func<T>> sourcePropertyExpression,
            object target,
            Expression<Func<T>> targetPropertyExpression,
            BindingMode mode = BindingMode.Default)
        {
            return new Binding<T>(
                source,
                sourcePropertyExpression,
                target,
                targetPropertyExpression,
                mode);
        }

        /// <summary>
        /// Adds a data binding between two objects. If the source implements INotifyPropertyChanged, has observable properties
        /// and the BindingMode is OneWay or TwoWay, the target will be notified of changes to the source's properties. If
        /// the target implements INotifyPropertyChanged, has observable properties and the BindingMode is
        /// TwoWay, the source will also be notified of changes to the target's properties.
        /// </summary>
        /// <typeparam name="T">The type of the property that is being databound.</typeparam>
        /// <param name="target">The target of the binding. If this object implements INotifyPropertyChanged and the
        /// BindingMode is TwoWay, the source will be notified of changes to the source property.</param>
        /// <param name="targetPropertyName">The name of the target property. This must be a simple name, without dots.</param>
        /// <param name="source">The source of the binding. If this object implements INotifyPropertyChanged and the
        /// BindingMode is OneWay or TwoWay, the target will be notified of changes to the target property.</param>
        /// <param name="sourcePropertyName">The name of the source property. This must be a simple name, without dots.</param>
        /// <param name="mode">The mode of the binding. OneTime means that the target property will be set once (when the binding is
        /// created) but that subsequent changes will be ignored. OneWay means that the target property will be set, and
        /// if the PropertyChanged event is raised by the source, the target property will be updated. TwoWay means that the source
        /// property will also be updated if the target raises the PropertyChanged event. Default means OneWay if only the source
        /// implements INPC, and TwoWay if both the source and the target implement INPC.</param>
        /// <returns>The new Binding instance.</returns>
        public static Binding<T> AddBinding<T>(
            this object source,
            string sourcePropertyName,
            object target,
            string targetPropertyName,
            BindingMode mode = BindingMode.Default)
        {
            return new Binding<T>(
                source,
                sourcePropertyName,
                target,
                targetPropertyName,
                mode);
        }

        /// <summary>
        /// Adds a generic RelayCommand to an object and actuate the command when a specific event is raised. This method
        /// should be used when the event uses an EventHandler&lt;TEventArgs&gt;.
        /// </summary>
        /// <typeparam name="T">The type of the CommandParameter that will be passed to the RelayCommand.</typeparam>
        /// <typeparam name="TEventArgs">The type of the event's arguments.</typeparam>
        /// <param name="element">The element to which the command is added.</param>
        /// <param name="eventName">The name of the event that will be subscribed to to actuate the command.</param>
        /// <param name="command">The command that must be added to the element.</param>
        /// <param name="commandParameterBinding">A <see cref="Binding&lt;T&gt;">Binding</see> instance subscribed to
        /// the CommandParameter that will passed to the RelayCommand. Depending on the Binding, the CommandParameter
        /// will be observed and changes will be passed to the command, for example to update the CanExecute.</param>
        public static void AddCommand<T, TEventArgs>(
            this object element,
            string eventName,
            RelayCommand<T> command,
            Binding<T> commandParameterBinding = null)
        {
            var t = element.GetType();
            var e = t.GetEvent(eventName);

            if (e == null)
            {
                throw new ArgumentException("Event not found: " + eventName, "eventName");
            }

            EventHandler<TEventArgs> handler = (s, args) =>
            {
                var param = commandParameterBinding == null ? default(T) : commandParameterBinding.Value;

                if (command.CanExecute(param))
                {
                    command.Execute(param);
                }
            };

            e.AddEventHandler(
                element,
                handler);

            if (commandParameterBinding == null)
            {
                return;
            }

            var enabledProperty = t.GetProperty("Enabled");
            if (enabledProperty != null)
            {
                enabledProperty.SetValue(element, command.CanExecute(commandParameterBinding.Value));

                commandParameterBinding.ValueChanged += (s, args) => enabledProperty.SetValue(
                    element,
                    command.CanExecute(commandParameterBinding.Value));

                command.CanExecuteChanged += (s, args) => enabledProperty.SetValue(
                    element,
                    command.CanExecute(commandParameterBinding.Value));
            }
        }

        /// <summary>
        /// Adds a generic RelayCommand to an object and actuate the command when a specific event is raised. This method
        /// can only be used when the event uses a standard EventHandler. 
        /// </summary>
        /// <typeparam name="T">The type of the CommandParameter that will be passed to the RelayCommand.</typeparam>
        /// <param name="element">The element to which the command is added.</param>
        /// <param name="eventName">The name of the event that will be subscribed to to actuate the command.</param>
        /// <param name="command">The command that must be added to the element.</param>
        /// <param name="commandParameterBinding">A <see cref="Binding&lt;T&gt;">Binding</see> instance subscribed to
        /// the CommandParameter that will passed to the RelayCommand. Depending on the Binding, the CommandParameter
        /// will be observed and changes will be passed to the command, for example to update the CanExecute.</param>
        public static void AddCommand<T>(
            this object element,
            string eventName,
            RelayCommand<T> command,
            Binding<T> commandParameterBinding = null)
        {
            var t = element.GetType();
            var e = t.GetEvent(eventName);

            if (e == null)
            {
                throw new ArgumentException("Event not found: " + eventName, "eventName");
            }

            EventHandler handler = (s, args) =>
            {
                var param = commandParameterBinding == null ? default(T) : commandParameterBinding.Value;

                if (command.CanExecute(param))
                {
                    command.Execute(param);
                }
            };

            e.AddEventHandler(
                element,
                handler);

            if (commandParameterBinding == null)
            {
                return;
            }

            var enabledProperty = t.GetProperty("Enabled");
            if (enabledProperty != null)
            {
                enabledProperty.SetValue(element, command.CanExecute(commandParameterBinding.Value));

                commandParameterBinding.ValueChanged += (s, args) => enabledProperty.SetValue(
                    element,
                    command.CanExecute(commandParameterBinding.Value));

                command.CanExecuteChanged += (s, args) => enabledProperty.SetValue(
                    element, 
                    command.CanExecute(commandParameterBinding.Value));
            }
        }

        /// <summary>
        /// Adds a non-generic RelayCommand to an object and actuate the command when a specific event is raised. This method
        /// can only be used when the event uses a standard EventHandler. 
        /// </summary>
        /// <param name="element">The element to which the command is added.</param>
        /// <param name="eventName">The name of the event that will be subscribed to to actuate the command.</param>
        /// <param name="command">The command that must be added to the element.</param>
        public static void AddCommand(
            this object element,
            string eventName,
            RelayCommand command)
        {
            var t = element.GetType();
            var e = t.GetEvent(eventName);

            if (e == null)
            {
                throw new ArgumentException("Event not found: " + eventName, "eventName");
            }

            EventHandler handler = (s, args) =>
            {
                if (command.CanExecute(null))
                {
                    command.Execute(null);
                }
            };

            e.AddEventHandler(
                element,
                handler);

            var enabledProperty = t.GetProperty("Enabled");
            if (enabledProperty != null)
            {
                enabledProperty.SetValue(element, command.CanExecute(null));
            }

            command.CanExecuteChanged += (s, args) =>
            {
                if (enabledProperty != null)
                {
                    enabledProperty.SetValue(element, command.CanExecute(null));
                }
            };
        }
    }
}