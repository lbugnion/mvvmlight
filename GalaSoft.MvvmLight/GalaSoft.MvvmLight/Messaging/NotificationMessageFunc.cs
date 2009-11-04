using System;

////using GalaSoft.Utilities.Attributes;

namespace GalaSoft.MvvmLight.Messaging
{
    public class NotificationMessageFunc<TResult> : NotificationMessageWithCallback
    {
        public NotificationMessageFunc(string notification, Func<TResult> callback)
            : base(notification, callback)
        {
        }

        public NotificationMessageFunc(object sender, string notification, Func<TResult> callback)
            : base(sender, notification, callback)
        {
        }

        public NotificationMessageFunc(object sender, object target, string notification, Func<TResult> callback)
            : base(sender, target, notification, callback)
        {
        }

        public TResult Execute()
        {
            return (TResult) base.Execute();
        }
    }

    public class NotificationMessageFunc<TCallbackParameter, TResult> : NotificationMessageWithCallback
    {
        public NotificationMessageFunc(string notification, Func<TCallbackParameter, TResult> callback)
            : base(notification, callback)
        {
        }

        public NotificationMessageFunc(object sender, string notification, Func<TCallbackParameter, TResult> callback)
            : base(sender, notification, callback)
        {
        }

        public NotificationMessageFunc(object sender,
                                       object target,
                                       string notification,
                                       Func<TCallbackParameter, TResult> callback)
            : base(sender, target, notification, callback)
        {
        }

        public TResult Execute(TCallbackParameter parameter)
        {
            return (TResult) base.Execute(parameter);
        }
    }
}