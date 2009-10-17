// ****************************************************************************
// <copyright file="CustomActions.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>27.8.2009</date>
// <project>MvvmLightToolkit.Setup.Custom</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Threading;
using MvvmLightToolkit.Setup.Configure;
using MvvmLightToolkit.Setup.Configure.Helpers;
using MvvmLightToolkit.Setup.Configure.ViewModel;

namespace MvvmLightToolkit.Setup.Custom
{
    /// <summary>
    /// Contains the custom actions for the MVVM Light Toolkit installer.
    /// </summary>
    [RunInstaller(true)]
    public partial class CustomActions : Installer, ICommit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomActions" /> class.
        /// </summary>
        public CustomActions()
        {
            InitializeComponent();
        }

        public Exception CommitException
        {
            get;
            set;
        }

        /// <summary>
        /// Moves the necessary files into place after the installation.
        /// </summary>
        /// <param name="savedState">The saved state for the installation.</param>
        protected override void OnAfterInstall(IDictionary savedState)
        {
            var worker = new Thread(() =>
            {
                var window = new MainWindow
                {
                    Caller = this
                };
                window.ShowDialog();
            });
            worker.SetApartmentState(ApartmentState.STA);
            worker.Start();
            worker.Join();

            if (CommitException != null)
            {
                throw new InstallException("Commit action failed", CommitException);
            }

            base.OnAfterInstall(savedState);
        }

        /// <summary>
        /// Called when the installation is rolled back. Uninstalls the toolkit.
        /// </summary>
        /// <param name="savedState">The saved state for the installation.</param>
        protected override void OnBeforeRollback(IDictionary savedState)
        {
            Uninstall();
            base.OnBeforeRollback(savedState);
        }

        /// <summary>
        /// Called when the toolkit is uninstalled.
        /// </summary>
        /// <param name="savedState">The saved state for the installation.</param>
        protected override void OnBeforeUninstall(IDictionary savedState)
        {
            Uninstall();
            base.OnBeforeUninstall(savedState);
        }

        private static void Uninstall()
        {
            var locator = new ViewModelLocator();
            if (locator.Main.CanUninstall)
            {
                locator.Main.Uninstall();
            }
        }
    }
}