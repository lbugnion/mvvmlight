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

namespace $safeprojectname$
{
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel ClockText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField DialogNavText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton IncrementButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton NavigateButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton SendMessageButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton ShowDialogButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel WelcomeText { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (ClockText != null) {
				ClockText.Dispose ();
				ClockText = null;
			}
			if (DialogNavText != null) {
				DialogNavText.Dispose ();
				DialogNavText = null;
			}
			if (IncrementButton != null) {
				IncrementButton.Dispose ();
				IncrementButton = null;
			}
			if (NavigateButton != null) {
				NavigateButton.Dispose ();
				NavigateButton = null;
			}
			if (SendMessageButton != null) {
				SendMessageButton.Dispose ();
				SendMessageButton = null;
			}
			if (ShowDialogButton != null) {
				ShowDialogButton.Dispose ();
				ShowDialogButton = null;
			}
			if (WelcomeText != null) {
				WelcomeText.Dispose ();
				WelcomeText = null;
			}
		}
	}
}
