// ****************************************************************************
// <copyright file="MainWindow.xaml.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>12.9.2009</date>
// <project>GalaSoft.MvvmLight.CheckVersion</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media.Animation;
using GalaSoft.MvvmLight.CheckVersion.ViewModel;
using GalaSoft.MvvmLight.Messaging;

namespace GalaSoft.MvvmLight.CheckVersion
{
    /// <summary>
    /// This application's main window.
    /// </summary>
    public partial class MainWindow
    {
        private bool _animationExecuted;

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            var requestMessage = new CommandMessage<Func<bool>>(
                this,
                InitiateShutdownAnimation,
                Commands.RequestShutdownNotification);
            Messenger.Default.Send(requestMessage);

            var vm = (MainViewModel) DataContext;
            vm.PropertyChanged += VMPropertyChanged;
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private bool InitiateShutdownAnimation()
        {
            if (_animationExecuted)
            {
                return true;
            }

            var sbd = TryFindResource("ShutdownStoryboard") as Storyboard;
            if (sbd == null)
            {
                return true;
            }

            sbd.Completed += (s, e) =>
            {
                _animationExecuted = true;
                var message = new CommandMessage(this, Commands.RequestShutdown);
                Messenger.Default.Send(message);
            };

            sbd.Begin();

            return false;
        }

        private void VMPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName
                == MainViewModel.IsProcessingPropertyName)
            {
                var sbd = TryFindResource("ProcessingStoryboard") as Storyboard;
                if (sbd != null)
                {
                    var vm = (MainViewModel) DataContext;

                    if (vm.IsProcessing)
                    {
                        sbd.Begin();
                    }
                    else
                    {
                        sbd.Stop();
                    }
                }
            }
        }
    }
}