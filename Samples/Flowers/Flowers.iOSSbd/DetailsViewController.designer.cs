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

namespace Flowers.iOSSbd
{
	[Register ("DetailsViewController")]
	partial class DetailsViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView FlowerImage { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel NameText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIScrollView Scroll { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton SeeCommentsButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (FlowerImage != null) {
				FlowerImage.Dispose ();
				FlowerImage = null;
			}
			if (NameText != null) {
				NameText.Dispose ();
				NameText = null;
			}
			if (Scroll != null) {
				Scroll.Dispose ();
				Scroll = null;
			}
			if (SeeCommentsButton != null) {
				SeeCommentsButton.Dispose ();
				SeeCommentsButton = null;
			}
		}
	}
}
