

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Event.Commons;
using Event.Commons.Utils;
using Event.Event.Data;
using Newtonsoft.Json;

namespace Event.Event.Presentation.Activity
{
    [Activity(Label = "UpdateEventActivity", Theme = "@style/ThemeNoActionBar", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
           Android.Content.PM.ConfigChanges.Orientation,
           ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class UpdateEventActivity : AppCompatActivity, BaseActivity
    {
        private EventData eventData;
        Button updateButton;
        ImageView backImage;
        TextView titleToolbarText;
        TextInputEditText titleUpdateEditText, addressUpdateEditText, dateUpdateEditText,
            startTimeUpdateEditText, endTimeUpdateEditText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_update_event);
            InitComponentView();
            InitView();
        }

        public void InitComponentView()
        {
            updateButton = (Button)FindViewById(Resource.Id.updateButton);
            backImage = (ImageView)FindViewById(Resource.Id.backImage);
            titleToolbarText = (TextView)FindViewById(Resource.Id.titleToolbarText);
            titleUpdateEditText = (TextInputEditText)FindViewById(Resource.Id.titleUpdateEditText);
            addressUpdateEditText = (TextInputEditText)FindViewById(Resource.Id.addressUpdateEditText);
            dateUpdateEditText = (TextInputEditText)FindViewById(Resource.Id.dateUpdateEditText);
            startTimeUpdateEditText = (TextInputEditText)FindViewById(Resource.Id.startTimeUpdateEditText);
            endTimeUpdateEditText = (TextInputEditText)FindViewById(Resource.Id.endTimeUpdateEditText);
        }

        public void InitView()
        {
            eventData = JsonConvert.DeserializeObject<EventData>(Intent.GetStringExtra("EVENT"));
            updateButton.Click += delegate { UpdateEvent(); };
            backImage.Click += delegate { Finish(); };
            titleToolbarText.Text = GetString(Resource.String.update_event);
            titleUpdateEditText.Text = eventData.Title;
            titleUpdateEditText.Enabled = false;
            titleUpdateEditText.Focusable = false;
            addressUpdateEditText.Text = eventData.Address;
            dateUpdateEditText.Text = eventData.Date;
            startTimeUpdateEditText.Text = eventData.StartTime;
            endTimeUpdateEditText.Text = eventData.EndTime;
        }

        private void UpdateEvent()
        {
            UpdatePersistentData();
            
            Finish();
        }

        private void UpdatePersistentData()
        {
            
            DataManager.RealmInstance.Write(() =>
            {
                var eventUpdate = DataManager.RealmInstance.All<EventData>()
                                                           .Where(item =>
                                                                item.Title == this.eventData.Title)
                                                           .FirstOrDefault();

                eventUpdate.Address = addressUpdateEditText.Text;
                eventUpdate.Date = dateUpdateEditText.Text;
                eventUpdate.StartTime = startTimeUpdateEditText.Text;
                eventUpdate.EndTime = endTimeUpdateEditText.Text;
            });

            Toast.MakeText(this, GetString(Resource.String.message_edit_event), ToastLength.Short).Show();
            SetResultData(DataManager.RealmInstance.All<EventData>()
                .Where(item => item.Title == this.eventData.Title)
                .FirstOrDefault());            
        }

        private void SetResultData(EventData eventUpdate) {
            Intent intent = new Intent();
            intent.PutExtra("EVENT", JsonConvert.SerializeObject(eventUpdate));
            SetResult(Result.Ok, intent);
            Finish();
        }
    }
}

