// ****************************************************************************
// <copyright file="NotificationMessageAction.cs" company="GalaSoft Laurent Bugnion">
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

namespace CleanShutdown.Messaging
{
    public class NotificationMessageAction : NotificationMessageWithCallback
    {
        public NotificationMessageAction(string notification, Action callback)
            : base(notification, callback)
        {
        }

        public void Execute()
        {
            base.Execute();
        }
    }

    public class NotificationMessageAction<T> : NotificationMessageWithCallback
    {
        public NotificationMessageAction(string notification, Action<T> callback)
            : base(notification, callback)
        {
        }

        public void Execute(T p1)
        {
            base.Execute(p1);
        }
    }

    public class NotificationMessageAction<T1, T2> : NotificationMessageWithCallback
    {
        public NotificationMessageAction(string notification, Action<T1, T2> callback)
            : base(notification, callback)
        {
        }

        public void Execute(T1 p1, T2 p2)
        {
            base.Execute(p1, p2);
        }
    }

    public class NotificationMessageAction<T1, T2, T3> : NotificationMessageWithCallback
    {
        public NotificationMessageAction(string notification, Action<T1, T2, T3> callback)
            : base(notification, callback)
        {
        }

        public void Execute(T1 p1, T2 p2, T3 p3)
        {
            base.Execute(p1, p2, p3);
        }
    }

    public class NotificationMessageAction<T1, T2, T3, T4> : NotificationMessageWithCallback
    {
        public NotificationMessageAction(string notification, Action<T1, T2, T3, T4> callback)
            : base(notification, callback)
        {
        }

        public void Execute(T1 p1, T2 p2, T3 p3, T4 p4)
        {
            base.Execute(p1, p2, p3, p4);
        }
    }
}