// ****************************************************************************
// <copyright file="UpdateTriggerMode.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2016
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>02.10.2014</date>
// <project>GalaSoft.MvvmLight</project>
// <web>http://www.mvvmlight.net</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

namespace GalaSoft.MvvmLight.Helpers
{
    /// <summary>
    /// Defines how a <see cref="Binding"/> is updated by a source control.
    /// </summary>
    ////[ClassInfo(typeof(Binding))]
    public enum UpdateTriggerMode
    {
        /// <summary>
        /// Defines that the binding should be updated when the control
        /// loses the focus.
        /// </summary>
        LostFocus,

        /// <summary>
        /// Defines that the binding should be updated when the control's 
        /// bound property changes.
        /// </summary>
        PropertyChanged
    }
}