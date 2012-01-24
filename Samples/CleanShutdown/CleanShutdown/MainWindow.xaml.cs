// ****************************************************************************
// <copyright file="MainWindow.xaml.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>15.10.2009</date>
// <project>CleanShutdown</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System.Windows;
using CleanShutdown.Helpers;

namespace CleanShutdown
{
    /// <summary>
    /// This application's main window.
    /// </summary>
    public partial class MainWindow : Window
    {
        private ShutdownAnimationService _animationService;

        public MainWindow()
        {
            _animationService = new ShutdownAnimationService(this);
            InitializeComponent();

            MouseDown += (s, e) => DragMove();
        }
    }
}