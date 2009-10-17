// ****************************************************************************
// <copyright file="ViewModelLocator.cs" company="GalaSoft Laurent Bugnion">
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

using System.Diagnostics.CodeAnalysis;

namespace MvvmLightToolkit.Setup.Configure.ViewModel
{
    /// <summary>
    /// Provides a central static way to create and locate ViewModels.
    /// </summary>
    public class ViewModelLocator
    {
        private static MainViewModel _main;

        private static SettingsViewModel _settings;

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            CreateMain();
            CreateSettings();
        }

        /// <summary>
        /// Gets an instance of the MainViewModel class. If needed, creates it first.
        /// </summary>
        /// <returns>The instance of the MainViewModel class.</returns>
        public static MainViewModel MainStatic
        {
            get
            {
                if (_main == null)
                {
                    CreateMain();
                }

                return _main;
            }
        }

        public static SettingsViewModel OldSettings
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets an instance of the SettingsViewModel class. If needed, creates it first.
        /// </summary>
        /// <returns>The instance of the SettingsViewModel class.</returns>
        public static SettingsViewModel SettingsStatic
        {
            get
            {
                if (_settings == null)
                {
                    CreateSettings();
                }

                return _settings;
            }
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return MainStatic;
            }
        }

        /// <summary>
        /// Gets the Settings property.
        /// </summary>
        [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public SettingsViewModel Settings
        {
            get
            {
                return SettingsStatic;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the Main property.
        /// </summary>
        public static void ClearMain()
        {
            if (_main != null)
            {
                _main.Dispose();
                _main = null;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the Settings property.
        /// </summary>
        public static void ClearSettings()
        {
            if (_settings != null)
            {
                _settings.Dispose();
                _settings = null;
            }
        }

        /// <summary>
        /// Provides a deterministic way to create the Main property.
        /// </summary>
        public static void CreateMain()
        {
            if (_main == null)
            {
                _main = new MainViewModel();
            }
        }

        /// <summary>
        /// Provides a deterministic way to create the Settings property.
        /// </summary>
        public static void CreateSettings()
        {
            if (_settings == null)
            {
                _settings = new SettingsViewModel();
                OldSettings = _settings.Clone();
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Dispose()
        {
            ClearMain();
            ClearSettings();
        }
    }
}