// ****************************************************************************
// <copyright file="SerializedSettings.cs" company="GalaSoft Laurent Bugnion">
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

using MvvmLightToolkit.Setup.Configure.ViewModel;

namespace MvvmLightToolkit.Setup.Configure.Helpers
{
    /// <summary>
    /// A helper class holding settings saved in the Settings file.
    /// </summary>
    public class SerializedSettings
    {
        /// <summary>
        /// Initializes a new instance of the SerializedSettings class.
        /// </summary>
        public SerializedSettings()
        {
            InstallType = InstallType.WpfAndSilverlight;
        }

        /// <summary>
        /// Gets or sets the currently installed version on this machine.
        /// </summary>
        public string InstalledVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of installation that the setup must execute (WPF, Silverlight or both).
        /// </summary>
        public InstallType InstallType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the path in which the code snippets are copied.
        /// </summary>
        public string SnippetsPath
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the path in which the project and item templates are copied.
        /// </summary>
        public string TemplatesPath
        {
            get;
            set;
        }
    }
}