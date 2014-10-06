using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using SDWebImage;

namespace SDWebImageMTDialogSample
{

	public class ImageLoaderStringElement : StringElement 
	{
		static NSString skey = new NSString ("ImageLoaderStringElement");

		public UIImage Placeholder { get; private set; }
		public NSUrl ImageUrl { get; private set; }

		public UITableViewCellAccessory Accessory { get; set; }
		
		public ImageLoaderStringElement (string caption, NSUrl imageUrl, UIImage placeholder) : base (caption)
		{
			Placeholder = placeholder;
			ImageUrl = imageUrl;
			this.Accessory = UITableViewCellAccessory.None;
		}
		
		public ImageLoaderStringElement (string caption, string value, NSUrl imageUrl, UIImage placeholder) : base (caption, value)
		{
			Placeholder = placeholder;
			ImageUrl = imageUrl;
			this.Accessory = UITableViewCellAccessory.None;
		}
		
		public ImageLoaderStringElement (string caption,  NSAction tapped, NSUrl imageUrl, UIImage placeholder) : base (caption, tapped)
		{
			Placeholder = placeholder;
			ImageUrl = imageUrl;
			this.Accessory = UITableViewCellAccessory.None;
		}
		
		protected override NSString CellKey {
			get {
				return skey;
			}
		}
		public override UITableViewCell GetCell (UITableView tv)
		{
			var cell = tv.DequeueReusableCell (CellKey);
			if (cell == null){
				cell = new UITableViewCell (Value == null ? UITableViewCellStyle.Default : UITableViewCellStyle.Subtitle, CellKey);
				cell.SelectionStyle = UITableViewCellSelectionStyle.Blue;
			}
			
			cell.Accessory = Accessory;
			cell.TextLabel.Text = Caption;
			cell.TextLabel.TextAlignment = Alignment;
			
			cell.ImageView.SetImage (ImageUrl, Placeholder);
			
			// The check is needed because the cell might have been recycled.
			if (cell.DetailTextLabel != null)
				cell.DetailTextLabel.Text = Value == null ? "" : Value;
			
			return cell;
		}
		
	}
}

