// ****************************************************************************
// <copyright file="PropertyChangingEventHandler.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2012
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>08.01.2012</date>
// <project>GalaSoft.MvvmLight</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

namespace System.ComponentModel
{
    /// <summary>
    /// Represents a method that will handle the System.ComponentModel.INotifyPropertyChanging.PropertyChanging event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    ////[ClassInfo(typeof(INotifyPropertyChanging))]
    public delegate void PropertyChangingEventHandler(object sender, PropertyChangingEventArgs e);
}