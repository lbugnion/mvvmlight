using System;
using System.Collections.Generic;
using System.Threading;
using Android.App;
using Android.Graphics;
using Android.Widget;
using Java.Net;

namespace Flowers.Helpers
{
    public class ImageDownloader
    {
        private static readonly Dictionary<string, Bitmap> UrlToImageMap;

        static ImageDownloader()
        {
            UrlToImageMap = new Dictionary<string, Bitmap>();
        }

        public static void AssignImageAsync(ImageView image, string url, Activity context)
        {
            var info = new ImageDownloadInfo
            {
                ImageView = image,
                ImageUrl = url,
                Context = context,
            };

            ThreadPool.QueueUserWorkItem(DownloadImage, info);
        }

        private static void DownloadImage(object state)
        {
            try
            {
                var info = (ImageDownloadInfo)state;
                Bitmap bitmap;
                lock (UrlToImageMap)
                {
                    if (UrlToImageMap.ContainsKey(info.ImageUrl))
                    {
                        bitmap = UrlToImageMap[info.ImageUrl];
                    }
                    else
                    {
                        var imageUrl = new URL(info.ImageUrl);
                        bitmap = BitmapFactory.DecodeStream(imageUrl.OpenStream());
                        UrlToImageMap.Add(info.ImageUrl, bitmap);
                    }
                }

                info.Context.RunOnUiThread(() => info.ImageView.SetImageBitmap(bitmap));
            }
            catch (Exception)
            {
                // Log error, etc
            }
        }

        private class ImageDownloadInfo
        {
            public Activity Context
            {
                get;
                set;
            }

            public string ImageUrl
            {
                get;
                set;
            }

            public ImageView ImageView
            {
                get;
                set;
            }
        }
    }
}