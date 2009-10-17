// ****************************************************************************
// <copyright file="OldMessenger.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>18.9.2009</date>
// <project>GalaSoft.MvvmLight</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;

////using GalaSoft.Utilities.Attributes;

namespace GalaSoft.MvvmLight.Messaging
{
    /// <summary>
    /// Stores the old Messenger's code. This code is due for deletion in 
    /// a future version. Public methods using this code are marked obsolete.
    /// </summary>
    internal class OldMessenger
    {
        private Dictionary<Type, List<WeakReference>> _recipientsOfSubclasses;

        private Dictionary<Type, List<WeakReference>> _recipientsStrict;

        internal void Broadcast(MessageBase message)
        {
            var messageType = message.GetType();

            if (_recipientsOfSubclasses != null)
            {
                foreach (var type in _recipientsOfSubclasses.Keys)
                {
                    List<WeakReference> list = null;

                    if (messageType == type
                        || messageType.IsSubclassOf(type))
                    {
                        list = _recipientsOfSubclasses[type];
                    }
                    else
                    {
                        if (type.IsGenericType
                            && messageType.IsGenericType)
                        {
                            if (type.GetGenericArguments()[0].FullName == null
                                && type.GetGenericTypeDefinition() == messageType.GetGenericTypeDefinition())
                            {
                                list = _recipientsOfSubclasses[type];
                            }
                        }
                    }

                    SendToList(message, list);
                }
            }

            if (_recipientsStrict != null)
            {
                if (_recipientsStrict.ContainsKey(messageType))
                {
                    var list = _recipientsStrict[messageType];
                    SendToList(message, list);
                }
            }

            Cleanup();
        }

        internal void Register(IMessageRecipient recipient, Type messageType, bool receiveDerivedMessagesToo)
        {
            if (messageType != typeof(MessageBase)
                && !messageType.IsSubclassOf(typeof(MessageBase)))
            {
                throw new ArgumentException("Parameter must be a MessageBase", "messageType");
            }

            Dictionary<Type, List<WeakReference>> recipients;

            if (receiveDerivedMessagesToo)
            {
                if (_recipientsOfSubclasses == null)
                {
                    _recipientsOfSubclasses = new Dictionary<Type, List<WeakReference>>();
                }

                recipients = _recipientsOfSubclasses;
            }
            else
            {
                if (_recipientsStrict == null)
                {
                    _recipientsStrict = new Dictionary<Type, List<WeakReference>>();
                }

                recipients = _recipientsStrict;
            }

            List<WeakReference> list;

            if (!recipients.ContainsKey(messageType))
            {
                list = new List<WeakReference>();
                recipients.Add(messageType, list);
            }
            else
            {
                list = recipients[messageType];
            }

            var reference = new WeakReference(recipient);
            list.Add(reference);

            Cleanup();
        }

        internal void Unregister(IMessageRecipient recipient)
        {
            OldUnregisterFromLists(recipient, _recipientsStrict);
            OldUnregisterFromLists(recipient, _recipientsOfSubclasses);
        }

        internal void Unregister(IMessageRecipient recipient, Type messageType)
        {
            if (messageType != typeof(MessageBase)
                && !messageType.IsSubclassOf(typeof(MessageBase)))
            {
                throw new ArgumentException("Parameter must be a MessageBase", "messageType");
            }

            OldUnregisterFromLists(recipient, messageType, _recipientsStrict);
            OldUnregisterFromLists(recipient, messageType, _recipientsOfSubclasses);
        }

        private static void CleanupList(IDictionary<Type, List<WeakReference>> lists)
        {
            if (lists == null)
            {
                return;
            }

            var listsToRemove = new List<Type>();
            foreach (var list in lists)
            {
                var recipientsToRemove = new List<WeakReference>();
                foreach (var recipient in list.Value)
                {
                    if (!recipient.IsAlive)
                    {
                        recipientsToRemove.Add(recipient);
                    }
                }

                foreach (var recipient in recipientsToRemove)
                {
                    list.Value.Remove(recipient);
                }

                if (list.Value.Count == 0)
                {
                    listsToRemove.Add(list.Key);
                }
            }

            foreach (var key in listsToRemove)
            {
                lists.Remove(key);
            }
        }

        private static void SendToList(MessageBase message, IEnumerable<WeakReference> list)
        {
            if (list != null)
            {
                var listClone = list.Take(list.Count()).ToList();

                foreach (var recipient in listClone)
                {
                    if (recipient.IsAlive
                        && recipient.Target != null
                        && (message.Target == null
                            || (recipient.Target.GetType() == message.Target
                            || recipient.Target == message.Target)))
                    {
                        ((IMessageRecipient)recipient.Target).ReceiveMessage(message);
                    }
                }
            }
        }

        private static void OldUnregisterFromLists(
            IMessageRecipient recipient,
            Dictionary<Type, List<WeakReference>> lists)
        {
            if (lists == null)
            {
                return;
            }

            var types = new Type[lists.Keys.Count];
            lists.Keys.CopyTo(types, 0);

            foreach (var type in types)
            {
                OldUnregisterFromLists(recipient, type, lists);
            }
        }

        private static void OldUnregisterFromLists(
            IMessageRecipient recipient,
            Type messageType,
            IDictionary<Type, List<WeakReference>> lists)
        {
            if (recipient == null
                || messageType == null
                    || lists == null
                        || lists.Count == 0
                            || !lists.ContainsKey(messageType))
            {
                return;
            }

            var list = lists[messageType];
            WeakReference referenceToRemove = null;
            foreach (var reference in list)
            {
                if (reference.Target == recipient)
                {
                    referenceToRemove = reference;
                    break;
                }
            }

            if (referenceToRemove != null)
            {
                list.Remove(referenceToRemove);
            }

            if (list.Count == 0)
            {
                lists.Remove(messageType);
            }
        }

        private void Cleanup()
        {
            CleanupList(_recipientsOfSubclasses);
            CleanupList(_recipientsStrict);
        }
    }
}
