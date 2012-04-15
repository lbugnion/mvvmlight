// ****************************************************************************
// <copyright file="WeakAction.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2011
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

using System;

namespace GalaSoft.MvvmLight.Helpers
{
    /// <summary>
    /// Stores a <see cref="Func" /> without causing a hard reference
    /// to be created to the Func's owner. The owner can be garbage collected at any time.
    /// </summary>
    ////[ClassInfo(typeof(Messenger))]
    public class WeakFunc<TResult>
    {
        private readonly Func<TResult> _func;

        private WeakReference _reference;

        public bool IsStatic
        {
            get
            {
                return _func != null && _func.Target == null;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeakFunc" /> class.
        /// </summary>
        /// <param name="target">The func's owner.</param>
        /// <param name="func">The func that will be associated to this instance.</param>
        public WeakFunc(object target, Func<TResult> func)
        {
            if (target != null)
            {
                _reference = new WeakReference(target);
            }

            _func = func;
        }

        public WeakFunc(Func<TResult> func)
            : this(func.Target, func)
        {
        }

        /// <summary>
        /// Gets the Func associated to this instance.
        /// </summary>
        public Func<TResult> Func
        {
            get
            {
                return _func;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the Func's owner is still alive, or if it was collected
        /// by the Garbage Collector already.
        /// </summary>
        public bool IsAlive
        {
            get
            {
                if (_reference == null)
                {
                    return false;
                }

                return _reference.IsAlive;
            }
        }

        /// <summary>
        /// Gets the Func's owner. This object is stored as a <see cref="WeakReference" />.
        /// </summary>
        public object Target
        {
            get
            {
                if (_reference == null)
                {
                    return null;
                }

                return _reference.Target;
            }
        }

        /// <summary>
        /// Executes the Func. This only happens if the Func's owner
        /// is still alive.
        /// </summary>
        public TResult Execute()
        {
            if (_func != null
                && (IsAlive || IsStatic))
            {
                return _func();
            }

            return default(TResult);
        }

        /// <summary>
        /// Sets the reference that this instance stores to null.
        /// </summary>
        public void MarkForDeletion()
        {
            _reference = null;
        }
    }
}