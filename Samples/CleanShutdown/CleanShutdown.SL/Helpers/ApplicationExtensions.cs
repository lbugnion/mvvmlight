// ****************************************************************************
// <copyright file="ApplicationExtensions.cs" company="GalaSoft Laurent Bugnion">
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
using System.Windows.Browser;
using System;

namespace CleanShutdown.Helpers
{
    public static class ApplicationExtensions
    {
        public static void Shutdown(this Application app)
        {
            HtmlPage.Window.Navigate(new Uri("http://www.galasoft.ch", UriKind.Absolute));
        }
    }
}