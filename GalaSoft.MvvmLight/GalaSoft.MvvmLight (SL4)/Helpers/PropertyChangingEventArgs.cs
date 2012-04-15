// ****************************************************************************
// <copyright file="PropertyChangingEventArgs.cs" company="GalaSoft Laurent Bugnion">
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
    /// Provides data for the System.ComponentModel.INotifyPropertyChanging.PropertyChanging 
    /// event.
    /// </summary>
    ////[ClassInfo(typeof(INotifyPropertyChanging))]
    public class PropertyChangingEventArgs
    {
        /// <summary>
        /// Gets the name of the property that is changing.
        /// </summary>
        public string PropertyName
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the System.ComponentModel.PropertyChangingEventArgs class.
        /// </summary>
        /// <param name="propertyName">The name of the property that is changing.</param>
        public PropertyChangingEventArgs(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}