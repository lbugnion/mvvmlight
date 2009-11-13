// ****************************************************************************
// <copyright file="NotificationMessageFunc.cs" company="GalaSoft Laurent Bugnion">
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
    public class NotificationMessageFunc<TResult> : NotificationMessageWithCallback
    {
        public NotificationMessageFunc(string notification, Func<TResult> callback)
            : base(notification, callback)
        {
        }

        public TResult Execute()
        {
            return (TResult) base.Execute();
        }
    }

    public class NotificationMessageFunc<T, TResult> : NotificationMessageWithCallback
    {
        public NotificationMessageFunc(string notification, Func<TResult> callback)
            : base(notification, callback)
        {
        }

        public TResult Execute(T p1)
        {
            return (TResult) base.Execute(p1);
        }
    }

    public class NotificationMessageFunc<T1, T2, TResult> : NotificationMessageWithCallback
    {
        public NotificationMessageFunc(string notification, Func<T1, T2, TResult> callback)
            : base(notification, callback)
        {
        }

        public TResult Execute(T1 p1, T2 p2)
        {
            return (TResult) base.Execute(p1, p2);
        }
    }

    public class NotificationMessageFunc<T1, T2, T3, TResult> : NotificationMessageWithCallback
    {
        public NotificationMessageFunc(string notification, Func<T1, T2, T3> callback)
            : base(notification, callback)
        {
        }

        public TResult Execute(T1 p1, T2 p2, T3 p3)
        {
            return (TResult) base.Execute(p1, p2, p3);
        }
    }

    public class NotificationMessageFunc<T1, T2, T3, T4, TResult> : NotificationMessageWithCallback
    {
        public NotificationMessageFunc(string notification, Func<T1, T2, T3, T4, TResult> callback)
            : base(notification, callback)
        {
        }

        public TResult Execute(T1 p1, T2 p2, T3 p3, T4 p4)
        {
            return (TResult) base.Execute(p1, p2, p3, p4);
        }
    }
}