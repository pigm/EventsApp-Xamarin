using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using Android.Content;
using Android.Graphics;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Event.Home.Data.Model;
using Java.IO;
using Java.Net;
using Square.Picasso;

namespace Event.Home.Presentation.Adapter
{
    public class HomeAdapter : PagerAdapter
    {
        Context context;
        List<EventData> eventDataList;

        public HomeAdapter(Context context, List<EventData> eventDataList)
        {
            this.context = context;
            this.eventDataList = eventDataList;
        }

        public override int Count => eventDataList.Count;

        public override bool IsViewFromObject(View view, Java.Lang.Object @object)
        {
            return view == @object;
        }

        public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object @object)
        {
            container.RemoveView((View)@object);
        }

        public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
        {
            View view = LayoutInflater.From(context).Inflate(Resource.Layout.item_card, container, false);

            var cardImage = view.FindViewById<ImageView>(Resource.Id.cardImage);
            var eventTitleText = view.FindViewById<TextView>(Resource.Id.eventTitleText);
            var eventDescriptionText = view.FindViewById<TextView>(Resource.Id.eventDescriptionText);
            var favFloatingActionButton = view.FindViewById<FloatingActionButton>(Resource.Id.favFloatingActionButton);

            //cardImage.SetImageResource(eventDataList[position].ImageUrl);
            LoadImageFromWebOperations(cardImage, eventDataList[position].ImageUrl);
            eventTitleText.Text = eventDataList[position].Name;
            eventDescriptionText.Text = eventDataList[position].Description;

            view.Click += delegate
            {
                Toast.MakeText(context, "" + eventDataList[position].Name, ToastLength.Short).Show();
            };

            favFloatingActionButton.Click += delegate
            {
                Toast.MakeText(context, "fav", ToastLength.Short).Show();
            };

            container.AddView(view);
            return view;
        }

        public void LoadImageFromWebOperations(ImageView imageView, string url)
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
