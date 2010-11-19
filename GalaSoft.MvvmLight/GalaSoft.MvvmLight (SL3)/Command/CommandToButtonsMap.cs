// ****************************************************************************
// <copyright file="CommandToButtonsMap.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2010
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
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

////using GalaSoft.Utilities.Attributes;

namespace GalaSoft.MvvmLight.Command
{
    /// <summary>
    /// Maps ICommand objects to lists of ButtonBase objects.  Stores the object references
    /// as WeakReferences, so that the commands and buttons can be garbage collected as necessary.
    /// </summary>
    ////[ClassInfo(typeof(RelayCommand))]
    internal class CommandToButtonsMap
    {
        private readonly Dictionary<WeakReference, List<WeakReference>> _map =
            new Dictionary<WeakReference, List<WeakReference>>();

        internal void AddButtonToMap(ButtonBase button, ICommand comand)
        {
            if (!ContainsCommand(comand))
            {
                _map.Add(new WeakReference(comand), new List<WeakReference>());
            }

            var weakRefs = GetButtonsFromCommand(comand);
            weakRefs.Add(new WeakReference(button));
        }

        internal bool ContainsCommand(ICommand command)
        {
            return GetButtonsFromCommand(command) != null;
        }

        internal void ForEachButton(ICommand command, Action<ButtonBase> callback)
        {
            var buttonRefs = GetButtonsFromCommand(command);
            for (var i = buttonRefs.Count - 1; i > -1; --i)
            {
                var weakRef = buttonRefs[i];
                var button = weakRef.Target as ButtonBase;
                if (button != null)
                {
                    callback(button);
                }
            }
        }

        internal void RemoveButtonFromMap(ButtonBase button, ICommand command)
        {
            var buttonRefs = GetButtonsFromCommand(command);
            if (buttonRefs == null)
            {
                return;
            }

            for (var i = buttonRefs.Count - 1; i > -1; --i)
            {
                var weakRef = buttonRefs[i];
                if (weakRef.Target == button)
                {
                    buttonRefs.RemoveAt(i);
                    break;
                }
            }
        }

        private List<WeakReference> GetButtonsFromCommand(ICommand command)
        {
            Prune();
            return _map.FirstOrDefault(entry => entry.Key.Target == command).Value;
        }

        private void Prune()
        {
            var commands = _map.Keys.ToList();
            for (var commandIndex = commands.Count - 1; commandIndex > -1; --commandIndex)
            {
                var commandRef = commands[commandIndex];
                if (!commandRef.IsAlive)
                {
                    _map.Remove(commandRef);
                }
                else
                {
                    var buttons = _map[commandRef];
                    for (var buttonIndex = buttons.Count - 1; buttonIndex > -1; --buttonIndex)
                    {
                        var buttonRef = buttons[buttonIndex];
                        if (!buttonRef.IsAlive)
                        {
                            buttons.RemoveAt(buttonIndex);
                        }
                    }
                }
            }
        }
    }
}