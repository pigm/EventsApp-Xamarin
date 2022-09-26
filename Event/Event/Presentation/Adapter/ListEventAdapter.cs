using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Event.Commons.Utils;
using Event.Event.Domain.Model;
using Event.Event.Presentation.Activity;
using Newtonsoft.Json;
using static Android.Content.ClipData;

namespace Event.Event.Presentation.Adapter
{
    public class ListEventAdapter : BaseAdapter
    {
        Context context;
        List<EventDomain> eventDomain;  

        public ListEventAdapter(Context context, List<EventDomain> eventDomain)
        {
            this.context = context;
            this.eventDomain = eventDomain;
        }

        public override int Count => eventDomain.Count;

        public override Java.Lang.Object GetItem(int position)
        {
            return 0;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public void RefillItems(List<EventDomain> items)
        {
            this.eventDomain = items;     
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

            eventImage.SetImageBitmap(eventDomain[position].ImageBitmap);
            dayText.Text = eventDomain[position].Date.Substring(0, 2);
            monthText.Text = eventDomain[position].Date.Substring(3, 3);
            titleEventText.Text = eventDomain[position].Title;
            addressEventText.Text = eventDomain[position].Address;
            var price = String.Format("{0:N0}", eventDomain[position].Price);
            priceEventText.Text = "$" + price + ".00 MXN"; 

            return convertView;
        }
    }
}

