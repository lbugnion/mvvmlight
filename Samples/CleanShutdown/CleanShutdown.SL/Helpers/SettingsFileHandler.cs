// ****************************************************************************
// <copyright file="SettingsFileHandler.cs" company="GalaSoft Laurent Bugnion">
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

using System.IO;
using System.IO.IsolatedStorage;

namespace CleanShutdown.Helpers
{
    public class SettingsFileHandler
    {
        public Settings LoadSettings()
        {
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (store.FileExists(Settings.SettingsFileName))
                {
                    using (var stream = store.OpenFile(Settings.SettingsFileName, FileMode.Open))
                    {
                        return Settings.Deserialize(stream);
                    }
                }
            }

            return Settings.GetDefaultSettings();
        }

        public void SaveSettings(Settings settings)
        {
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var stream = store.OpenFile(Settings.SettingsFileName, FileMode.Create))
                {
                    Settings.Serialize(settings, stream);
                }
            }
        }
    }
}