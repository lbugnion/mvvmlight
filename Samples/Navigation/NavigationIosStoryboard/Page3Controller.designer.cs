// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace NavigationIosStoryboard
{
	[Register ("Page3Controller")]
	partial class Page3Controller
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel DisplayLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton GoBackButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (DisplayLabel != null) {
				DisplayLabel.Dispose ();
				DisplayLabel = null;
			}
			if (GoBackButton != null) {
				GoBackButton.Dispose ();
				GoBackButton = null;
			}
		}
	}
}
