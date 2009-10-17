// ****************************************************************************
// <copyright file="App.xaml.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>12.9.2009</date>
// <project>GalaSoft.MvvmLight.CheckVersion</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Collections.Generic;
using System.Windows;
using GalaSoft.MvvmLight.CheckVersion.ViewModel;
using GalaSoft.MvvmLight.Messaging;

namespace GalaSoft.MvvmLight.CheckVersion
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private static List<Func<bool>> _shutdownConfirmations;

        public void ReceiveCommandMessage(CommandMessage message)
        {
            if (message != null
                && message.Command == Commands.RequestShutdown)
            {
                ConfirmShutdown();
            }
        }

        public void ReceiveCommandMessageGeneric(CommandMessage<Func<bool>> message)
        {
            if (message != null
                && message.Command == Commands.RequestShutdownNotification)
            {
                RegisterForShutdown(message.Content);
            }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Messenger.Default.Register<CommandMessage>(this, ReceiveCommandMessage);
            Messenger.Default.Register<CommandMessage<Func<bool>>>(this, ReceiveCommandMessageGeneric);

            base.OnStartup(e);
        }

        private static void RegisterForShutdown(Func<bool> confirmShutdown)
        {
            if (confirmShutdown == null)
            {
                return;
            }

            if (_shutdownConfirmations == null)
            {
                _shutdownConfirmations = new List<Func<bool>>();
            }

            _shutdownConfirmations.Add(confirmShutdown);
        }

        private void ConfirmShutdown()
        {
            var shutdownOk = true;

            if (_shutdownConfirmations != null)
            {
                foreach (var f in _shutdownConfirmations)
                {
                    if (!f())
                    {
                        shutdownOk = false;
                        break;
                    }
                }
            }

            if (shutdownOk)
            {
                Shutdown();
            }
        }
    }
}