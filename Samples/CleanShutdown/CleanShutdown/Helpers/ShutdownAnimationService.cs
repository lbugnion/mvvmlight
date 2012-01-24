// ****************************************************************************
// <copyright file="ShutdownAnimationService.cs" company="GalaSoft Laurent Bugnion">
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
using System.Windows;
using System.Windows.Media.Animation;
using CleanShutdown.Messaging;
using GalaSoft.MvvmLight.Messaging;

namespace CleanShutdown.Helpers
{
    public class ShutdownAnimationService
    {
        private bool _shutdownAnimationHasRun;

        public ShutdownAnimationService(FrameworkElement element)
        {
            Messenger.Default.Register<NotificationMessageAction<bool>>(
                this,
                message =>
                {
                    if (message.Command == Notifications.ConfirmShutdown)
                    {
                        if (!_shutdownAnimationHasRun)
                        {
                            var sbd =
                                element.Resources["ShutdownStoryboard"] as Storyboard;
                            if (sbd != null)
                            {
                                message.Execute(true);
                                    // true == abort shutdown

                                sbd.Completed += ShutdownStoryboardCompleted;
                                sbd.Begin();
                            }
                        }

                        // If the animation ran already, no need to reply
                        // to the message, allow shutdown.
                    }
                });
        }

        private void ShutdownStoryboardCompleted(object sender, EventArgs e)
        {
            _shutdownAnimationHasRun = true;

            // Now that our pre-shutdown task is done, we can request shutdown again.
            ShutdownService.RequestShutdown();
        }
    }
}