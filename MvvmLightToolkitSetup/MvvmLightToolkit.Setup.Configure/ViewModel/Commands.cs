// ****************************************************************************
// <copyright file="Commands.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>26.6.2009</date>
// <project>MvvmLightToolkit.Setup.Configure</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this project or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;

namespace MvvmLightToolkit.Setup.Configure.ViewModel
{
    /// <summary>
    /// Defines commands that can be used to broadcast CommandMessage using the
    /// GalaSoft.MvvmLight.Messaging.Messenger class.
    /// </summary>
    public static class Commands
    {
        /// <summary>
        /// Command used to display the Main control.
        /// </summary>
        public static readonly string ShowMain = Guid.NewGuid().ToString();

        /// <summary>
        /// Command used to display the Settings control.
        /// </summary>
        public static readonly string ShowSettings = Guid.NewGuid().ToString();

        /// <summary>
        /// Command used to shut down the application.
        /// </summary>
        public static readonly string Shutdown = Guid.NewGuid().ToString();
    }
}