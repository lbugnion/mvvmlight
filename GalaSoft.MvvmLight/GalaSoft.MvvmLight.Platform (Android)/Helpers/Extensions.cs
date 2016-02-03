// ****************************************************************************
// <copyright file="Extensions.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2016
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>18.03.2014</date>
// <project>GalaSoft.MvvmLight</project>
// <web>http://www.mvvmlight.net</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace GalaSoft.MvvmLight.Helpers
{
    /// <summary>
    /// Defines extension methods used to add data bindings and commands between Xamarin
    /// Android and iOS elements.
    /// </summary>
    ////[ClassInfo(typeof(Binding))]
    public static class Extensions
    {
        /// <summary>
        /// Sets a data binding between two properties. If the source implements INotifyPropertyChanged, the source property raises the PropertyChanged event
        /// and the BindingMode is OneWay or TwoWay, the target property will be synchronized with the source property. If
        /// the target implements INotifyPropertyChanged, the target property raises the PropertyChanged event and the BindingMode is
        /// TwoWay, the source property will also be synchronized with the target property.
        /// </summary>
        /// <remarks>This class allows for a different TSource and TTarget and is able to perform simple
        /// type conversions automatically. This is useful if the source property and the target
        /// property are of different type.
        /// If the type conversion is complex, please use the <see cref="Binding{TSource, TTarget}.ConvertSourceToTarget"/>
        /// and <see cref="Binding{TSource, TTarget}.ConvertTargetToSource"/> methods to configure the binding.
        /// It is very possible that TSource and TTarget are the same type in which case no conversion occurs.</remarks>
        /// <typeparam name="TSource">The type of the property that is being databound before conversion.</typeparam>
        /// <typeparam name="TTarget">The type of the property that is being databound after conversion.</typeparam>
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
        /// <param name="fallbackValue">The value to use when the binding is unable to return a value. This can happen if one of the
        /// items on the Path (except the source property itself) is null, or if the Converter throws an exception.</param>
        /// <param name="targetNullValue">The value used when the source property is null (or equals to default(TSource)).</param>
        /// <returns>The new Binding instance.</returns>
        public static Binding<TSource, TTarget> SetBinding<TSource, TTarget>(
            this object source,
            Expression<Func<TSource>> sourcePropertyExpression,
            object target,
            Expression<Func<TTarget>> targetPropertyExpression = null,
            BindingMode mode = BindingMode.Default,
            TSource fallbackValue = default(TSource),
            TSource targetNullValue = default(TSource))
        {
            return new Binding<TSource, TTarget>(
                source,
                sourcePropertyExpression,
                target,
                targetPropertyExpression,
                mode,
                fallbackValue,
                targetNullValue);
        }

        /// <summary>
        /// Creates a <see cref="Binding{TSource, TSource}"/> with a source property but without a target.
        /// This type of bindings is useful for the <see cref="SetCommand{TIn, TOut}"/>
        /// and <see cref="SetCommand{T, TEventArgs}"/> methods, to use as CommandParameter
        /// binding.
        /// </summary>
        /// <param name="source">The source of the binding. If this object implements INotifyPropertyChanged and the
        /// BindingMode is OneWay or TwoWay, the target will be notified of changes to the target property.</param>
        /// <param name="sourcePropertyExpression">An expression pointing to the source property. It can be
        /// a simple expression "() => [source].MyProperty" or a composed expression "() => [source].SomeObject.SomeOtherObject.SomeProperty".</param>
        /// <param name="mode">The mode of the binding. OneTime means that the target property will be set once (when the binding is
        /// created) but that subsequent changes will be ignored. OneWay means that the target property will be set, and
        /// if the PropertyChanged event is raised by the source, the target property will be updated. TwoWay means that the source
        /// property will also be updated if the target raises the PropertyChanged event. Default means OneWay if only the source
        /// implements INPC, and TwoWay if both the source and the target implement INPC.</param>
        /// <param name="fallbackValue">The value to use when the binding is unable to return a value. This can happen if one of the
        /// items on the Path (except the source property itself) is null, or if the Converter throws an exception.</param>
        /// <param name="targetNullValue">The value used when the source property is null (or equals to default(TSource)).</param>
        /// <typeparam name="TSource">The type of the bound property.</typeparam>
        /// <returns>The created binding instance.</returns>
        public static Binding<TSource, TSource> SetBinding<TSource>(
            this object source,
            Expression<Func<TSource>> sourcePropertyExpression,
            BindingMode mode = BindingMode.Default,
            TSource fallbackValue = default(TSource),
            TSource targetNullValue = default(TSource))
        {
            return new Binding<TSource, TSource>(
                source,
                sourcePropertyExpression,
                null,
                null,
                mode,
                fallbackValue,
                targetNullValue);
        }

        /// <summary>
        /// Sets a data binding between two properties of the same object. If the source implements INotifyPropertyChanged, has observable properties
        /// and the BindingMode is OneWay or TwoWay, the target property will be notified of changes to the source property. If
        /// the target implements INotifyPropertyChanged, has observable properties and the BindingMode is
        /// TwoWay, the source will also be notified of changes to the target's properties.
        /// </summary>
        /// <typeparam name="TSource">The type of the source property that is being databound.</typeparam>
        /// <typeparam name="TTarget">The type of the target property that is being databound. If the source type
        /// is not the same as the target type, an automatic conversion will be attempted. However only
        /// simple types can be converted. For more complex conversions, use the <see cref="Binding{TSource, TTarget}.ConvertSourceToTarget"/>
        /// and <see cref="Binding{TSource, TTarget}.ConvertTargetToSource"/> methods to define custom converters.</typeparam>
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
        /// <param name="fallbackValue">The value to use when the binding is unable to return a value. This can happen if one of the
        /// items on the Path (except the source property itself) is null, or if the Converter throws an exception.</param>
        /// <param name="targetNullValue">The value used when the source property is null (or equals to default(TSource)).</param>
        /// <returns>The new Binding instance.</returns>
        public static Binding<TSource, TTarget> SetBinding<TSource, TTarget>(
            this object source,
            Expression<Func<TSource>> sourcePropertyExpression,
            Expression<Func<TTarget>> targetPropertyExpression = null,
            BindingMode mode = BindingMode.Default,
            TSource fallbackValue = default(TSource),
            TSource targetNullValue = default(TSource))
        {
            return new Binding<TSource, TTarget>(
                source,
                sourcePropertyExpression,
                null,
                targetPropertyExpression,
                mode,
                fallbackValue,
                targetNullValue);
        }

        /// <summary>
        /// Sets a data binding between two properties. If the source implements INotifyPropertyChanged, the source property raises the PropertyChanged event
        /// and the BindingMode is OneWay or TwoWay, the target property will be synchronized with the source property. If
        /// the target implements INotifyPropertyChanged, the target property raises the PropertyChanged event and the BindingMode is
        /// TwoWay, the source property will also be synchronized with the target property.
        /// </summary>
        /// <typeparam name="TSource">The type of the source property that is being databound.</typeparam>
        /// <typeparam name="TTarget">The type of the target property that is being databound. If the source type
        /// is not the same as the target type, an automatic conversion will be attempted. However only
        /// simple types can be converted. For more complex conversions, use the <see cref="Binding{TSource, TTarget}.ConvertSourceToTarget"/>
        /// and <see cref="Binding{TSource, TTarget}.ConvertTargetToSource"/> methods to define custom converters.</typeparam>
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
        /// <param name="fallbackValue">The value to use when the binding is unable to return a value. This can happen if one of the
        /// items on the Path (except the source property itself) is null, or if the Converter throws an exception.</param>
        /// <param name="targetNullValue">The value used when the source property is null (or equals to default(TSource)).</param>
        /// <returns>The new Binding instance.</returns>
        public static Binding<TSource, TTarget> SetBinding<TSource, TTarget>(
            this object source,
            string sourcePropertyName,
            object target,
            string targetPropertyName = null,
            BindingMode mode = BindingMode.Default,
            TSource fallbackValue = default(TSource),
            TSource targetNullValue = default(TSource))
        {
            return new Binding<TSource, TTarget>(
                source,
                sourcePropertyName,
                target,
                targetPropertyName,
                mode,
                fallbackValue,
                targetNullValue);
        }

        /// <summary>
        /// Sets a data binding between two properties of the same object. If the source implements INotifyPropertyChanged, has observable properties
        /// and the BindingMode is OneWay or TwoWay, the target property will be notified of changes to the source property. If
        /// the target implements INotifyPropertyChanged, has observable properties and the BindingMode is
        /// TwoWay, the source will also be notified of changes to the target's properties.
        /// </summary>
        /// <typeparam name="TSource">The type of the source property that is being databound.</typeparam>
        /// <typeparam name="TTarget">The type of the target property that is being databound. If the source type
        /// is not the same as the target type, an automatic conversion will be attempted. However only
        /// simple types can be converted. For more complex conversions, use the <see cref="Binding{TSource, TTarget}.ConvertSourceToTarget"/>
        /// and <see cref="Binding{TSource, TTarget}.ConvertTargetToSource"/> methods to define custom converters.</typeparam>
        /// <param name="targetPropertyName">The name of the target property. This must be a simple name, without dots.</param>
        /// <param name="source">The source of the binding. If this object implements INotifyPropertyChanged and the
        /// BindingMode is OneWay or TwoWay, the target will be notified of changes to the target property.</param>
        /// <param name="sourcePropertyName">The name of the source property. This must be a simple name, without dots.</param>
        /// <param name="mode">The mode of the binding. OneTime means that the target property will be set once (when the binding is
        /// created) but that subsequent changes will be ignored. OneWay means that the target property will be set, and
        /// if the PropertyChanged event is raised by the source, the target property will be updated. TwoWay means that the source
        /// property will also be updated if the target raises the PropertyChanged event. Default means OneWay if only the source
        /// implements INPC, and TwoWay if both the source and the target implement INPC.</param>
        /// <param name="fallbackValue">The value to use when the binding is unable to return a value. This can happen if one of the
        /// items on the Path (except the source property itself) is null, or if the Converter throws an exception.</param>
        /// <param name="targetNullValue">The value used when the source property is null (or equals to default(TSource)).</param>
        /// <returns>The new Binding instance.</returns>
        public static Binding<TSource, TTarget> SetBinding<TSource, TTarget>(
            this object source,
            string sourcePropertyName,
            string targetPropertyName = null,
            BindingMode mode = BindingMode.Default,
            TSource fallbackValue = default(TSource),
            TSource targetNullValue = default(TSource))
        {
            return new Binding<TSource, TTarget>(
                source,
                sourcePropertyName,
                null,
                targetPropertyName,
                mode,
                fallbackValue,
                targetNullValue);
        }

        /// <summary>
        /// Sets a generic RelayCommand to an object and actuates the command when a specific event is raised. This method
        /// can only be used when the event uses a standard EventHandler. 
        /// </summary>
        /// <typeparam name="T">The type of the CommandParameter that will be passed to the RelayCommand.</typeparam>
        /// <param name="element">The element to which the command is added.</param>
        /// <param name="eventName">The name of the event that will be subscribed to to actuate the command.</param>
        /// <param name="command">The command that must be added to the element.</param>
        /// <param name="commandParameterBinding">A <see cref="Binding{T, T}">Binding</see> instance subscribed to
        /// the CommandParameter that will passed to the RelayCommand. Depending on the Binding, the CommandParameter
        /// will be observed and changes will be passed to the command, for example to update the CanExecute.</param>
        public static void SetCommand<T>(
            this object element,
            string eventName,
            RelayCommand<T> command,
            Binding commandParameterBinding)
        {
            var t = element.GetType();
            var e = t.GetEventInfoForControl(eventName);

            var castedBinding = (Binding<T, T>)commandParameterBinding;

            EventHandler handler = (s, args) =>
            {
                var param = castedBinding == null ? default(T) : castedBinding.Value;

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
                enabledProperty.SetValue(element, command.CanExecute(castedBinding.Value));

                command.CanExecuteChanged += (s, args) => enabledProperty.SetValue(
                    element,
                    command.CanExecute(castedBinding.Value));

                commandParameterBinding.ValueChanged += (s, args) => enabledProperty.SetValue(
                    element,
                    command.CanExecute(castedBinding.Value));
            }
        }

        /// <summary>
        /// Sets a generic RelayCommand to an object and actuates the command when a specific event is raised. This method
        /// should be used when the event uses an EventHandler&lt;TEventArgs&gt;.
        /// </summary>
        /// <typeparam name="T">The type of the CommandParameter that will be passed to the RelayCommand.</typeparam>
        /// <typeparam name="TEventArgs">The type of the event's arguments.</typeparam>
        /// <param name="element">The element to which the command is added.</param>
        /// <param name="command">The command that must be added to the element.</param>
        /// <param name="eventName">The name of the event that will be subscribed to to actuate the command.</param>
        /// <param name="commandParameterBinding">A <see cref="Binding&lt;TSource, TTarget&gt;">Binding</see> instance subscribed to
        /// the CommandParameter that will passed to the RelayCommand. Depending on the Binding, the CommandParameter
        /// will be observed and changes will be passed to the command, for example to update the CanExecute.</param>
        public static void SetCommand<T, TEventArgs>(
            this object element,
            string eventName,
            RelayCommand<T> command,
            Binding commandParameterBinding)
        {
            var castedBinding = (Binding<T, T>)commandParameterBinding;

            var t = element.GetType();
            var e = t.GetEventInfoForControl(eventName);

            EventHandler<TEventArgs> handler = (s, args) =>
            {
                var param = castedBinding == null ? default(T) : castedBinding.Value;

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
                enabledProperty.SetValue(element, command.CanExecute(castedBinding.Value));

                commandParameterBinding.ValueChanged += (s, args) => enabledProperty.SetValue(
                    element,
                    command.CanExecute(castedBinding.Value));

                command.CanExecuteChanged += (s, args) => enabledProperty.SetValue(
                    element,
                    command.CanExecute(castedBinding.Value));
            }
        }

        /// <summary>
        /// Sets a non-generic RelayCommand to an object and actuates the command when a specific event is raised. This method
        /// can only be used when the event uses a standard EventHandler. 
        /// </summary>
        /// <param name="element">The element to which the command is added.</param>
        /// <param name="eventName">The name of the event that will be subscribed to to actuate the command.</param>
        /// <param name="command">The command that must be added to the element.</param>
        public static void SetCommand(
            this object element,
            string eventName,
            ICommand command)
        {
            var t = element.GetType();
            var e = t.GetEventInfoForControl(eventName);

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

                command.CanExecuteChanged += (s, args) => enabledProperty.SetValue(
                    element,
                    command.CanExecute(null));
            }
        }

        /// <summary>
        /// Sets a non-generic RelayCommand to an object and actuates the command when a specific event is raised. This method
        /// should be used when the event uses an EventHandler&lt;TEventArgs&gt;.
        /// </summary>
        /// <typeparam name="TEventArgs">The type of the event's arguments.</typeparam>
        /// <param name="element">The element to which the command is added.</param>
        /// <param name="eventName">The name of the event that will be subscribed to to actuate the command.</param>
        /// <param name="command">The command that must be added to the element.</param>
        public static void SetCommand<TEventArgs>(
            this object element,
            string eventName,
            ICommand command)
        {
            var t = element.GetType();
            var e = t.GetEventInfoForControl(eventName);

            EventHandler<TEventArgs> handler = (s, args) =>
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

                command.CanExecuteChanged += (s, args) => enabledProperty.SetValue(
                    element,
                    command.CanExecute(null));
            }
        }

        /// <summary>
        /// Sets a generic RelayCommand to an object and actuates the command when a specific event is raised. This method
        /// can only be used when the event uses a standard EventHandler. 
        /// </summary>
        /// <typeparam name="T">The type of the CommandParameter that will be passed to the RelayCommand.</typeparam>
        /// <param name="element">The element to which the command is added.</param>
        /// <param name="command">The command that must be added to the element.</param>
        /// <param name="eventName">The name of the event that will be subscribed to to actuate the command.</param>
        /// <param name="commandParameter">The command parameter that will be passed to the RelayCommand when it
        /// is executed. This is a fixed value. To pass an observable value, use one of the SetCommand
        /// overloads that uses a Binding as CommandParameter.</param>
        public static void SetCommand<T>(
            this object element,
            string eventName,
            RelayCommand<T> command,
            T commandParameter)
        {
            var t = element.GetType();
            var e = t.GetEventInfoForControl(eventName);

            EventHandler handler = (s, args) =>
            {
                if (command.CanExecute(commandParameter))
                {
                    command.Execute(commandParameter);
                }
            };

            e.AddEventHandler(
                element,
                handler);

            var enabledProperty = t.GetProperty("Enabled");
            if (enabledProperty != null)
            {
                enabledProperty.SetValue(element, command.CanExecute(commandParameter));

                command.CanExecuteChanged += (s, args) => enabledProperty.SetValue(
                    element,
                    command.CanExecute(commandParameter));
            }
        }

        /// <summary>
        /// Sets a generic RelayCommand to an object and actuates the command when a specific event is raised. This method
        /// should be used when the event uses an EventHandler&lt;TEventArgs&gt;.
        /// </summary>
        /// <typeparam name="T">The type of the CommandParameter that will be passed to the RelayCommand.</typeparam>
        /// <typeparam name="TEventArgs">The type of the event's arguments.</typeparam>
        /// <param name="element">The element to which the command is added.</param>
        /// <param name="command">The command that must be added to the element.</param>
        /// <param name="eventName">The name of the event that will be subscribed to to actuate the command.</param>
        /// <param name="commandParameter">The command parameter that will be passed to the RelayCommand when it
        /// is executed. This is a fixed value. To pass an observable value, use one of the SetCommand
        /// overloads that uses a Binding as CommandParameter.</param>
        public static void SetCommand<T, TEventArgs>(
            this object element,
            string eventName,
            RelayCommand<T> command,
            T commandParameter)
        {
            var t = element.GetType();
            var e = t.GetEventInfoForControl(eventName);

            EventHandler<TEventArgs> handler = (s, args) =>
            {
                if (command.CanExecute(commandParameter))
                {
                    command.Execute(commandParameter);
                }
            };

            e.AddEventHandler(
                element,
                handler);

            var enabledProperty = t.GetProperty("Enabled");
            if (enabledProperty != null)
            {
                enabledProperty.SetValue(element, command.CanExecute(commandParameter));

                command.CanExecuteChanged += (s, args) => enabledProperty.SetValue(
                    element,
                    command.CanExecute(commandParameter));
            }
        }

