Adds methods to `UIImageView` supporting asynchronous web image loading:

```csharp
using SDWebImage;
...

const string CellIdentifier = "Cell";

public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
{
	UITableViewCell cell = tableView.DequeueReusableCell (CellIdentifier) ??
		new UITableViewCell (UITableViewCellStyle.Default, CellIdentifier);
	
	// Use the SetImage extension method to load the web image:
	cell.ImageView.SetImage (
		url: new NSUrl ("http://db.tt/ayAqtbFy"), 
		placeholder: UIImage.FromBundle ("placeholder.png")
	);

	return cell;
}
```

It provides:

* `UIImageView` and `UIButton` extension methods adding web image loading and cache management.
* An asynchronous image downloader
* An asynchronous memory + disk image caching with automatic cache expiration handling
* Animated GIF support
* WebP format support
* A background image decompression
* A guarantee that the same URL won't be downloaded several times
* A guarantee that bogus URLs won't be retried again and again
* A guarantee that main thread will never be blocked
* Performances!
* Use GCD and ARC
* Arm64 support

### Callbacks

With callbacks, you can be notified about the image download progress
and whenever the image retrieval has completed:

```csharp
cell.ImageView.SetImage (
	url: new NSUrl ("http://db.tt/ayAqtbFy"), 
	placeholder: UIImage.FromBundle ("placeholder.png"),
	completedHandler: (image, error, cacheType) => {
		// Handle download completed...
	}
);
```

Callbacks are not called if the request is canceled.

## Using SDWebImageManager Independently

The SDWebImageManager is the class behind the UIImageView extension
methods. It owns the asynchronous downloader and the image cache.  You
can reuse this class directly for cached web image downloading in other
contexts.

```csharp
SDWebImageManager.SharedManager.Download (
	url: new NSUrl ("http://db.tt/ayAqtbFy"), 
	options: SDWebImageOptions.CacheMemoryOnly,
	progressHandler: (recievedSize, expectedSize) => {
		// Track progress...
	},
	completedHandler: (image, error, cacheType, finished) => {
		if (image != null) {
			// do something with the image
		}
	}
);
```

## Using SDWebImageDownloader Independently

It's also possible to use the asynchronous image downloader independently:

```csharp
SDWebImageDownloader.SharedDownloader.DownloadImage (
	url: new NSUrl ("http://db.tt/ayAqtbFy"),
	options: SDWebImageDownloaderOptions.LowPriority,
	progressHandler: (receivedSize, expectedSize) => {
		// Track progress...
	},
	completedHandler: (image, error, finished) => {
		if (image != null && finished) {
			// do something with the image
		}
	}
);
```

## Using SDImageCache Independently

You may also use the image cache independently. SDImageCache maintains a
memory cache and an optional disk cache. Disk writes are performed
asynchronously as well.

The SDImageCache class provides a singleton instance for convenience but
you can create your own instance if you want to create Independent
caches.

```csharp
var myCache = new SDImageCache ("MyUniqueCacheKey");

myCache.QueryDiskCache ("UniqueImageKey", image => {
	// If image is not null, image was found
	if (image != null) {
		// Do something with the image
	}
 });
```

By default SDImageCache will lookup the disk cache if an image can't be
found in the memory cache. You can prevent this from happening by
calling the alternative method `ImageFromMemoryCache`.

To store an image into the cache, you use the `StoreImage` method:

```csharp
SDImageCache.SharedImageCache.StoreImage (image: myImage, key: "myKey");
```

By default, the image will be stored in memory cache as well as on disk
cache. If you want only the memory cache use:


```csharp
SDImageCache.SharedImageCache.StoreImage (image: myImage, key: "myKey", toDisk: false);
```

## Using cache key filter

Sometimes, you may not want to use image URLs as cache keys because part
of the URL is unstable.  SDWebImageManager provides a way to set a cache
key filter that maps NSUrls to cache key strings.

The following example sets a filter in the application delegate that
removes query parameters from the URL before querying the cache:
key:

```csharp
using SDWebImage;
...

public override bool FinishedLaunching (UIApplication app, NSDictionary options)
{
	SDWebImageManager.SharedManager.SetCacheKeyFilter (url => {
		var stableUrl = new NSUrl (scheme: url.Scheme, host: url.Host, path: url.Path);  
		return stableUrl.AbsoluteString;
	});
	...
}
```

## Handle image refresh

`SDWebImage` does very aggressive caching by default; it ignores any
caching control headers returned by the HTTP server, and caches images
with no time restrictions. This implies that your images change only if
their URLs change.

If you don't control the image server, you may not be able
to change the URL when an image changes--this is the case with
Facebook profile URLs, for example. In this case, you may use the
`SDWebImageOptions.RefreshCached` flag, which causes the cache to
respect HTTP caching control headers:

```csharp
var imageView = new UIImageView ();
imageView.SetImage (
	url: new NSUrl ("http://db.tt/ayAqtbFy"), 
	placeholder: UIImage.FromBundle ("yourPlaceholder.png"),
	options: SDWebImageOptions.RefreshCached
);
```
