// **************************************************************************
// <copyright file="Messenger.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>13.4.2009</date>
// <project>GalaSoft.MvvmLight.Messaging</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this project or http://www.galasoft.ch/license_MIT.txt
// </license>
// <LastBaseLevel>BL0008</LastBaseLevel>
// ****************************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using GalaSoft.MvvmLight.Helpers;

////using GalaSoft.Utilities.Attributes;

namespace GalaSoft.MvvmLight.Messaging
{
    /// <summary>
    /// The Messenger is a class allowing objects to exchange messages.
    /// </summary>
    ////[ClassInfo(typeof(Messenger),
    ////    VersionString = "2.0.0.0",
    ////    DateString = "200909281606",
    ////    Description = "A messenger class allowing a class to send a message to multiple recipients",
    ////    UrlContacts = "http://www.galasoft.ch/contact_en.html",
    ////    Email = "laurent@galasoft.ch")]
    public class Messenger : IMessenger
    {
        private readonly OldMessenger _oldMessenger = new OldMessenger();

        private static Messenger _defaultInstance;

        private Dictionary<Type, List<WeakAction>> _recipientsOfSubclassesAction;

        private Dictionary<Type, List<WeakAction>> _recipientsStrictAction;

        /// <summary>
        /// Gets the Messenger's default instance, allowing
        /// to register and broadcast in a static manner.
        /// </summary>
        public static Messenger Default
        {
            get
            {
                if (_defaultInstance == null)
                {
                    _defaultInstance = new Messenger();
                }

                return _defaultInstance;
            }
        }

        /// <summary>
        /// Sets the Messenger's default (static) instance to null.
        /// </summary>
        public static void Reset()
        {
            _defaultInstance = null;
        }

        //// OLD

        /// <summary>
        /// Broacasts a message to the recipients who registered for
        /// this type of message.
        /// </summary>
        /// <param name="message">The message to broadcast.</param>
        [Obsolete("Please use the method Send<TMessage> instead.")]
        public void Broadcast(MessageBase message)
        {
            _oldMessenger.Broadcast(message);
        }

        /// <summary>
        /// Registers a message recipient for a given type of messages, with
        /// the Messenger's default instance. Registration is made in a way that
        /// it is not necessary to unregister a recipient before it is disposed.
        /// </summary>
        /// <param name="recipient">The recipient.</param>
        /// <param name="messageType">The message type that the recipient registers
        /// for. The type must inherit MessageBase.</param>
        /// <exception cref="ArgumentException">If the messageType does not
        /// inherit <see cref="MessageBase"/></exception>
        [Obsolete("Please register a recipient with the generic methods 'Messenger.Register<TMessage>'.")]
        public void Register(IMessageRecipient recipient, Type messageType)
        {
            Register(recipient, messageType, false);
        }

        /// <summary>
        /// Registers a message recipient for a given type of messages, with
        /// the Messenger's default instance. Registration is made in a way that
        /// it is not necessary to unregister a recipient before it is disposed.
        /// </summary>
        /// <param name="recipient">The recipient.</param>
        /// <param name="messageType">The message type that the recipient registers
        /// for. The type must inherit MessageBase.</param>
        /// <param name="receiveDerivedMessagesToo">If true, the recipient will also receive
        /// message types deriving from the registered message type. For example, registering
        /// for <see cref="MessageBase" /> will pass all the messages to the recipient.
        /// If the message type registered is a generic type without type arguments, all the
        /// messages of this generic type will be received. For example, registering the message
        /// type "GenericMessage&lt;&gt;" will get the message types "GenericMessage&lt;string&gt;",
        /// "GenericMessage&lt;Exception&gt;", etc...</param>
        /// <exception cref="ArgumentException">If the messageType does not
        /// inherit <see cref="MessageBase"/></exception>
        [Obsolete("Please register a recipient with the generic methods 'Messenger.Register<TMessage>'.")]
        public void Register(IMessageRecipient recipient, Type messageType, bool receiveDerivedMessagesToo)
        {
            _oldMessenger.Register(recipient, messageType, receiveDerivedMessagesToo);
        }

        //// NEW

        /// <summary>
        /// Registers a recipient for a type of message TMessage. The <see cref="action" />
        /// parameter will be executed when a corresponding message is sent.
        /// <para>Registering a recipient does not create a hard reference to it,
        /// so if this recipient is deleted, no memory leak is caused.</para>
        /// </summary>
        /// <typeparam name="TMessage">The type of message that the recipient registers
        /// for.</typeparam>
        /// <param name="recipient">The recipient that will receive the messages.</param>
        /// <param name="action">The action that will be executed when a message
        /// of type TMessage is sent.</param>
        public void Register<TMessage>(object recipient, Action<TMessage> action)
        {
            Register(recipient, false, action);
        }

