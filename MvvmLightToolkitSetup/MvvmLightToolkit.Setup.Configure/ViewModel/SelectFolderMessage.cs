// ****************************************************************************
// <copyright file="SelectFolderMessage.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>27.6.2009</date>
// <project>MvvmLightToolkit.Setup.Configure</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this project or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.IO;
using GalaSoft.MvvmLight.Messaging;

namespace MvvmLightToolkit.Setup.Configure.ViewModel
{
    /// <summary>
    /// A message instructing the receiver to select a folder
    /// and to return it to the sender using a callback.
    /// </summary>
    public class SelectFolderMessage : GenericMessage<DirectoryInfo>
    {
        /// <summary>
        /// Initializes a new instance of the SelectFolderMessage class.
        /// </summary>
        /// <param name="sender">The mesage's sender.</param>
        /// <param name="folderKind">The type of folder to select.</param>
        /// <param name="currentFolder">The currently selected folder for this kind.</param>
        /// <param name="description">The description to display in the folder browser dialog.</param>
        /// <param name="callback">The callback to be executed when the folder has been selected.</param>
        public SelectFolderMessage(
            object sender,
            Folder folderKind,
            DirectoryInfo currentFolder,
            string description,
            Action<Folder, DirectoryInfo> callback)
            : base(sender, currentFolder)
        {
            FolderKind = folderKind;
            Description = description;
            Callback = callback;
        }

        /// <summary>
        /// Gets the callback to be executed when the folder has been selected.
        /// </summary>
        public Action<Folder, DirectoryInfo> Callback
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the description to display in the folder browser dialog.
        /// </summary>
        public string Description
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the kind of folder that must be selected.
        /// </summary>
        public Folder FolderKind
        {
            get;
            private set;
        }
    }
}