#if ANDROID
        /// <summary>
        /// Sets a generic RelayCommand to an object and actuates the command when a specific event is raised. This method
        /// can only be used when the event uses a standard EventHandler.
        /// This method does not specify the observed event explicitly. The following events are used:
        /// - For CheckBox: CheckedChange.
        /// - For Button: Click.
        /// - At the moment, no other controls are supported. For other controls, use another SetCommand overload
        /// and specify the eventName parameter explicitly.
        /// </summary>
        /// <typeparam name="T">The type of the CommandParameter that will be passed to the RelayCommand.</typeparam>
        /// <param name="element">The element to which the command is added.</param>
        /// <param name="command">The command that must be added to the element.</param>
        /// <param name="commandParameterBinding">A <see cref="Binding&lt;TSource, TTarget&gt;">Binding</see> instance subscribed to
        /// the CommandParameter that will passed to the RelayCommand. Depending on the Binding, the CommandParameter
        /// will be observed and changes will be passed to the command, for example to update the CanExecute.</param>
#elif __IOS__
        /// <summary>
        /// Sets a generic RelayCommand to an object and actuates the command when a specific event is raised. This method
        /// can only be used when the event uses a standard EventHandler.
        /// This method does not specify the observed event explicitly. The following events are used:
        /// - For UIBarButtonItem: Clicked.
        /// - For UIButton: TouchUpInside.
        /// - At the moment, no other controls are supported. For other controls, use another SetCommand overload
        /// and specify the eventName parameter explicitly.
        /// </summary>
        /// <typeparam name="T">The type of the CommandParameter that will be passed to the RelayCommand.</typeparam>
        /// <param name="element">The element to which the command is added.</param>
        /// <param name="command">The command that must be added to the element.</param>
        /// <param name="commandParameterBinding">A <see cref="Binding&lt;TSource, TTarget&gt;">Binding</see> instance subscribed to
        /// the CommandParameter that will passed to the RelayCommand. Depending on the Binding, the CommandParameter
        /// will be observed and changes will be passed to the command, for example to update the CanExecute.</param>
