// ****************************************************************************
// <copyright file="NotificationMessageAction.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2013
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>29.11.2009</date>
// <project>GalaSoft.MvvmLight</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;

////using GalaSoft.Utilities.Attributes;

namespace GalaSoft.MvvmLight.Messaging
{
    /// <summary>
    /// Provides a message class with a built-in callback. When the recipient
    /// is done processing the message, it can execute the callback to
    /// notify the sender that it is done. Use the <see cref="Execute" />
    /// method to execute the callback.
    /// </summary>
    ////[ClassInfo(typeof(Messenger))]
    public class NotificationMessageAction : NotificationMessageWithCallback
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="NotificationMessageAction" /> class.
        /// </summary>
        /// <param name="notification">An arbitrary string that will be
        /// carried by the message.</param>
        /// <param name="callback">The callback method that can be executed
        /// by the recipient to notify the sender that the message has been
        /// processed.</param>
        public NotificationMessageAction(string notification, Action callback)
            : base(notification, callback)
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="NotificationMessageAction" /> class.
        /// </summary>
        /// <param name="sender">The message's sender.</param>
        /// <param name="notification">An arbitrary string that will be
        /// carried by the message.</param>
        /// <param name="callback">The callback method that can be executed
        /// by the recipient to notify the sender that the message has been
        /// processed.</param>
        public NotificationMessageAction(object sender, string notification, Action callback)
            : base(sender, notification, callback)
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="NotificationMessageAction" /> class.
        /// </summary>
        /// <param name="sender">The message's sender.</param>
        /// <param name="target">The message's intended target. This parameter can be used
        /// to give an indication as to whom the message was intended for. Of course
        /// this is only an indication, amd may be null.</param>
        /// <param name="notification">An arbitrary string that will be
        /// carried by the message.</param>
        /// <param name="callback">The callback method that can be executed
        /// by the recipient to notify the sender that the message has been
        /// processed.</param>
        public NotificationMessageAction(object sender, object target, string notification, Action callback)
            : base(sender, target, notification, callback)
        {
        }

        /// <summary>
        /// Executes the callback that was provided with the message.
        /// </summary>
        public void Execute()
        {
            base.Execute();
        }
    }
}