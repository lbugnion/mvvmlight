// ****************************************************************************
// <copyright file="Settings.cs" company="GalaSoft Laurent Bugnion">
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

using System.Windows.Media;

namespace CleanShutdown.Helpers
{
    public partial class Settings
    {
        public const string SettingsFileName = "Settings.xaml";

        public Brush ApplicationBackgroundBrush
        {
            get;
            set;
        }

        internal static Settings GetDefaultSettings()
        {
            var settings = new Settings
            {
                ApplicationBackgroundBrush = new SolidColorBrush(Colors.Purple)
            };

            return settings;
        }
    }
}