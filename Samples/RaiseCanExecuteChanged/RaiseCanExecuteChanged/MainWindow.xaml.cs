// ****************************************************************************
// <copyright file="MainWindow.xaml.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>26.9.2009</date>
// <project>GalaSoft.Samples.RaiseCanExecuteChanged</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_ISC.txt
// </license>
// ****************************************************************************

using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.Samples.RaiseCanExecuteChanged.ViewModel;

namespace GalaSoft.Samples.RaiseCanExecuteChanged
{
    /// <summary>
    /// This application's main window.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            Messenger.Default.Register<DialogMessage>(this, HandleDialogMessage);

            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Dispose();
        }

        private void HandleDialogMessage(DialogMessage message)
        {
            if (message == null)
            {
                return;
            }

            if (message.Sender.GetType() == typeof(MainViewModel)
                && message.Target == typeof(MainWindow))
            {
                var result = MessageBox.Show(
                    this,
                    message.Content,
                    message.Caption,
                    message.Button,
                    message.Icon,
                    message.DefaultResult,
                    message.Options);

                if (message.Callback != null)
                {
                    message.Callback(result);
                }
            }
        }
    }
}