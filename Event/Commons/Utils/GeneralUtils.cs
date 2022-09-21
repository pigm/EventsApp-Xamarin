using System;
using System.Net;
using System.Net.Security;
using Android.Graphics;
using Android.Widget;
using Event.Event.Data;

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

        public static long SetMaxDate(int days)
        {
            DateTime dateNow = DateTime.Now;
            DateTime start = new DateTime(1970, 1, 1);
            TimeSpan ts = (dateNow - start);
            int noOfDays = ts.Days + days;
            return (long)(TimeSpan.FromDays(noOfDays).TotalMilliseconds);
        }

        public static long SetMinDate()
        {
            var dt = DateTime.Now;
            var dateMin = new DateTime(1970, 1, 1);
            if (dt.CompareTo(dateMin) < 0)
                throw new ArgumentException("la fecha debe ser >= a 1/1970");
            var longVal = dt.AddDays(0) - dateMin;
            return (long)longVal.TotalMilliseconds;
        }

        public static string DateFormat(int year, int month, int dayOfMonth)
        {
            string monthSelected = "Ene";
            var daySelected = String.Format("{0:dd}", dayOfMonth.ToString()).Length == 1 ? "0" + String.Format("{0:dd}", dayOfMonth.ToString()) : String.Format("{0:dd}", dayOfMonth.ToString());
            if (month == 0)
            {
                monthSelected = "Ene";
            }
            else if (month == 1)
            {
                monthSelected = "Feb";
            }
            else if (month == 2)
            {
                monthSelected = "Mar";
            }
            else if (month == 3)
            {
                monthSelected = "Abr";
            }
            else if (month == 4)
            {
                monthSelected = "May";
            }
            else if (month == 5)
            {
                monthSelected = "Jun";
            }
            else if (month == 6)
            {
                monthSelected = "Jul";
            }
            else if (month == 7)
            {
                monthSelected = "Ago";
            }
            else if (month == 8)
            {
                monthSelected = "Sep";
            }
            else if (month == 9)
            {
                monthSelected = "Oct";
            }
            else if (month == 10)
            {
                monthSelected = "Nov";
            }
            else if (month == 11)
            {
                monthSelected = "Dic";
            }

            return daySelected + "/" + monthSelected + "/" + year;
        }
    }
}

