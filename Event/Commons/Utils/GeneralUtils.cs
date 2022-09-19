using System;
using System.Net;
using System.Net.Security;
using Android.Graphics;
using Android.Widget;

namespace Event.Commons.Utils
{
    public class GeneralUtils
    {
        public static void LoadImageFromWebOperations(ImageView imageView, string url)
        {
            var uri = new UriBuilder(url).Uri;
            var client = new WebClient();
            ServicePointManager.ServerCertificateValidationCallback = new
            RemoteCertificateValidationCallback
            (
                delegate { return true; }
            );
            var imageBytes = client.DownloadData(uri);

            Bitmap imageBitmap;
            if (imageBytes != null && imageBytes.Length > 0)
            {
                imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                imageView.SetImageBitmap(imageBitmap);
            }
        }
    }
}

