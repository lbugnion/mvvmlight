// ****************************************************************************
// <copyright file="MainWindow.xaml.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>1.10.2009</date>
// <project>MvvmLightToolkit.Setup.Configure</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Messaging;
using MvvmLightToolkit.Setup.Configure.Helpers;
using MvvmLightToolkit.Setup.Configure.Log;
using MvvmLightToolkit.Setup.Configure.ViewModel;
using MessageBox = System.Windows.MessageBox;

namespace MvvmLightToolkit.Setup.Configure
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMessageRecipient
    {
        private bool _isInstallPressed;

        /// <summary>
        /// Initializes static members of the <see cref="MainWindow" /> class.
        /// </summary>
        static MainWindow()
        {
            Logger = new Logger();
        }

        public MainWindow()
        {
            Messenger.Default.Register(this, typeof(DialogMessage));
            Messenger.Default.Register(this, typeof(CommandMessage));
            Messenger.Default.Register(this, typeof(SelectFolderMessage));
            Messenger.Default.Register(this, typeof(GenericMessage<Exception>));
            Messenger.Default.Register(this, typeof(PropertyChangedMessage<bool>));

            InitializeComponent();

            Closing += (s, e) =>
            {
                if (!this._isInstallPressed)
                {
                    var exception = new InvalidOperationException(Properties.Resources.UserCancelledException);
                    CommitException = exception;
                }
            };
        }

        /// <summary>
        /// Gets the logger for this application.
        /// </summary>
        public static Logger Logger
        {
            get;
            private set;
        }

        public ICommit Caller
        {
            get;
            set;
        }

        internal Exception CommitException
        {
            set
            {
                if (Caller == null)
                {
                    return;
                }

                Caller.CommitException = value;
                Shutdown();
            }
        }

        /// <summary>
        /// Receives and handles messages sent by the Messenger.
        /// <para>The following types are handled:</para>
        /// <list type="bullet">
        /// <item>DialogMessage: Displays a message box</item>
        /// <item>CommandMessage: Executes a command</item>
        /// <item>SelectFolderMessage: Displays a "Select folder" dialog to the user</item>
        /// <item>GenericMessage&lt;Exception&gt;: Handles an exception by passing
        /// it to installer.</item>
        /// <item>PropertyChangedMessage&lt;bool&gt;: Handles the changes to the
        /// MainViewModel.IsInstallPressed property.</item>
        /// </list>
        /// </summary>
        /// <param name="message">The message to handle.</param>
        public void ReceiveMessage(MessageBase message)
        {
            var dialogMessage = message as DialogMessage;
            if (dialogMessage != null)
            {
                var result = MessageBox.Show(
                    dialogMessage.Content,
                    dialogMessage.Caption,
                    dialogMessage.Button,
                    dialogMessage.Icon);

                if (dialogMessage.Callback != null)
                {
                    dialogMessage.Callback(result);
                }

                return;
            }

            var commandMessage = message as CommandMessage;
            if (commandMessage != null)
            {
                if (commandMessage.Command
                    == Commands.Shutdown)
                {
                    Shutdown();
                }

                return;
            }

            var selectFolderMessage = message as SelectFolderMessage;
            if (selectFolderMessage != null)
            {
                var dialog = new FolderBrowserDialog
                {
                    Description = selectFolderMessage.Description
                };

                if (selectFolderMessage.Content != null)
                {
                    dialog.SelectedPath = selectFolderMessage.Content.FullName;
                }

                dialog.ShowNewFolderButton = false; // There are some problems with the new folder button

                DirectoryInfo selectedFolder = null;
                if (dialog.ShowDialog()
                    == System.Windows.Forms.DialogResult.OK)
                {
                    selectedFolder = new DirectoryInfo(dialog.SelectedPath);
                }

                selectFolderMessage.Callback(
                    selectFolderMessage.FolderKind,
                    selectedFolder);

                return;
            }

            var exceptionMessage = message as GenericMessage<Exception>;
            if (exceptionMessage != null)
            {
                CommitException = exceptionMessage.Content;
                return;
            }

            var propertyMessage = message as PropertyChangedMessage<bool>;
            if (propertyMessage != null
                && propertyMessage.PropertyName == MainViewModel.IsInstallPressedPropertyName)
            {
                this._isInstallPressed = propertyMessage.Content;
                return;
            }
        }

        private void Shutdown()
        {
            ViewModelLocator.Dispose();
            Dispatcher.BeginInvoke((ThreadStart) Close);
        }
    }
}