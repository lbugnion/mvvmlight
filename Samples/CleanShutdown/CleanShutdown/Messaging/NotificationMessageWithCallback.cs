// ****************************************************************************
// <copyright file="NotificationMessageWithCallback.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>15.10.2009</date>
// <project>CleanShutdown</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using GalaSoft.MvvmLight.Messaging;

namespace CleanShutdown.Messaging
{
    public class NotificationMessageWithCallback : CommandMessage
    {
        private readonly Delegate _callback;

        public NotificationMessageWithCallback(string notification, Delegate callback)
            : base(notification)
        {
            _callback = callback;
        }

        public virtual object Execute(params object[] arguments)
        {
            if (_callback != null)
            {
                return _callback.DynamicInvoke(arguments);
            }

            return null;
        }
    }
}