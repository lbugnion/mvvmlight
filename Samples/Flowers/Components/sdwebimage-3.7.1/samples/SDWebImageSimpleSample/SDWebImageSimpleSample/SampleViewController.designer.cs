// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace SDWebImageSimpleSample
{
	[Register ("SampleViewController")]
	partial class SampleViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView imageView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIProgressView progressBar { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblPercent { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnDownload { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imageView != null) {
				imageView.Dispose ();
				imageView = null;
			}

			if (progressBar != null) {
				progressBar.Dispose ();
				progressBar = null;
			}

			if (lblPercent != null) {
				lblPercent.Dispose ();
				lblPercent = null;
			}

			if (btnDownload != null) {
				btnDownload.Dispose ();
				btnDownload = null;
			}
		}
	}
}
