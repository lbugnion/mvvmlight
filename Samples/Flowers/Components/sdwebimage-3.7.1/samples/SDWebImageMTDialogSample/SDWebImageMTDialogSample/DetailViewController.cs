
using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using SDWebImage;

namespace SDWebImageMTDialogSample
{
	public partial class DetailViewController : UIViewController
	{
		UIImageView ImageView;
		UIActivityIndicatorView activityIndicator;
		public NSUrl ImageUrl { get; private set; }


		public DetailViewController (NSUrl imageUrl) : base ()
		{
			ImageUrl = imageUrl;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			View.BackgroundColor = UIColor.White;
			ImageView = new UIImageView (View.Bounds) {
				ContentMode = UIViewContentMode.ScaleAspectFit
			};

			View.AddSubview (ImageView);

			if (ImageUrl != null) {
				ImageView.SetImage (ImageUrl, null, SDWebImageOptions.ProgressiveDownload, ProgressHandler, CompletedHandler);
			}
		}

		void ProgressHandler (int receivedSize, int expectedSize)
		{
			if (activityIndicator == null) {
				InvokeOnMainThread (()=> {
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
				InvokeOnMainThread (()=> {
					activityIndicator.RemoveFromSuperview ();
					activityIndicator = null;
				});
			}
		}
	}
}
