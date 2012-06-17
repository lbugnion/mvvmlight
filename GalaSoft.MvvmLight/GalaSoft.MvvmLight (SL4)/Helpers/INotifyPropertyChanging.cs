// ****************************************************************************
// <copyright file="INotifyPropertyChanging.cs" company="GalaSoft Laurent Bugnion">
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
// <LastBaseLevel>BL0000</LastBaseLevel>
// ****************************************************************************

namespace System.ComponentModel
{
    /// <summary>
    /// Defines an event for notifying clients that a property value is changing.
    /// </summary>
    ////[ClassInfo(typeof(INotifyPropertyChanging),
    ////    VersionString = "4.0.0.0/BL0000",
    ////    DateString = "201201081910",
    ////    Description = "A class allowing to store and invoke actions without keeping a hard reference to the action's target.",
    ////    UrlContacts = "http://www.galasoft.ch/contact_en.html",
    ////    Email = "laurent@galasoft.ch")]
    public interface INotifyPropertyChanging
    {
        /// <summary>
        /// Occurs when a property value is changing.
        /// </summary>
        event PropertyChangingEventHandler PropertyChanging;
    }
}
