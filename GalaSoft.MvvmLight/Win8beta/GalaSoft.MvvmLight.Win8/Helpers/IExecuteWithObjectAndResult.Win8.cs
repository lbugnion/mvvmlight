using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaSoft.MvvmLight.Helpers
{
    public interface IExecuteWithObjectAndResult<TResult>
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
        TResult ExecuteWithObject(object parameter);

        /// <summary>
        /// Deletes all references, which notifies the cleanup method
        /// that this entry must be deleted.
        /// </summary>
        void MarkForDeletion();
    }
}
