// ****************************************************************************
// <copyright file="WeakActionGeneric.cs" company="GalaSoft Laurent Bugnion">
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
    /// Stores a Func without causing a hard reference
    /// to be created to the Func's owner. The owner can be garbage collected at any time.
    /// </summary>
    /// <typeparam name="T">The type of the Func's parameter.</typeparam>
    ////[ClassInfo(typeof(Messenger))]
    public class WeakFunc<T, TResult> : WeakFunc<TResult>, IExecuteWithObjectAndResult<TResult>
    {
        private readonly Func<T, TResult> _func;

        public new bool IsStatic
        {
            get
            {
                return _func != null && _func.Target == null;
            }
        }

        /// <summary>
        /// Initializes a new instance of the WeakFunc class.
        /// </summary>
        /// <param name="target">The func's owner.</param>
        /// <param name="func">The func that will be associated to this instance.</param>
        public WeakFunc(object target, Func<T, TResult> func)
            : base(target, null)
        {
            _func = func;
        }

        public WeakFunc(Func<T, TResult> func)
            : this(func.Target, func)
        {
        }

        /// <summary>
        /// Gets the Func associated to this instance.
        /// </summary>
        public new Func<T, TResult> Func
        {
            get
            {
                return _func;
            }
        }

        /// <summary>
        /// Executes the func. This only happens if the func's owner
        /// is still alive. The func's parameter is set to default(T).
        /// </summary>
        public new TResult Execute()
        {
            if (_func != null
                && (IsAlive || IsStatic))
            {
                return _func(default(T));
            }

            return default(TResult);
        }

        /// <summary>
        /// Executes the func. This only happens if the func's owner
        /// is still alive.
        /// </summary>
        /// <param name="parameter">A parameter to be passed to the func.</param>
        public TResult Execute(T parameter)
        {
            if (_func != null
                && (IsAlive || IsStatic))
            {
                return _func(parameter);
            }

            return default(TResult);
        }

        /// <summary>
        /// Executes the func with a parameter of type object. This parameter
        /// will be casted to T. This method implements <see cref="IExecuteWithObject.ExecuteWithObject" />
        /// and can be useful if you store multiple WeakFunc{T} instances but don't know in advance
        /// what type T represents.
        /// </summary>
        /// <param name="parameter">The parameter that will be passed to the action after
        /// being casted to T.</param>
        public TResult ExecuteWithObject(object parameter)
        {
            var parameterCasted = (T) parameter;
            return Execute(parameterCasted);
        }
    }
}