#endif
        public static void SetCommand<T>(
            this object element,
            RelayCommand<T> command,
            Binding commandParameterBinding)
        {
            SetCommand(element, string.Empty, command, commandParameterBinding);
        }

#if ANDROID
        /// <summary>
        /// Sets a generic RelayCommand to an object and actuates the command when a specific event is raised. This method
        /// should be used when the event uses an EventHandler&lt;TEventArgs&gt;.
        /// This method does not specify the observed event explicitly. The following events are used:
        /// - For CheckBox: CheckedChange.
        /// - For Button: Click.
        /// - At the moment, no other controls are supported. For other controls, use another SetCommand overload
        /// and specify the eventName parameter explicitly.
        /// </summary>
        /// <typeparam name="T">The type of the CommandParameter that will be passed to the RelayCommand.</typeparam>
        /// <typeparam name="TEventArgs">The type of the event's arguments.</typeparam>
        /// <param name="element">The element to which the command is added.</param>
        /// <param name="command">The command that must be added to the element.</param>
        /// <param name="commandParameterBinding">A <see cref="Binding&lt;TSource, TTarget&gt;">Binding</see> instance subscribed to
        /// the CommandParameter that will passed to the RelayCommand. Depending on the Binding, the CommandParameter
        /// will be observed and changes will be passed to the command, for example to update the CanExecute.</param>
