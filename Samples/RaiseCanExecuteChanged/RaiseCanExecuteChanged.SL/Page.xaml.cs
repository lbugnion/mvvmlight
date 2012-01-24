// ****************************************************************************
// <copyright file="Page.xaml.cs" company="GalaSoft Laurent Bugnion">
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
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.Samples.RaiseCanExecuteChanged.ViewModel;

namespace GalaSoft.Samples.RaiseCanExecuteChanged
{
    /// <summary>
    /// Main Page for the application.
    /// </summary>
    public partial class Page : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the Page class.
        /// </summary>
        public Page()
        {
            Messenger.Default.Register<DialogMessage>(this, HandleDialogMessage);
            InitializeComponent();
        }

        private static void HandleDialogMessage(DialogMessage message)
        {
            if (message == null)
            {
                return;
            }

            if (message.Sender.GetType() == typeof(MainViewModel)
                && message.Target == typeof(Page))
            {
                var result = MessageBox.Show(
                    message.Content,
                    message.Caption,
                    message.Button);

                if (message.Callback != null)
                {
                    message.Callback(result);
                }
            }
        }
    }
}