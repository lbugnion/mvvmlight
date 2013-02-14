// ****************************************************************************
// <copyright file="IExecuteWithObject.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2013
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>18.9.2009</date>
// <project>GalaSoft.MvvmLight</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

namespace GalaSoft.MvvmLight.Helpers
{
    /// <summary>
    /// This interface is meant for the <see cref="WeakAction{T}" /> class and can be 
    /// useful if you store multiple WeakAction{T} instances but don't know in advance
    /// what type T represents.
    /// </summary>
    ////[ClassInfo(typeof(WeakAction))]
    public interface IExecuteWithObject
    {
        /// <summary>
        /// The target of the WeakAction.
        /// </summary>
        object Target
        {
            get;
        }

        /// <summary>
        /// Executes an action.
        /// </summary>
        /// <param name="parameter">A parameter passed as an object,
        /// to be casted to the appropriate type.</param>
        void ExecuteWithObject(object parameter);

        /// <summary>
        /// Deletes all references, which notifies the cleanup method
        /// that this entry must be deleted.
        /// </summary>
        void MarkForDeletion();
    }
}