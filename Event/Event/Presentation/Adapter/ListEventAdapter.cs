using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Event.Commons.Utils;
using Event.Event.Data;
using Event.Event.Presentation.Activity;
using Newtonsoft.Json;
using static Android.Content.ClipData;

namespace Event.Event.Presentation.Adapter
{
    public class ListEventAdapter : BaseAdapter
    {
        Context context;
        List<EventData> eventData;  

        public ListEventAdapter(Context context, List<EventData> eventData)
        {
            this.context = context;
            this.eventData = eventData;
        }

        public override int Count => eventData.Count;

        public override Java.Lang.Object GetItem(int position)
        {
            return 0;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public void RefillItems(List<EventData> items)
        {
            this.eventData = items;     
            NotifyDataSetChanged();
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
                convertView = inflater.Inflate(Resource.Layout.item_card_event, parent, false);
            }
            ImageView eventImage = (ImageView)convertView.FindViewById(Resource.Id.eventImage);
            TextView dayText = (TextView)convertView.FindViewById(Resource.Id.dayText);
            TextView monthText = (TextView)convertView.FindViewById(Resource.Id.monthText);
            TextView titleEventText = (TextView)convertView.FindViewById(Resource.Id.titleEventText);
            TextView addressEventText = (TextView)convertView.FindViewById(Resource.Id.addressEventText);
            TextView priceEventText = (TextView)convertView.FindViewById(Resource.Id.priceEventText);

            GeneralUtils.LoadImageFromWebOperations(eventImage, eventData[position].ImageUrl);
            dayText.Text = eventData[position].Date.Substring(0, 2);
            monthText.Text = eventData[position].Date.Substring(3, 3);
            titleEventText.Text = eventData[position].Title;
            addressEventText.Text = eventData[position].Address;
            var price = String.Format("{0:N0}", eventData[position].Price);
            priceEventText.Text = "$" + price + ".00 MXN";

            return convertView;
        }
    }
}

