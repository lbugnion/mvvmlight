// ****************************************************************************
// <copyright file="SettingsFileHandler.cs" company="GalaSoft Laurent Bugnion">
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
using System.IO;
using System.Windows.Markup;
using System.Xml;
using MvvmLightToolkit.Setup.Configure.ViewModel;
using System.Diagnostics.CodeAnalysis;

namespace MvvmLightToolkit.Setup.Configure.Helpers
{
    /// <summary>
    /// Handles reading and saving the settings file.
    /// </summary>
    public class SettingsFileHandler
    {
        internal const string NoInstalledVersion = "0.0.0.0";

        internal const string SettingsFileName = "SetupSettings.xaml";

        private const string AppDataFolderName = "MvvmLightSetup";

        private const string BlendFolderSubPath = @"Expression{0}Blend 3";

        private const string SnippetsSubPath = @"Visual Studio 2008{0}Code Snippets{0}Visual C#{0}My Code Snippets";

        private const string TemplatesSubPath = @"Visual Studio 2008{0}Templates";

        private readonly FileInfo _settingsFile;

        public SettingsFileHandler()
        {
            var appDataFolder = AppDataFolder;
            _settingsFile = new FileInfo(Path.Combine(appDataFolder.FullName, SettingsFileName));
        }

        public static DirectoryInfo AppDataFolder
        {
            get
            {
                var appDataFolder = new DirectoryInfo(Path.Combine(
                                                          Environment.GetFolderPath(
                                                              Environment.SpecialFolder.ApplicationData),
                                                          AppDataFolderName));

                if (!appDataFolder.Exists)
                {
                    appDataFolder.Create();
                }

                return appDataFolder;
            }
        }

        public static DirectoryInfo BlendDocumentsFolder
        {
            get
            {
                var blendDocumentsFolder = new DirectoryInfo(Path.Combine(
                                                                 Environment.GetFolderPath(
                                                                     Environment.SpecialFolder.MyDocuments),
                                                                 Installer.Format(BlendFolderSubPath)));

                if (!blendDocumentsFolder.Exists)
                {
                    blendDocumentsFolder.Create();
                }

                return blendDocumentsFolder;
            }
        }

        public SerializedSettings SavedSettings
        {
            get
            {
                SerializedSettings savedSettings = null;

                if (_settingsFile.Exists)
                {
                    using (var stream = new FileStream(_settingsFile.FullName, FileMode.Open))
                    {
                        try
                        {
                            savedSettings = XamlReader.Load(stream) as SerializedSettings;
                        }
                        catch (XamlParseException)
                        {
                            savedSettings = TryRepairSettingsFile();
                        }
                    }
                }

                if (savedSettings == null)
                {
                    savedSettings = new SerializedSettings
                    {
                        SnippetsPath = Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                            Installer.Format(SnippetsSubPath)),
                        TemplatesPath = Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                            Installer.Format(TemplatesSubPath)),
                        InstalledVersion = NoInstalledVersion
                    };
                }

                return savedSettings;
            }
        }

        public void Save(
            InstallType installType,
            string snippetsPath,
            string templatesPath,
            string installedVersion)
        {
            var savedSettings = new SerializedSettings
            {
                InstallType = installType,
                SnippetsPath = snippetsPath,
                TemplatesPath = templatesPath,
                InstalledVersion = installedVersion
            };

            Save(savedSettings);
        }

        private void Save(SerializedSettings savedSettings)
        {
            if (!Directory.Exists(_settingsFile.DirectoryName))
            {
                Directory.CreateDirectory(_settingsFile.DirectoryName);
            }

            using (var writer = new StreamWriter(_settingsFile.FullName, false))
            {
                XamlWriter.Save(savedSettings, writer);
            }
        }

        [SuppressMessage(
            "Microsoft.Design", 
            "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification = "This is a last resort catch, and should not crash the application.")]
        private SerializedSettings TryRepairSettingsFile()
        {
            SerializedSettings settings;

            try
            {
                var xmlDoc = new XmlDocument();

                using (var stream = new FileStream(_settingsFile.FullName, FileMode.Open))
                {
                    xmlDoc.Load(stream);
                }

                if (xmlDoc.DocumentElement != null)
                {
                    var xmlNamespace = xmlDoc.DocumentElement.NamespaceURI;
                    var newNamespace = xmlNamespace.Replace("Custom", "Configure");

                    xmlDoc.DocumentElement.SetAttribute("xmlns", newNamespace);

                    using (var stream = new FileStream(_settingsFile.FullName, FileMode.Create))
                    {
                        xmlDoc.Save(stream);
                    }
                }

                using (var stream = new FileStream(_settingsFile.FullName, FileMode.Open))
                {
                    settings = XamlReader.Load(stream) as SerializedSettings;
                }
            }
            catch
            {
                settings = null;
            }

            return settings;
        }
    }
}