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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using GalaSoft.MvvmLight.Command;

#if ANDROID
using Android.Views;
#endif

#if IOS
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif

namespace GalaSoft.MvvmLight.Helpers
{
    /// <summary>
    /// Defines extension methods used to add data bindings and commands between Xamarin
    /// Android and iOS elements.
    /// </summary>
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
        /// <returns>The new Binding instance.</returns>
        public static Binding<TSource, TTarget> SetBinding<TSource, TTarget>(
            this object source,
            Expression<Func<TSource>> sourcePropertyExpression,
            object target,
            Expression<Func<TTarget>> targetPropertyExpression = null,
            BindingMode mode = BindingMode.Default)
        {
            return new Binding<TSource, TTarget>(
                source,
                sourcePropertyExpression,
                target,
                targetPropertyExpression,
                mode);
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
        /// <typeparam name="TSource">The type of the bound property.</typeparam>
        /// <returns>The created binding instance.</returns>
        public static Binding<TSource, TSource> SetBinding<TSource>(
            this object source,
            Expression<Func<TSource>> sourcePropertyExpression,
            BindingMode mode = BindingMode.Default)
        {
            return new Binding<TSource, TSource>(
                source,
                sourcePropertyExpression,
                null,
                null,
                mode);
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
        /// <returns>The new Binding instance.</returns>
        public static Binding<TSource, TTarget> SetBinding<TSource, TTarget>(
            this object source,
            Expression<Func<TSource>> sourcePropertyExpression,
            Expression<Func<TTarget>> targetPropertyExpression = null,
            BindingMode mode = BindingMode.Default)
        {
            return new Binding<TSource, TTarget>(
                source,
                sourcePropertyExpression,
                null,
                targetPropertyExpression,
                mode);
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
        /// <returns>The new Binding instance.</returns>
        public static Binding<TSource, TTarget> SetBinding<TSource, TTarget>(
            this object source,
            string sourcePropertyName,
            object target,
            string targetPropertyName = null,
            BindingMode mode = BindingMode.Default)
        {
            return new Binding<TSource, TTarget>(
                source,
                sourcePropertyName,
                target,
                targetPropertyName,
                mode);
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
        /// <returns>The new Binding instance.</returns>
        public static Binding<TSource, TTarget> SetBinding<TSource, TTarget>(
            this object source,
            string sourcePropertyName,
            string targetPropertyName = null,
            BindingMode mode = BindingMode.Default)
        {
            return new Binding<TSource, TTarget>(
                source,
                sourcePropertyName,
                null,
                targetPropertyName,
                mode);
        }

        /// <summary>
        /// Sets a generic RelayCommand to an object and actuate the command when a specific event is raised. This method
        /// should be used when the event uses an EventHandler&lt;TEventArgs&gt;.
        /// </summary>
        /// <typeparam name="T">The type of the CommandParameter that will be passed to the RelayCommand.</typeparam>
        /// <typeparam name="TEventArgs">The type of the event's arguments.</typeparam>
        /// <param name="element">The element to which the command is added.</param>
        /// <param name="eventName">The name of the event that will be subscribed to to actuate the command.</param>
        /// <param name="command">The command that must be added to the element.</param>
        /// <param name="commandParameterBinding">A <see cref="Binding&lt;TSource, TTarget&gt;">Binding</see> instance subscribed to
        /// the CommandParameter that will passed to the RelayCommand. Depending on the Binding, the CommandParameter
        /// will be observed and changes will be passed to the command, for example to update the CanExecute.</param>
        public static void SetCommand<T, TEventArgs>(
            this object element,
            string eventName,
            RelayCommand<T> command,
            Binding commandParameterBinding = null)
        {
            var castedBinding = (Binding<T, T>)commandParameterBinding;

            var t = element.GetType();
            var e = t.GetEvent(eventName);

            if (e == null)
            {
                throw new ArgumentException("Event not found: " + eventName, "eventName");
            }

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
        /// Sets a generic RelayCommand to an object and actuate the command when a specific event is raised. This method
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
            Binding commandParameterBinding = null)
        {
            var castedBinding = (Binding<T, T>)commandParameterBinding;

            var t = element.GetType();
            var e = t.GetEvent(eventName);

            if (e == null)
            {
                throw new ArgumentException("Event not found: " + eventName, "eventName");
            }

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

                commandParameterBinding.ValueChanged += (s, args) => enabledProperty.SetValue(
                    element,
                    command.CanExecute(castedBinding.Value));

                command.CanExecuteChanged += (s, args) => enabledProperty.SetValue(
                    element,
                    command.CanExecute(castedBinding.Value));
            }
        }

        /// <summary>
        /// Sets a non-generic RelayCommand to an object and actuate the command when a specific event is raised. This method
        /// can only be used when the event uses a standard EventHandler. 
        /// </summary>
        /// <param name="element">The element to which the command is added.</param>
        /// <param name="eventName">The name of the event that will be subscribed to to actuate the command.</param>
        /// <param name="command">The command that must be added to the element.</param>
        public static void SetCommand(
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

#if ANDROID

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

#endif

#if IOS

        /// <summary>
        /// Creates a new <see cref="ObservableTableViewController{T}"/> for a given <see cref="ObservableCollection{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the items contained in the collection.</typeparam>
        /// <param name="collection">The collection that the adapter will be created for.</param>
        /// <param name="createCellDelegate">A delegate to a method creating or reusing a <see cref="UITableViewCell"/>.
        /// The cell will then be passed to the <see cref="bindCellDelegate"/>
        /// delegate to set the elements' properties.</param>
        /// <param name="bindCellDelegate">A delegate to a method taking a <see cref="UITableViewCell"/>
        /// and setting its elements' properties according to the item
        /// passed as second parameter.
        /// The cell must be created first in the <see cref="createCellDelegate"/>
        /// delegate.</param>
        /// <returns>A controller adapted to the collection passed in parameter.</returns>
        public static ObservableTableViewController<T> GetController<T>(
            this ObservableCollection<T> collection,
            Func<NSString, UITableViewCell> createCellDelegate,
            Action<UITableViewCell, T, NSIndexPath> bindCellDelegate)
        {
            return new ObservableTableViewController<T>
            {
                DataSource = collection,
                CreateCellDelegate = createCellDelegate,
                BindCellDelegate = bindCellDelegate
            };
        }

        /// <summary>
        /// Creates a new <see cref="ObservableTableViewController{T}"/> for a given <see cref="IList{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the items contained in the list.</typeparam>
        /// <param name="list">The list that the adapter will be created for.</param>
        /// <param name="createCellDelegate">A delegate to a method creating or reusing a <see cref="UITableViewCell"/>.
        /// The cell will then be passed to the <see cref="bindCellDelegate"/>
        /// delegate to set the elements' properties.</param>
        /// <param name="bindCellDelegate">A delegate to a method taking a <see cref="UITableViewCell"/>
        /// and setting its elements' properties according to the item
        /// passed as second parameter.
        /// The cell must be created first in the <see cref="createCellDelegate"/>
        /// delegate.</param>
        /// <returns>A controller adapted to the collection passed in parameter.</returns>
        public static ObservableTableViewController<T> GetController<T>(
            this IList<T> list,
            Func<NSString, UITableViewCell> createCellDelegate,
            Action<UITableViewCell, T, NSIndexPath> bindCellDelegate)
        {
            return new ObservableTableViewController<T>
            {
                DataSource = list,
                CreateCellDelegate = createCellDelegate,
                BindCellDelegate = bindCellDelegate
            };
        }

#endif
    }
}