#elif __IOS__
        /// <summary>
        /// Sets a generic RelayCommand to an object and actuates the command when a specific event is raised. This method
        /// should be used when the event uses an EventHandler&lt;TEventArgs&gt;.
        /// This method does not specify the observed event explicitly. The following events are used:
        /// - For UIBarButtonItem: Clicked.
        /// - For UIButton: TouchUpInside.
        /// - At the moment, no other controls are supported. For other controls, use another SetCommand overload
        /// and specify the eventName parameter explicitly.
        /// </summary>
        /// <typeparam name="T">The type of the CommandParameter that will be passed to the RelayCommand.</typeparam>
        /// <typeparam name="TEventArgs">The type of the event's arguments.</typeparam>
        /// <param name="element">The element to which the command is added.</param>
        /// <param name="command">The command that must be added to the element.</param>
        /// <param name="commandParameterBinding">A <see cref="Binding&lt;TSource, TTarget&gt;">Binding</see> instance subscribed to
        /// the CommandParameter that will passed to the RelayCommand. Depending on the Binding, the CommandParameter
        /// will be observed and changes will be passed to the command, for example to update the CanExecute.</param>
#endif
        public static void SetCommand<T, TEventArgs>(
            this object element,
            RelayCommand<T> command,
            Binding commandParameterBinding)
        {
            SetCommand<T, TEventArgs>(element, string.Empty, command, commandParameterBinding);
        }

