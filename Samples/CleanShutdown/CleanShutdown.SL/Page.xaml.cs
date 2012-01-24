// ****************************************************************************
// <copyright file="Page.xaml.cs" company="GalaSoft Laurent Bugnion">
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

using System.Windows.Controls;
using CleanShutdown.Helpers;

namespace CleanShutdown
{
    public partial class Page : UserControl
    {
        private ShutdownAnimationService _animationService;

        public Page()
        {
            _animationService = new ShutdownAnimationService(this);

            InitializeComponent();
        }
    }
}