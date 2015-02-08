using System;
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
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="handle"></param>
        public ControllerBase(IntPtr handle)
            : base(handle)
        {
        }
    }
}