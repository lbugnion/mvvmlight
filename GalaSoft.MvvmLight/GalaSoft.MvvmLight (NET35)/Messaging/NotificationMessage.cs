// ****************************************************************************
// <copyright file="NotificationMessage.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2013
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>21.4.2009</date>
// <project>GalaSoft.MvvmLight.Messaging</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this project or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

////using GalaSoft.Utilities.Attributes;

namespace GalaSoft.MvvmLight.Messaging
{
    /// <summary>
    /// Passes a string message (Notification) to a recipient.
    /// <para>Typically, notifications are defined as unique strings in a static class. To define
    /// a unique string, you can use Guid.NewGuid().ToString() or any other unique
    /// identifier.</para>
    /// </summary>
    ////[ClassInfo(typeof(Messenger))]
    public class NotificationMessage : MessageBase
    {
        /// <summary>
        /// Initializes a new instance of the NotificationMessage class.
        /// </summary>
        /// <param name="notification">A string containing any arbitrary message to be
        /// passed to recipient(s)</param>
        public NotificationMessage(string notification)
        {
            Notification = notification;
        }

        /// <summary>
        /// Initializes a new instance of the NotificationMessage class.
        /// </summary>
        /// <param name="sender">The message's sender.</param>
        /// <param name="notification">A string containing any arbitrary message to be
        /// passed to recipient(s)</param>
        public NotificationMessage(object sender, string notification)
            : base(sender)
        {
            Notification = notification;
        }

        /// <summary>
        /// Initializes a new instance of the NotificationMessage class.
        /// </summary>
        /// <param name="sender">The message's sender.</param>
        /// <param name="target">The message's intended target. This parameter can be used
        /// to give an indication as to whom the message was intended for. Of course
        /// this is only an indication, amd may be null.</param>
        /// <param name="notification">A string containing any arbitrary message to be
        /// passed to recipient(s)</param>
        public NotificationMessage(object sender, object target, string notification)
            : base(sender, target)
        {
            Notification = notification;
        }

        /// <summary>
        /// Gets a string containing any arbitrary message to be
        /// passed to recipient(s).
        /// </summary>
        public string Notification
        {
            get;
            private set;
        }
    }
}