#if ANDROID
        /// <summary>
        /// Sets an ICommand to an object and actuates the command when a specific event is raised. This method
        /// can only be used when the event uses a standard EventHandler. 
        /// This method does not specify the observed event explicitly. The following events are used:
        /// - For CheckBox: CheckedChange.
        /// - For Button: Click.
        /// - At the moment, no other controls are supported. For other controls, use another SetCommand overload
        /// and specify the eventName parameter explicitly.
        /// </summary>
        /// <param name="element">The element to which the command is added.</param>
        /// <param name="command">The command that must be added to the element.</param>
#elif __IOS__
        /// <summary>
        /// Sets an ICommand to an object and actuates the command when a specific event is raised. This method
        /// can only be used when the event uses a standard EventHandler. 
        /// This method does not specify the observed event explicitly. The following events are used:
        /// - For UIBarButtonItem: Clicked.
        /// - For UIButton: TouchUpInside.
        /// - At the moment, no other controls are supported. For other controls, use another SetCommand overload
        /// and specify the eventName parameter explicitly.
        /// </summary>
        /// <param name="element">The element to which the command is added.</param>
        /// <param name="command">The command that must be added to the element.</param>
#endif
        public static void SetCommand(
            this object element,
            ICommand command)
        {
            SetCommand(element, string.Empty, command);
        }

