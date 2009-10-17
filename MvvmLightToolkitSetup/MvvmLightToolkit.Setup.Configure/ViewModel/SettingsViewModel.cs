// ****************************************************************************
// <copyright file="SettingsViewModel.cs" company="GalaSoft Laurent Bugnion">
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
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Reflection;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MvvmLightToolkit.Setup.Configure.Helpers;
using MvvmLightToolkit.Setup.Configure.Properties;

namespace MvvmLightToolkit.Setup.Configure.ViewModel
{
    /// <summary>
    /// Indicates which installation must be executed (WPF, Silverlight or both).
    /// </summary>
    public enum InstallType
    {
        /// <summary>
        /// Install only the WPF MVVM toolkit.
        /// </summary>
        WpfOnly = 0,

        /// <summary>
        /// Install only the Silverlight MVVM toolkit.
        /// </summary>
        SilverlightOnly = 1,

        /// <summary>
        /// Install both the WPF and the Silverlight MVVM toolkit.
        /// </summary>
        WpfAndSilverlight = 2,
    }

    /// <summary>
    /// Defines which folders the user can setup for the install.
    /// </summary>
    public enum Folder
    {
        /// <summary>
        /// The folder in which the snippets will be copied.
        /// </summary>
        SnippetsFolder = 0,

        /// <summary>
        /// The folder in which the templates will be copied (in the
        /// ProjectTemplates and ItemTemplates children folders).
        /// </summary>
        TemplatesFolder = 1,
    }

    /// <summary>
    /// View Model for the Settings control.
    /// </summary>
    public class SettingsViewModel : ViewModelBase
    {
        /// <summary>
        /// The <see cref="InstalledVersion" /> property's name.
        /// </summary>
        public const string InstalledVersionPropertyName = "InstalledVersion";

        /// <summary>
        /// The <see cref="InstallType" /> property's name.
        /// </summary>
        public const string InstallTypePropertyName = "InstallType";

        /// <summary>
        /// The <see cref="IsEnabled" /> property's name.
        /// </summary>
        public const string IsEnabledPropertyName = "IsEnabled";

        /// <summary>
        /// The <see cref="SnippetsFolder" /> property's name.
        /// </summary>
        public const string SnippetsFolderPropertyName = "SnippetsFolder";

        /// <summary>
        /// The <see cref="TemplatesFolder" /> property's name.
        /// </summary>
        public const string TemplatesFolderPropertyName = "TemplatesFolder";

        private const string CheckVersionExeFileName = "GalaSoft.MvvmLight.CheckVersion.exe";

        private const string CheckVersionFolderName = "CheckVersion";

        private const string DllFolderSubPath = @"Binaries";

        private const string ItemsTemplatesSubPathSl = @"ItemTemplates{0}Silverlight{0}Mvvm";

        // Keep "WPF" instead of "Windows"
        private const string ItemsTemplatesSubPathWpf = @"ItemTemplates{0}Visual C#{0}WPF{0}Mvvm";

        private const string ProjectTemplatesSubPathSl = @"ProjectTemplates{0}Silverlight{0}Mvvm";

        private const string ProjectTemplatesSubPathWpf = @"ProjectTemplates{0}Visual C#{0}Windows{0}Mvvm";

        private const string SourceFolderSubPath = @"Source";

        private readonly SettingsFileHandler _settingsFile;

        private readonly bool _suspendSaving;

        private static InstallTypeToCheckedConverter _installTypeConverter;

        private string _installedVersion = SettingsFileHandler.NoInstalledVersion;

        private InstallType _installType = InstallType.WpfAndSilverlight;

        private bool _isEnabled = true;

        private DirectoryInfo _snippetsFolder;

        private DirectoryInfo _templatesFolder;

