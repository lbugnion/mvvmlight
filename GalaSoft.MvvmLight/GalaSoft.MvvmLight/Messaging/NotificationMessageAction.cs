using System;

////using GalaSoft.Utilities.Attributes;

namespace GalaSoft.MvvmLight.Messaging
{
    public class NotificationMessageAction : NotificationMessageWithCallback
    {
        public NotificationMessageAction(string notification, Action callback)
            : base(notification, callback)
        {
        }

        public NotificationMessageAction(object sender, string notification, Action callback)
            : base(sender, notification, callback)
        {
        }

        public NotificationMessageAction(object sender, object target, string notification, Action callback)
            : base(sender, target, notification, callback)
        {
        }

        public void Execute()
        {
            base.Execute();
        }
    }

    public class NotificationMessageAction<TCallbackParameter> : NotificationMessageWithCallback
    {
        public NotificationMessageAction(string notification, Action<TCallbackParameter> callback)
            : base(notification, callback)
        {
        }

        public NotificationMessageAction(object sender, string notification, Action<TCallbackParameter> callback)
            : base(sender, notification, callback)
        {
        }

        public NotificationMessageAction(object sender,
                                         object target,
                                         string notification,
                                         Action<TCallbackParameter> callback)
            : base(sender, target, notification, callback)
        {
        }

        public void Execute(TCallbackParameter parameter)
        {
            base.Execute(parameter);
        }
    }
}