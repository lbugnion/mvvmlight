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

namespace ObservableTableAndCollectionViewSource
{
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton CollectionViewCircleButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton CollectionViewGridButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton ControllerInCodeButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton TableSourceWithCreateCellButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton TableSourceWithReuseIdButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CollectionViewCircleButton != null) {
				CollectionViewCircleButton.Dispose ();
				CollectionViewCircleButton = null;
			}
			if (CollectionViewGridButton != null) {
				CollectionViewGridButton.Dispose ();
				CollectionViewGridButton = null;
			}
			if (ControllerInCodeButton != null) {
				ControllerInCodeButton.Dispose ();
				ControllerInCodeButton = null;
			}
			if (TableSourceWithCreateCellButton != null) {
				TableSourceWithCreateCellButton.Dispose ();
				TableSourceWithCreateCellButton = null;
			}
			if (TableSourceWithReuseIdButton != null) {
				TableSourceWithReuseIdButton.Dispose ();
				TableSourceWithReuseIdButton = null;
			}
		}
	}
}
