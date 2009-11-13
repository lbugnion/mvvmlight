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
using System.Windows.Markup;

namespace CleanShutdown.Helpers
{
    public class SettingsFileHandler
    {
        public const string ApplicationFolderName = "CleanShutdownDemo";

        private FileInfo _settingsFile;

        public Settings LoadSettings()
        {
            InitializeSettingsFile();

            try
            {
                using (var fileStream = File.Open(_settingsFile.FullName, FileMode.Open))
                {
                    var settings = XamlReader.Load(fileStream) as Settings;
                    return settings;
                }
            }
            catch (DirectoryNotFoundException)
            {
                return Settings.GetDefaultSettings();
            }
            catch (FileNotFoundException)
            {
                return Settings.GetDefaultSettings();
            }
            catch (XamlParseException)
            {
                return Settings.GetDefaultSettings();
            }
        }

        public void SaveSettings(Settings settings)
        {
            InitializeSettingsFile();

            if (!_settingsFile.Directory.Exists)
            {
                _settingsFile.Directory.Create();
            }

            using (var stream = File.Open(_settingsFile.FullName, FileMode.Create))
            {
                XamlWriter.Save(settings, stream);
            }
        }

        private void InitializeSettingsFile()
        {
            if (_settingsFile == null)
            {
                // In a real application, we would use Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                var applicationDataPath = Path.GetTempPath();

                var settingsFolderPath = Path.Combine(applicationDataPath, ApplicationFolderName);
                _settingsFile = new FileInfo(Path.Combine(settingsFolderPath, Settings.SettingsFileName));
            }
        }
    }
}