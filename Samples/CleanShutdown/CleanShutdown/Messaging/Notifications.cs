// ****************************************************************************
// <copyright file="Notifications.cs" company="GalaSoft Laurent Bugnion">
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
    public static class Notifications
    {
        public static readonly string ConfirmShutdown = Guid.NewGuid().ToString();

        public static readonly string NotifyShutdown = Guid.NewGuid().ToString();
    }
}