#if ANDROID
        /// <summary>
        /// Sets an ICommand to an object and actuates the command when a specific event is raised. This method
        /// should be used when the event uses an EventHandler&lt;TEventArgs&gt;.
        /// This method does not specify the observed event explicitly. The following events are used:
        /// - For CheckBox: CheckedChange.
        /// - For Button: Click.
        /// - At the moment, no other controls are supported. For other controls, use another SetCommand overload
        /// and specify the eventName parameter explicitly.
        /// </summary>
        /// <typeparam name="TEventArgs">The type of the event's arguments.</typeparam>
        /// <param name="element">The element to which the command is added.</param>
        /// <param name="command">The command that must be added to the element.</param>
#elif __IOS__
        /// <summary>
        /// Sets an ICommand to an object and actuates the command when a specific event is raised. This method
        /// should be used when the event uses an EventHandler&lt;TEventArgs&gt;.
        /// This method does not specify the observed event explicitly. The following events are used:
        /// - For UIBarButtonItem: Clicked.
        /// - For UIButton: TouchUpInside.
        /// - At the moment, no other controls are supported. For other controls, use another SetCommand overload
        /// and specify the eventName parameter explicitly.
        /// </summary>
        /// <typeparam name="TEventArgs">The type of the event's arguments.</typeparam>
        /// <param name="element">The element to which the command is added.</param>
        /// <param name="command">The command that must be added to the element.</param>
