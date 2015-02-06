
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using CGRect = global::System.Drawing.RectangleF;
using CGSize = global::System.Drawing.SizeF;
using CGPoint = global::System.Drawing.PointF;

using SDWebImage;

namespace SDWebImageSample
{
	public partial class DetailViewController : UIViewController
	{
		public NSUrl ImageUrl { get; set; }

		UIActivityIndicatorView activityIndicator;

		public DetailViewController () : base ("DetailViewController", null)
		{

		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();

			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			configureView ();
		}

		void configureView ()
		{
			if (ImageUrl != null) {
				ImageView.SetImage (ImageUrl, null, SDWebImageOptions.ProgressiveDownload, ProgressHandler, CompletedHandler);
			}
		}

		void ProgressHandler (int receivedSize, int expectedSize)
		{
			if (activityIndicator == null) {
				InvokeOnMainThread (() => {
					activityIndicator = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.Gray);
					ImageView.AddSubview (activityIndicator);
					activityIndicator.Center = ImageView.Center;
					activityIndicator.StartAnimating ();
				});
			}
		}

		void CompletedHandler (UIImage image, NSError error, SDImageCacheType cacheType, NSUrl url)
		{
			if (activityIndicator != null) {
				InvokeOnMainThread (() => {
					activityIndicator.RemoveFromSuperview ();
					activityIndicator = null;
				});
			}
		}
	}
}