        /// <summary>
        /// Registers a recipient for a type of message TMessage.
        /// The <see cref="action" /> parameter will be executed when a corresponding 
        /// message is sent. See the <see cref="receiveDerivedMessagesToo" /> parameter
        /// for details on how messages deriving from TMessage (or, if TMessage is an interface,
        /// messages implementing TMessage) can be received too.
        /// <para>Registering a recipient does not create a hard reference to it,
        /// so if this recipient is deleted, no memory leak is caused.</para>
        /// </summary>
        /// <typeparam name="TMessage">The type of message that the recipient registers
        /// for.</typeparam>
        /// <param name="recipient">The recipient that will receive the messages.</param>
        /// <param name="receiveDerivedMessagesToo">If true, message types deriving from
        /// TMessage will also be transmitted to the recipient. For example, if a SendOrderMessage
        /// and an ExecuteOrderMessage derive from OrderMessage, registering for OrderMessage
        /// and setting receiveDerivedMessagesToo to true will send SendOrderMessage
        /// and ExecuteOrderMessage to the recipient that registered.
        /// <para>Also, if TMessage is an interface, message types implementing TMessage will also be
        /// transmitted to the recipient. For example, if a SendOrderMessage
        /// and an ExecuteOrderMessage implement IOrderMessage, registering for IOrderMessage
        /// and setting receiveDerivedMessagesToo to true will send SendOrderMessage
        /// and ExecuteOrderMessage to the recipient that registered.</para>
        /// </param>
        /// <param name="action">The action that will be executed when a message
        /// of type TMessage is sent.</param>
        public void Register<TMessage>(object recipient, bool receiveDerivedMessagesToo, Action<TMessage> action)
        {
            var messageType = typeof(TMessage);

            Dictionary<Type, List<WeakAction>> recipients;

            if (receiveDerivedMessagesToo)
            {
                if (_recipientsOfSubclassesAction == null)
                {
                    _recipientsOfSubclassesAction = new Dictionary<Type, List<WeakAction>>();
                }

                recipients = _recipientsOfSubclassesAction;
            }
            else
            {
                if (_recipientsStrictAction == null)
                {
                    _recipientsStrictAction = new Dictionary<Type, List<WeakAction>>();
                }

                recipients = _recipientsStrictAction;
            }

            List<WeakAction> list;

            if (!recipients.ContainsKey(messageType))
            {
                list = new List<WeakAction>();
                recipients.Add(messageType, list);
            }
            else
            {
                list = recipients[messageType];
            }

            var weakAction = new WeakAction<TMessage>(recipient, action);
            list.Add(weakAction);

            Cleanup();
        }

        /// <summary>
        /// Sends a message to registered recipients. The message will
        /// reach all recipients that registered for this message type
        /// using one of the Register methods.
        /// </summary>
        /// <typeparam name="TMessage">The type of message that will be sent.</typeparam>
        /// <param name="message">The message to send to registered recipients.</param>
        public void Send<TMessage>(TMessage message)
        {
            SendToTargetOrType(message, null);
        }

        /// <summary>
        /// Sends a message to registered recipients. The message will
        /// reach only recipients that registered for this message type
        /// using one of the Register methods, and that are
        /// of the targetType.
        /// </summary>
        /// <typeparam name="TMessage">The type of message that will be sent.</typeparam>
        /// <typeparam name="TTarget">The type of recipients that will receive
        /// the message. The message won't be sent to recipients of another type.</typeparam>
        /// <param name="message">The message to send to registered recipients.</param>
        [SuppressMessage(
            "Microsoft.Design",
            "CA1004:GenericMethodsShouldProvideTypeParameter",
            Justification = "This syntax is more convenient than other alternatives.")]
        public void Send<TMessage, TTarget>(TMessage message)
        {
            SendToTargetOrType(message, typeof(TTarget));
        }

        //// OLD

        /// <summary>
        /// Unregisters a previously registered message recipient. After it is unregistered,
        /// the recipient will not get any messages anymore.
        /// </summary>
        /// <param name="recipient">The recipient to unregister.</param>
        [Obsolete("Please unregister a recipient with the generic methods 'Messenger.Unregister<TMessage>'.")]
        public void Unregister(IMessageRecipient recipient)
        {
            _oldMessenger.Unregister(recipient);
        }

        /// <summary>
        /// Unregisters a previously registered message recipient. After it is unregistered,
        /// the recipient will not get any messages of the given message type anymore..
        /// </summary>
        /// <param name="recipient">The recipient to unregister.</param>
        /// <param name="messageType">The message type for which the
        /// recipient wants to unregister.</param>
        [Obsolete("Please unregister a recipient with the generic methods 'Messenger.Unregister<TMessage>'.")]
        public void Unregister(IMessageRecipient recipient, Type messageType)
        {
            _oldMessenger.Unregister(recipient, messageType);
        }

        //// NEW

        /// <summary>
        /// Unregisters a messager recipient completely. After this method
        /// is executed, the recipient will not receive any messages anymore.
        /// </summary>
        /// <param name="recipient">The recipient that must be unregistered.</param>
        public void Unregister(object recipient)
        {
            UnregisterFromLists(recipient, _recipientsOfSubclassesAction);
            UnregisterFromLists(recipient, _recipientsStrictAction);

            var oldRecipient = recipient as IMessageRecipient;
            if (oldRecipient != null)
            {
                _oldMessenger.Unregister(oldRecipient);
            }
        }

