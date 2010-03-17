// ****************************************************************************
// <copyright file="CommandMessage.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2010
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

using System;

namespace GalaSoft.MvvmLight.Messaging
{
    /// <summary>
    /// Passes a string message (Command) to a recipient.
    /// </summary>
    ////[ClassInfo(typeof(Messenger))]
    [Obsolete("This class has been replaced by NotificationMessage. Only the name changed. Please use the new class from now on.")]
    public class CommandMessage : MessageBase
    {
        /// <summary>
        /// Initializes a new instance of the CommandMessage class.
        /// </summary>
        /// <param name="command">A string containing any arbitrary message to be
        /// passed to recipient(s)</param>
        public CommandMessage(string command)
        {
            Command = command;
        }

        /// <summary>
        /// Initializes a new instance of the CommandMessage class.
        /// </summary>
        /// <param name="sender">The message's sender.</param>
        /// <param name="command">A string containing any arbitrary message to be
        /// passed to recipient(s)</param>
        public CommandMessage(object sender, string command)
            : base(sender)
        {
            Command = command;
        }

        /// <summary>
        /// Initializes a new instance of the CommandMessage class.
        /// </summary>
        /// <param name="sender">The message's sender.</param>
        /// <param name="target">The message's intended target. This parameter can be used
        /// to give an indication as to whom the message was intended for. Of course
        /// this is only an indication, amd may be null.</param>
        /// <param name="command">A string containing any arbitrary message to be
        /// passed to recipient(s)</param>
        public CommandMessage(object sender, object target, string command)
            : base(sender, target)
        {
            Command = command;
        }

        /// <summary>
        /// Gets a string containing any arbitrary message to be
        /// passed to recipient(s).
        /// </summary>
        public string Command
        {
            get;
            private set;
        }
    }
}