#endif
        public static void SetCommand<TEventArgs>(
            this object element,
            ICommand command)
        {
            SetCommand<TEventArgs>(element, string.Empty, command);
        }

#if ANDROID
        /// <summary>
        /// Sets a generic RelayCommand to an object and actuates the command when a specific event is raised. This method
        /// can only be used when the event uses a standard EventHandler.
        /// This method does not specify the observed event explicitly. The following events are used:
        /// - For CheckBox: CheckedChange.
        /// - For Button: Click.
        /// - At the moment, no other controls are supported. For other controls, use another SetCommand overload
        /// and specify the eventName parameter explicitly.
        /// </summary>
        /// <typeparam name="T">The type of the CommandParameter that will be passed to the RelayCommand.</typeparam>
        /// <param name="element">The element to which the command is added.</param>
        /// <param name="command">The command that must be added to the element.</param>
        /// <param name="commandParameter">The command parameter that will be passed to the RelayCommand when it
        /// is executed. This is a fixed value. To pass an observable value, use one of the SetCommand
        /// overloads that uses a Binding as CommandParameter.</param>
#elif __IOS__
        /// <summary>
        /// Sets a generic RelayCommand to an object and actuates the command when a specific event is raised. This method
        /// can only be used when the event uses a standard EventHandler.
        /// This method does not specify the observed event explicitly. The following events are used:
        /// - For UIBarButtonItem: Clicked.
        /// - For UIButton: TouchUpInside.
        /// - At the moment, no other controls are supported. For other controls, use another SetCommand overload
        /// and specify the eventName parameter explicitly.
        /// </summary>
        /// <typeparam name="T">The type of the CommandParameter that will be passed to the RelayCommand.</typeparam>
        /// <param name="element">The element to which the command is added.</param>
        /// <param name="command">The command that must be added to the element.</param>
        /// <param name="commandParameter">The command parameter that will be passed to the RelayCommand when it
        /// is executed. This is a fixed value. To pass an observable value, use one of the SetCommand
        /// overloads that uses a Binding as CommandParameter.</param>
