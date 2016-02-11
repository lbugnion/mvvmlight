// ****************************************************************************
// <copyright file="IWeakEventListener.cs" company="GalaSoft Laurent Bugnion">
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

// ReSharper disable CheckNamespace

namespace System.Windows
    // ReSharper restore CheckNamespace
{
    /// <summary>
    /// Provides event listening support for classes that expect to receive events 
    /// through the WeakEvent pattern and a WeakEventManager.
    /// </summary>
    ////[ClassInfo(typeof(Binding))]
    public interface IWeakEventListener
    {
        /// <summary>
        /// Gets the WeakReference holding the instance that raised the event.
        /// </summary>
        WeakReference InstanceReference
        {
            get;
        }

        /// <summary>
        /// Receives events from the centralized event manager. 
        /// </summary>
        /// <param name="managerType">The type of the WeakEventManager calling this method.</param>
        /// <param name="sender">Object that originated the event.</param>
        /// <param name="e">Event data.</param>
        /// <returns>true if the listener handled the event. It is considered an error by the 
        /// WeakEventManager handling in WPF to register a listener for an event that the 
        /// listener does not handle. Regardless, the method should return false if it receives 
        /// an event that it does not recognize or handle.
        /// </returns>
        bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e);
    }
}