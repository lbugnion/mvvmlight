// ****************************************************************************
// <copyright file="IMessageRecipient.cs" company="GalaSoft Laurent Bugnion">
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
// ****************************************************************************

using System;

////using GalaSoft.Utilities.Attributes;

namespace GalaSoft.MvvmLight.Messaging
{
    /// <summary>
    /// Defines a message recipient that the Messenger can broadcast to.
    /// </summary>
    ////[ClassInfo(typeof(Messenger))]
    [Obsolete("Please register a recipient with the generic methods 'Messenger.Register<TMessage>'.")]
    public interface IMessageRecipient
    {
        /// <summary>
        /// Implement this method to receive messages broadcasted by the Messenger
        /// class. Messages will only be broadcasted to IMessageRecipients who
        /// registered using either the Messenger.Register method or the
        /// Messenger.Default.Register method.
        /// </summary>
        /// <param name="message">The message broadcasted by the Messenger.</param>
        void ReceiveMessage(MessageBase message);
    }
}