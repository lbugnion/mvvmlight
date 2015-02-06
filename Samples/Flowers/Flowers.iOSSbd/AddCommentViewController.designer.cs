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
	[Register ("AddCommentViewController")]
	partial class AddCommentViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView CommentText { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CommentText != null) {
				CommentText.Dispose ();
				CommentText = null;
			}
		}
	}
}
