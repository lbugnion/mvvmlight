// ****************************************************************************
// <copyright file="ShutdownService.cs" company="GalaSoft Laurent Bugnion">
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

using System.Windows;
using CleanShutdown.Messaging;
using GalaSoft.MvvmLight.Messaging;

namespace CleanShutdown.Helpers
{
    public static class ShutdownService
    {
        public static void RequestShutdown()
        {
            var shouldAbortShutdown = false;

            Messenger.Default.Send(new NotificationMessageAction<bool>(
                                       Notifications.ConfirmShutdown,
                                       shouldAbort => shouldAbortShutdown |= shouldAbort));

            if (!shouldAbortShutdown)
            {
                // This time it is for real
                Messenger.Default.Send(new CommandMessage(Notifications.NotifyShutdown));

                Application.Current.Shutdown();
            }
        }
    }
}