        /// <summary>
        /// Unregisters a message recipient for a given type of messages only. 
        /// After this method is executed, the recipient will not receive messages
        /// of type TMessage anymore, but will still receive other message types (if it
        /// registered for them previously).
        /// </summary>
        /// <typeparam name="TMessage">The type of messages that the recipient wants
        /// to unregister from.</typeparam>
        /// <param name="recipient">The recipient that must be unregistered.</param>
        [SuppressMessage(
            "Microsoft.Design",
            "CA1004:GenericMethodsShouldProvideTypeParameter",
            Justification =
                "The type parameter TMessage identifies the message type that the recipient wants to unregister for.")]
        public void Unregister<TMessage>(object recipient)
        {
            Unregister<TMessage>(recipient, null);
        }

        /// <summary>
        /// Unregisters a message recipient for a given type of messages and for
        /// a given action. Other message types will still be transmitted to the
        /// recipient (if it registered for them previously). Other actions that have
        /// been registered for the message type TMessage and for the given recipient (if
        /// available) will also remain available.
        /// </summary>
        /// <typeparam name="TMessage">The type of messages that the recipient wants
        /// to unregister from.</typeparam>
        /// <param name="recipient">The recipient that must be unregistered.</param>
        /// <param name="action">The action that must be unregistered for
        /// the recipient and for the message type TMessage.</param>
        public void Unregister<TMessage>(object recipient, Action<TMessage> action)
        {
            UnregisterFromLists(recipient, action, _recipientsStrictAction);
            UnregisterFromLists(recipient, action, _recipientsOfSubclassesAction);
            Cleanup();
        }

        private static void CleanupList(IDictionary<Type, List<WeakAction>> lists)
        {
            if (lists == null)
            {
                return;
            }

            var listsToRemove = new List<Type>();
            foreach (var list in lists)
            {
                var recipientsToRemove = new List<WeakAction>();
                foreach (var recipient in list.Value)
                {
                    if (recipient == null
                        || !recipient.IsAlive)
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

        private static bool Implements(Type messageType, Type type)
        {
            if (type == null
                || messageType == null)
            {
                return false;
            }

            var interfaces = messageType.GetInterfaces();
            foreach (var currentInterface in interfaces)
            {
                if (currentInterface == type)
                {
                    return true;
                }
            }

            return false;
        }

        private static void SendToList<TMessage>(
            TMessage message,
            IEnumerable<WeakAction> list,
            Type messageTargetType)
        {
            if (list != null)
            {
                // Clone to protect from people registering in a "receive message" method
                // Bug correction Messaging BL0004.007
                var listClone = list.Take(list.Count()).ToList();

                foreach (var action in listClone)
                {
                    var executeAction = action as IExecuteWithObject;

                    if (action != null
                        && executeAction != null
                        && action.IsAlive
                        && action.Target != null
                        && (messageTargetType == null
                            || action.Target.GetType() == messageTargetType))
                    {
                        executeAction.ExecuteWithObject(message);
                    }
                }
            }
        }

        private static void UnregisterFromLists(object recipient, Dictionary<Type, List<WeakAction>> lists)
        {
            if (recipient == null
                || lists == null
                || lists.Count == 0)
            {
                return;
            }

            lock (lists)
            {
                foreach (var messageType in lists.Keys)
                {
                    foreach (var weakAction in lists[messageType])
                    {
                        if (recipient == weakAction.Target)
                        {
                            weakAction.MarkForDeletion();
                        }
                    }
                }
            }
        }

        private static void UnregisterFromLists<TMessage>(
            object recipient,
            Action<TMessage> action,
            Dictionary<Type, List<WeakAction>> lists)
        {
            var messageType = typeof(TMessage);

            if (recipient == null
                || lists == null
                || lists.Count == 0
                || !lists.ContainsKey(messageType))
            {
                return;
            }

            lock (lists)
            {
                foreach (var weakAction in lists[messageType])
                {
                    var weakActionCasted = weakAction as WeakAction<TMessage>;

                    if (weakActionCasted != null
                        && recipient == weakActionCasted.Target
                        && (action == null
                            || action == weakActionCasted.Action))
                    {
                        weakAction.MarkForDeletion();
                    }
                }
            }
        }

        private void Cleanup()
        {
            CleanupList(_recipientsOfSubclassesAction);
            CleanupList(_recipientsStrictAction);
        }

        private void SendToTargetOrType<TMessage>(TMessage message, Type messageTargetType)
        {
            var messageType = typeof(TMessage);

            if (_recipientsOfSubclassesAction != null)
            {
                foreach (var type in _recipientsOfSubclassesAction.Keys)
                {
                    List<WeakAction> list = null;

                    if (messageType == type
                        || messageType.IsSubclassOf(type)
                        || Implements(messageType, type))
                    {
                        list = _recipientsOfSubclassesAction[type];
                    }

                    SendToList(message, list, messageTargetType);
                }
            }

            if (_recipientsStrictAction != null)
            {
                if (_recipientsStrictAction.ContainsKey(messageType))
                {
                    var list = _recipientsStrictAction[messageType];
                    SendToList(message, list, messageTargetType);
                }
            }

            Cleanup();
        }
    }
}