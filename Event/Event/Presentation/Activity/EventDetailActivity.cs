
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Event.Commons;
using Event.Commons.Utils;
using Event.Event.Data;
using Newtonsoft.Json;
using static Android.Icu.Text.Transliterator;

namespace Event.Event.Presentation.Activity
{
    [Activity(Label = "EventDetailActivity", Theme = "@style/ThemeNoActionBar", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
           Android.Content.PM.ConfigChanges.Orientation,
           ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class EventDetailActivity : AppCompatActivity, BaseActivity
    {
        private EventData eventData;
        Button paymentDetailButton, deleteEventButton;
        ImageView eventDetailImage, backImage;
        TextView titleEventDetailText, dayDetailText, monthDetailText, startTimeDetailText,
            endTimeDetailText, addressEventDetailText, priceEventDetailText, titleToolbarText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_detail_event);
            InitComponentView();
            InitView();
        }

        public void InitComponentView()
        {
            backImage = (ImageView)FindViewById(Resource.Id.backImage);
            titleToolbarText = (TextView)FindViewById(Resource.Id.titleToolbarText);
            eventDetailImage = (ImageView)FindViewById(Resource.Id.eventDetailImage);
            titleEventDetailText = (TextView)FindViewById(Resource.Id.titleEventDetailText);
            dayDetailText = (TextView)FindViewById(Resource.Id.dayDetailText);
            monthDetailText = (TextView)FindViewById(Resource.Id.monthDetailText);
            startTimeDetailText = (TextView)FindViewById(Resource.Id.startTimeDetailText);
            endTimeDetailText = (TextView)FindViewById(Resource.Id.endTimeDetailText);
            addressEventDetailText = (TextView)FindViewById(Resource.Id.addressEventDetailText);
            priceEventDetailText = (TextView)FindViewById(Resource.Id.priceEventDetailText);
            paymentDetailButton = (Button)FindViewById(Resource.Id.paymentDetailButton);
            deleteEventButton = (Button)FindViewById(Resource.Id.deleteEventButton);
        }

        public void InitView()
        {
            eventData = JsonConvert.DeserializeObject<EventData>(Intent.GetStringExtra("EVENT"));
            backImage.Click += delegate { Finish(); };
            titleToolbarText.Text = GetString(Resource.String.events_detail);
            GeneralUtils.LoadImageFromWebOperations(eventDetailImage, eventData.ImageUrl);
            titleEventDetailText.Text = eventData.Title;
            dayDetailText.Text = eventData.Date.Substring(0, 2);
            monthDetailText.Text = eventData.Date.Substring(3, 3);
            startTimeDetailText.Text = "De " + eventData.StartTime;
            endTimeDetailText.Text = eventData.EndTime;
            addressEventDetailText.Text = eventData.Address;

            var price = String.Format("{0:N0}", eventData.Price);
            priceEventDetailText.Text = "$" + price + ".00 MXN";
            paymentDetailButton.Click += delegate
            {
                Android.Net.Uri uri = Android.Net.Uri.Parse(eventData.UrlPago);
                Intent i = new Intent(Intent.ActionView);
                i.SetData(uri);
                StartActivity(i);
            };
            deleteEventButton.Click += delegate
            {
                DeleteEvent();
                OnBackPressed();           
            };
        }

        private void DeleteEvent()
        {
            var eventDelete = DataManager.RealmInstance.All<EventData>().Where(w => w.Title == eventData.Title).ToList<EventData>();
            if (eventDelete.Any())
            {
                foreach (EventData itemDelete in eventDelete)
                {
                    using (var trans = DataManager.RealmInstance.BeginWrite())
                    {
                        DataManager.RealmInstance.Remove(itemDelete);
                        trans.Commit();
                    }
                }

            }
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }
    }
}