#endif
        public static void SetCommand<T>(
            this object element,
            RelayCommand<T> command,
            T commandParameter)
        {
            SetCommand(element, string.Empty, command, commandParameter);
        }

#if ANDROID
        /// <summary>
        /// Sets a generic RelayCommand to an object and actuates the command when a specific event is raised. This method
        /// should be used when the event uses an EventHandler&lt;TEventArgs&gt;.
        /// This method does not specify the observed event explicitly. The following events are used:
        /// - For CheckBox: CheckedChange.
        /// - For Button: Click.
        /// - At the moment, no other controls are supported. For other controls, use another SetCommand overload
        /// and specify the eventName parameter explicitly.
        /// </summary>
        /// <typeparam name="T">The type of the CommandParameter that will be passed to the RelayCommand.</typeparam>
        /// <typeparam name="TEventArgs">The type of the event's arguments.</typeparam>
        /// <param name="element">The element to which the command is added.</param>
        /// <param name="command">The command that must be added to the element.</param>
        /// <param name="commandParameter">The command parameter that will be passed to the RelayCommand when it
        /// is executed. This is a fixed value. To pass an observable value, use one of the SetCommand
        /// overloads that uses a Binding as CommandParameter.</param>
#elif __IOS__
        /// <summary>
        /// Sets a generic RelayCommand to an object and actuates the command when a specific event is raised. This method
        /// should be used when the event uses an EventHandler&lt;TEventArgs&gt;.
        /// This method does not specify the observed event explicitly. The following events are used:
        /// - For UIBarButtonItem: Clicked.
        /// - For UIButton: TouchUpInside.
        /// - At the moment, no other controls are supported. For other controls, use another SetCommand overload
        /// and specify the eventName parameter explicitly.
        /// </summary>
        /// <typeparam name="T">The type of the CommandParameter that will be passed to the RelayCommand.</typeparam>
        /// <typeparam name="TEventArgs">The type of the event's arguments.</typeparam>
        /// <param name="element">The element to which the command is added.</param>
        /// <param name="command">The command that must be added to the element.</param>
        /// <param name="commandParameter">The command parameter that will be passed to the RelayCommand when it
        /// is executed. This is a fixed value. To pass an observable value, use one of the SetCommand
        /// overloads that uses a Binding as CommandParameter.</param>
#endif
        public static void SetCommand<T, TEventArgs>(
            this object element,
            RelayCommand<T> command,
            T commandParameter)
        {
            SetCommand<T, TEventArgs>(element, string.Empty, command, commandParameter);
        }

        internal static EventInfo GetEventInfoForControl(this Type type, string eventName)
        {
            if (string.IsNullOrEmpty(eventName))
            {
                eventName = type.GetDefaultEventNameForControl();
            }

            if (string.IsNullOrEmpty(eventName))
            {
                throw new ArgumentException("Event not found", "eventName");
            }

            var info = type.GetEvent(eventName);

            if (info == null)
            {
                throw new ArgumentException("Event not found: " + eventName, "eventName");
            }

            return info;
        }
    }
}