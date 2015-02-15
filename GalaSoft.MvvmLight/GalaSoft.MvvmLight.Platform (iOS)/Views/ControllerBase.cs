using System;
using Foundation;
using UIKit;

namespace GalaSoft.MvvmLight.Views
{
    /// <summary>
    /// A base class to be used with the <see cref="NavigationService" /> when
    /// using Storyboards.
    /// </summary>
    ////[ClassInfo(typeof(INavigationService))]
    public class ControllerBase : UIViewController
    {
        /// <summary>
        /// The parameter passed to this controller by the
        /// <see cref="NavigationService.NavigateTo(string, object)"/>  method.
        /// </summary>
        public object NavigationParameter
        {
            get;
            set;
        }

        /// <summary>
        /// A constructor used when creating managed representations of unmanaged objects;
        /// Called by the runtime.
        /// </summary>
        /// <param name="handle">Pointer (handle) to the unmanaged object.</param>
        /// <remarks>Check the remarks on <see cref="UIViewController(IntPtr)"/></remarks>
        protected internal ControllerBase(IntPtr handle)
            : base(handle)
        {
        }

        /// <summary>
        /// A constructor that initializes the object from the data stored in the unarchiver
        /// object.
        /// </summary>
        /// <param name="coder">The unarchiver object.</param>
        /// <remarks>Check the remarks on <see cref="UIViewController(NSCoder)"/></remarks>
        public ControllerBase(NSCoder coder)
            : base(coder)
        {
        }

        /// <summary>
        /// Constructor to call on derived classes to skip initialization and merely
        /// allocate the object.
        /// </summary>
        /// <param name="t">Unused sentinel value, pass NSObjectFlag.Empty.</param>
        /// <remarks>Check the remarks on <see cref="UIViewController(NSObjectFlag)"/></remarks>
        public ControllerBase(NSObjectFlag t)
            : base(t)
        {
        }

        /// <summary>
        /// Initializes an instance of this class.
        /// </summary>
        /// <param name="nibName">The NIB name, or null.
        /// This parameter can be null.</param>
        /// <param name="bundle">The bundle where the search for the NIB takes place,
        /// if you pass null, this searches for the NIB on the main bundle.
        /// This parameter can be null.</param>
        /// <remarks>Check the remarks on <see cref="UIViewController(string, NSBundle)"/></remarks>
        public ControllerBase(string nibName, NSBundle bundle)
            : base(nibName, bundle)
        {
        }

        /// <summary>
        /// Initializes an instance of this class.
        /// </summary>
        public ControllerBase()
        {
        }
    }
}