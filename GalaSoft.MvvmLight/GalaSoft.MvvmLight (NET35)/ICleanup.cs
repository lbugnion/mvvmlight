// ****************************************************************************
// <copyright file="ICleanup.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2013
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>29.11.2009</date>
// <project>GalaSoft.MvvmLight</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

////using GalaSoft.Utilities.Attributes;

namespace GalaSoft.MvvmLight
{
    /// <summary>
    /// Defines a common interface for classes that should be cleaned up,
    /// but without the implications that IDisposable presupposes. An instance
    /// implementing ICleanup can be cleaned up without being
    /// disposed and garbage collected.
    /// </summary>
    //// [ClassInfo(typeof(ViewModelBase))]
    public interface ICleanup
    {
        /// <summary>
        /// Cleans up the instance, for example by saving its state,
        /// removing resources, etc...
        /// </summary>
        void Cleanup();
    }
}