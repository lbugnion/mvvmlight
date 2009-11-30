// ****************************************************************************
// <copyright file="ButtonBaseExtensions.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>22.4.2009</date>
// <project>GalaSoft.MvvmLight.Command (SL)</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this project or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************
// <credits>This class was developed by Josh Smith (http://joshsmithonwpf.wordpress.com) and
// slightly modified with his permission.</credits>
// ****************************************************************************

using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

////using GalaSoft.Utilities.Attributes;

namespace GalaSoft.MvvmLight.Command
{
    /// <summary>
    /// Provides attached properties that extend the behavior
    /// of controls that derive from ButtonBase.
    /// </summary>
    ////[ClassInfo(typeof(RelayCommand))]
    public static class ButtonBaseExtensions
    {
        /// <summary>
        /// Identifies the CommandParameter dependency property.
        /// </summary>
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.RegisterAttached(
                "CommandParameter",
                typeof(object),
                typeof(ButtonBaseExtensions),
                new PropertyMetadata(null, OnCommandParameterChanged));

        /// <summary>
        /// Identitifies the Command dependency property.
        /// </summary>
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached(
                "Command",
                typeof(ICommand),
                typeof(ButtonBaseExtensions),
                new PropertyMetadata(null, OnCommandChanged));

        private static readonly CommandToButtonsMap CommandToButtonsMap = new CommandToButtonsMap();

        /// <summary>
        /// Gets the value of the Command dependency property.
        /// </summary>
        /// <param name="button">An instance of ButtonBase.</param>
        /// <returns>The value of the Command dependency property.</returns>
        [SuppressMessage("Microsoft.Design",
            "CA1011:ConsiderPassingBaseTypesAsParameters",
            Justification = "Commands are only for controls deriving from ButtonBase")]
        public static ICommand GetCommand(ButtonBase button)
        {
            return (ICommand) button.GetValue(CommandProperty);
        }

        /// <summary>
        /// Gets the value of the CommandParameter dependency property.
        /// </summary>
        /// <param name="button">An instance of ButtonBase.</param>
        /// <returns>The value of the CommandParameter dependency property.</returns>
        [SuppressMessage("Microsoft.Design",
            "CA1011:ConsiderPassingBaseTypesAsParameters",
            Justification = "Commands are only for controls deriving from ButtonBase")]
        public static object GetCommandParameter(ButtonBase button)
        {
            return button.GetValue(CommandParameterProperty);
        }

        /// <summary>
        /// Sets the value of the <see cref="Command" /> dependency property.
        /// </summary>
        /// <param name="button">An instance of ButtonBase.</param>
        /// <param name="value">The new value to set on the Command dependency property.</param>
        [SuppressMessage("Microsoft.Design",
            "CA1011:ConsiderPassingBaseTypesAsParameters",
            Justification = "Commands are only for controls deriving from ButtonBase")]
        public static void SetCommand(ButtonBase button, ICommand value)
        {
            button.SetValue(CommandProperty, value);
        }

        /// <summary>
        /// Sets the value of the CommandParameter dependency property.
        /// </summary>
        /// <param name="button">An instance of ButtonBase.</param>
        /// <param name="value">The new value to set on the CommandParameter dependency property.</param>
        [SuppressMessage("Microsoft.Design",
            "CA1011:ConsiderPassingBaseTypesAsParameters",
            Justification = "Commands are only for controls deriving from ButtonBase")]
        public static void SetCommandParameter(ButtonBase button, object value)
        {
            button.SetValue(CommandParameterProperty, value);
        }

        private static void OnButtonBaseClick(object sender, RoutedEventArgs e)
        {
            var btn = sender as ButtonBase;
            var cmd = GetCommand(btn);
            var parameter = GetCommandParameter(btn);
            if (cmd != null
                && cmd.CanExecute(parameter))
            {
                cmd.Execute(parameter);
            }
        }

        private static void OnCommandCanExecuteChanged(object sender, EventArgs e)
        {
            var cmd = sender as ICommand;
            if (cmd != null
                && CommandToButtonsMap.ContainsCommand(cmd))
            {
                CommandToButtonsMap.ForEachButton(
                    cmd,
                    btn =>
                    {
                        var parameter = GetCommandParameter(btn);
                        btn.IsEnabled = cmd.CanExecute(parameter);
                    });
            }
        }

        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = d as ButtonBase;
            if (button == null)
            {
                throw new ArgumentException(
                    "You must set the Command attached property on an element that derives from ButtonBase.");
            }

            var oldCommand = e.OldValue as ICommand;
            if (oldCommand != null)
            {
                CommandToButtonsMap.RemoveButtonFromMap(button, oldCommand);
                oldCommand.CanExecuteChanged -= OnCommandCanExecuteChanged;
                button.Click -= OnButtonBaseClick;
            }

            var newCommand = e.NewValue as ICommand;
            if (newCommand != null)
            {
                CommandToButtonsMap.AddButtonToMap(button, newCommand);
                newCommand.CanExecuteChanged += OnCommandCanExecuteChanged;
                button.Click += OnButtonBaseClick;

                // Bug fix (BL0004.002)
                var parameter = GetCommandParameter(button);
                button.IsEnabled = newCommand.CanExecute(parameter);
            }
        }

        private static void OnCommandParameterChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var btn = obj as ButtonBase;
            if (btn == null)
            {
                throw new ArgumentException(
                    "You must set the CommandParameter attached property on an element that derives from ButtonBase.");
            }

            var cmd = GetCommand(btn);
            if (cmd == null)
            {
                return;
            }

            var parameter = GetCommandParameter(btn);
            btn.IsEnabled = cmd.CanExecute(parameter);
        }
    }
}