// ****************************************************************************
// <copyright file="EventToCommand.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2011
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
// <LastBaseLevel>BL0002</LastBaseLevel>
// ****************************************************************************

using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

////using GalaSoft.Utilities.Attributes;

namespace GalaSoft.MvvmLight.Command
{
    /// <summary>
    /// This <see cref="System.Windows.Interactivity.TriggerAction" /> can be
    /// used to bind any event on any FrameworkElement to an <see cref="ICommand" />.
    /// Typically, this element is used in XAML to connect the attached element
    /// to a command located in a ViewModel. This trigger can only be attached
    /// to a FrameworkElement or a class deriving from FrameworkElement.
    /// <para>To access the EventArgs of the fired event, use a RelayCommand&lt;EventArgs&gt;
    /// and leave the CommandParameter and CommandParameterValue empty!</para>
    /// </summary>
    ////[ClassInfo(typeof(EventToCommand),
    ////  VersionString = "3.0.0.0",
    ////  DateString = "201003041420",
    ////  Description = "A Trigger used to bind any event to an ICommand.",
    ////  UrlContacts = "http://www.galasoft.ch/contact_en.html",
    ////  Email = "laurent@galasoft.ch")]
    public partial class EventToCommand : TriggerAction<DependencyObject>
    {
        /// <summary>
        /// Gets or sets a value indicating whether the EventArgs passed to the
        /// event handler will be forwarded to the ICommand's Execute method
        /// when the event is fired (if the bound ICommand accepts an argument
        /// of type EventArgs).
        /// <para>For example, use a RelayCommand&lt;MouseEventArgs&gt; to get
        /// the arguments of a MouseMove event.</para>
        /// </summary>
        public bool PassEventArgsToCommand
        {
            get;
            set;
        }

        /// <summary>
        /// Provides a simple way to invoke this trigger programatically
        /// without any EventArgs.
        /// </summary>
        public void Invoke()
        {
            Invoke(null);
        }

        /// <summary>
        /// Executes the trigger.
        /// <para>To access the EventArgs of the fired event, use a RelayCommand&lt;EventArgs&gt;
        /// and leave the CommandParameter and CommandParameterValue empty!</para>
        /// </summary>
        /// <param name="parameter">The EventArgs of the fired event.</param>
        protected override void Invoke(object parameter)
        {
            if (AssociatedElementIsDisabled())
            {
                return;
            }

            var command = GetCommand();
            var commandParameter = CommandParameterValue;

            if (commandParameter == null
                && PassEventArgsToCommand)
            {
                commandParameter = parameter;
            }

            if (command != null
                && command.CanExecute(commandParameter))
            {
                command.Execute(commandParameter);
            }
        }

        private static void OnCommandChanged(
            EventToCommand element,
            DependencyPropertyChangedEventArgs e)
        {
            if (element == null)
            {
                return;
            }

            if (e.OldValue != null)
            {
                ((ICommand) e.OldValue).CanExecuteChanged -= element.OnCommandCanExecuteChanged;
            }

            var command = (ICommand) e.NewValue;

            if (command != null)
            {
                command.CanExecuteChanged += element.OnCommandCanExecuteChanged;
            }

            element.EnableDisableElement();
        }

        private bool AssociatedElementIsDisabled()
        {
            var element = GetAssociatedObject();
            return AssociatedObject == null
                || (element != null
                   && !element.IsEnabled);
        }

        private void EnableDisableElement()
        {
            var element = GetAssociatedObject();

            if (element == null)
            {
                return;
            }

            var command = this.GetCommand();

            if (this.MustToggleIsEnabledValue
                && command != null)
            {
                element.IsEnabled = command.CanExecute(this.CommandParameterValue);
            }
        }

        private void OnCommandCanExecuteChanged(object sender, EventArgs e)
        {
            EnableDisableElement();
        }
    }
}