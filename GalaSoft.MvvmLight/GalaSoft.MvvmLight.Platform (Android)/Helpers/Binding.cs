// ****************************************************************************
// <copyright file="Binding.cs" company="GalaSoft Laurent Bugnion">
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

using System;

namespace GalaSoft.MvvmLight.Helpers
{
    /// <summary>
    /// Base class for bindings in Xamarin.iOS and Xamarin.Android.
    /// </summary>
    ////[ClassInfo(typeof(Binding),
    ////    VersionString = "5.4.4",
    ////    DateString = "201801022330",
    ////    Description = "Base class for bindings in Xamarin.iOS and Xamarin.Android",
    ////    UrlContacts = "http://www.galasoft.ch/contact_en.html",
    ////    Email = "laurent@galasoft.ch")]
    public abstract class Binding
    {
        /// <summary>
        /// The source at the "top" of the property chain.
        /// </summary>
        protected WeakReference TopSource;

        /// <summary>
        /// The target at the "top" of the property chain.
        /// </summary>
        protected WeakReference TopTarget;

        /// <summary>
        /// The mode of the binding. OneTime means that the target property will be set once (when the binding is
        /// created) but that subsequent changes will be ignored. OneWay means that the target property will be set, and
        /// if the PropertyChanged event is raised by the source, the target property will be updated. TwoWay means that the source
        /// property will also be updated if the target raises the PropertyChanged event. Default means OneWay if only the source
        /// implements INPC, and TwoWay if both the source and the target implement INPC.
        /// </summary>
        public BindingMode Mode
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the source object for the binding.
        /// </summary>
        public object Source
        {
            get
            {
                return TopSource == null || !TopSource.IsAlive
                    ? null
                    : TopSource.Target;
            }
        }

        /// <summary>
        /// Gets the target object for the binding.
        /// </summary>
        public object Target
        {
            get
            {
                return TopTarget == null || !TopTarget.IsAlive
                    ? null
                    : TopTarget.Target;
            }
        }

        /// <summary>
        /// Instructs the Binding instance to stop listening to value changes and to
        /// remove all listeneners.
        /// </summary>
        public abstract void Detach();

        /// <summary>
        /// Forces the Binding's value to be reevaluated. The target value will
        /// be set to the source value.
        /// </summary>
        public abstract void ForceUpdateValueFromSourceToTarget();

        /// <summary>
        /// Forces the Binding's value to be reevaluated. The source value will
        /// be set to the target value.
        /// </summary>
        public abstract void ForceUpdateValueFromTargetToSource();

        /// <summary>
        /// Occurs when the value of the databound property changes.
        /// </summary>
        public abstract event EventHandler ValueChanged;
    }
}