        /// <summary>
        /// Initializes a new instance of the SettingsViewModel class.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors",
            Justification = "The ViewModelBase method must be called to initialze the bindings.")]
        public SettingsViewModel()
        {
            SelectFolderCommand = new RelayCommand<string>(
                SelectFolder,
                p => this.IsEnabled);

            ShowUrlCommand = new RelayCommand<string>(ShowUrl);

            CheckVersionCommand = new RelayCommand(() =>
            {
                var assembly = new FileInfo(Assembly.GetExecutingAssembly().Location);
                if (assembly.Directory != null
                    && assembly.Directory.Parent != null)
                {
                    var checkVersionFolder = new DirectoryInfo(
                        Path.Combine(assembly.Directory.Parent.FullName, CheckVersionFolderName));

                    if (!checkVersionFolder.Exists)
                    {
                        return;
                    }

                    var checkVersionExe = checkVersionFolder.GetFiles(CheckVersionExeFileName);
                    if (checkVersionExe.Length == 1)
                    {
                        Process.Start(checkVersionExe[0].FullName);
                    }
                }
            });

            _settingsFile = new SettingsFileHandler();
            var settings = _settingsFile.SavedSettings;

            _suspendSaving = true;

            SnippetsFolder = new DirectoryInfo(settings.SnippetsPath);
            TemplatesFolder = new DirectoryInfo(settings.TemplatesPath);
            InstalledVersion = settings.InstalledVersion;
            InstallType = settings.InstallType;

            var assemblyFile = new FileInfo(Assembly.GetExecutingAssembly().Location);
            var assemblyFolder = new DirectoryInfo(assemblyFile.DirectoryName);

            DllFolder = new DirectoryInfo(
                Path.Combine(assemblyFolder.Parent.FullName, DllFolderSubPath));

            SourceFolder = new DirectoryInfo(
                Path.Combine(assemblyFolder.Parent.FullName, SourceFolderSubPath));

            _suspendSaving = false;
        }

        /// <summary>
        /// Gets the converter used to convert the installation type to a boolean, and back.
        /// </summary>
        public static InstallTypeToCheckedConverter InstallTypeToCheckedConverter
        {
            get
            {
                if (_installTypeConverter == null)
                {
                    _installTypeConverter = new InstallTypeToCheckedConverter();
                }

                return _installTypeConverter;
            }
        }

        public RelayCommand CheckVersionCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the DllFolder property.
        /// </summary>
        public DirectoryInfo DllFolder
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the URL to the GalaSoft page online.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic",
            Justification = "Non static member needed for binding")]
        public string GalaSoftLocation
        {
            get
            {
                return Resources.GalaSoftUrl;
            }
        }

        /// <summary>
        /// Gets the URL to the Help page online.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic",
            Justification = "Non static member needed for binding")]
        public string GetHelpLocation
        {
            get
            {
                return Resources.GetHelpUrl;
            }
        }

        /// <summary>
        /// Gets the InstalledVersion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string InstalledVersion
        {
            get
            {
                return _installedVersion;
            }

            internal set
            {
                if (_installedVersion == value)
                {
                    return;
                }

                _installedVersion = value;

                if (_installedVersion
                    != SettingsFileHandler.NoInstalledVersion)
                {
                    SaveSettings();
                }

                RaisePropertyChanged(InstalledVersionPropertyName);
            }
        }

        /// <summary>
        /// Gets or sets the type if installation to be executed.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public InstallType InstallType
        {
            get
            {
                return _installType;
            }

            set
            {
                if (_installType == value)
                {
                    return;
                }

                _installType = value;
                SaveSettings();
                RaisePropertyChanged(InstallTypePropertyName);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the dialog is enabled or disabled.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsEnabled
        {
            get
            {
                return this._isEnabled;
            }

            internal set
            {
                if (this._isEnabled == value)
                {
                    return;
                }

                this._isEnabled = value;

                RaisePropertyChanged(IsEnabledPropertyName);
            }
        }

        /// <summary>
        /// Gets the command that the user executes to select one of 
        /// the folders in the Settings control.
        /// </summary>
        public RelayCommand<string> SelectFolderCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the command that is used to execute a URL (website
        /// or local folder path).
        /// </summary>
        public RelayCommand<string> ShowUrlCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the SnippetsFolder property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DirectoryInfo SnippetsFolder
        {
            get
            {
                return _snippetsFolder;
            }

            private set
            {
                if (_snippetsFolder == value)
                {
                    return;
                }

                _snippetsFolder = value;
                SaveSettings();
                RaisePropertyChanged(SnippetsFolderPropertyName);
            }
        }

        /// <summary>
        /// Gets the folder that holds the source code.
        /// </summary>
        public DirectoryInfo SourceFolder
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the TemplatesFolder property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DirectoryInfo TemplatesFolder
        {
            get
            {
                return _templatesFolder;
            }

            private set
            {
                if (_templatesFolder == value)
                {
                    return;
                }

                var projectSubPathWpf = string.Format(
                    CultureInfo.CurrentCulture,
                    ProjectTemplatesSubPathWpf,
                    Path.DirectorySeparatorChar);

                ProjectTemplatesFolderWpf = new DirectoryInfo(Path.Combine(
                                                                  value.FullName,
                                                                  projectSubPathWpf));

                var projectSubPathSl = string.Format(
                    CultureInfo.CurrentCulture,
                    ProjectTemplatesSubPathSl,
                    Path.DirectorySeparatorChar);

                ProjectTemplatesFolderSl = new DirectoryInfo(Path.Combine(
                                                                 value.FullName,
                                                                 projectSubPathSl));

                var itemSubPathWpf = string.Format(
                    CultureInfo.CurrentCulture,
                    ItemsTemplatesSubPathWpf,
                    Path.DirectorySeparatorChar);

                ItemTemplatesFolderWpf = new DirectoryInfo(Path.Combine(
                                                               value.FullName,
                                                               itemSubPathWpf));

                var itemSubPathSl = string.Format(
                    CultureInfo.CurrentCulture,
                    ItemsTemplatesSubPathSl,
                    Path.DirectorySeparatorChar);

                ItemTemplatesFolderSl = new DirectoryInfo(Path.Combine(
                                                              value.FullName,
                                                              itemSubPathSl));

                _templatesFolder = value;
                SaveSettings();
                RaisePropertyChanged(TemplatesFolderPropertyName);
            }
        }

        internal DirectoryInfo ItemTemplatesFolderSl
        {
            get;
            private set;
        }

        internal DirectoryInfo ItemTemplatesFolderWpf
        {
            get;
            private set;
        }

        internal DirectoryInfo ProjectTemplatesFolderSl
        {
            get;
            private set;
        }

        internal DirectoryInfo ProjectTemplatesFolderWpf
        {
            get;
            private set;
        }

        public SettingsViewModel Clone()
        {
            var vm = new SettingsViewModel
            {
                IsEnabled = this.IsEnabled,
                DllFolder = this.DllFolder,
                InstalledVersion = this.InstalledVersion,
                InstallType = this.InstallType,
                SnippetsFolder = this.SnippetsFolder,
                SourceFolder = this.SourceFolder,
                TemplatesFolder = this.TemplatesFolder
            };
            return vm;
        }

        internal void SaveSettings()
        {
            if (_suspendSaving)
            {
                return;
            }

            _settingsFile.Save(
                InstallType,
                SnippetsFolder.FullName,
                TemplatesFolder.FullName,
                InstalledVersion);
        }

        private static void ShowUrl(string url)
        {
            Process.Start(url);
        }

        private void SelectFolder(string folderKind)
        {
            var folderKindEnum = (Folder) Enum.Parse(typeof(Folder), folderKind);

            DirectoryInfo currentFolder = null;
            var description = string.Empty;
            switch (folderKindEnum)
            {
                case Folder.SnippetsFolder:
                    currentFolder = SnippetsFolder;
                    description = Resources.SnippetsFolderBrowserDialogDescription;
                    break;
                case Folder.TemplatesFolder:
                    currentFolder = TemplatesFolder;
                    description = Resources.TemplatesFolderBrowserDialogDescription;
                    break;
            }

            var message = new SelectFolderMessage(
                this,
                folderKindEnum,
                currentFolder,
                description,
                SetNewFolder);

            Messenger.Default.Broadcast(message);
        }

        private void SetNewFolder(Folder folderkind, DirectoryInfo folder)
        {
            if (folder == null)
            {
                return;
            }

            switch (folderkind)
            {
                case Folder.SnippetsFolder:
                    SnippetsFolder = folder;
                    MainWindow.Logger.Log("SetNewFolder SnippetsFolder " + SnippetsFolder.FullName);
                    break;
                case Folder.TemplatesFolder:
                    TemplatesFolder = folder;
                    MainWindow.Logger.Log("SetNewFolder TemplatesFolder " + TemplatesFolder.FullName);
                    break;
            }
        }
    }
}