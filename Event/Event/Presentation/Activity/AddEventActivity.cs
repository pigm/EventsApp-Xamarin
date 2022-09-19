
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
using Event.Event.Presentation.Contract;

namespace Event.Event.Presentation.Activity
{
    [Activity(Label = "AddEventActivity", Theme = "@style/ThemeNoActionBar", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
           Android.Content.PM.ConfigChanges.Orientation,
           ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class AddEventActivity : AppCompatActivity, BaseActivity, AddEventContract.View
    {
        Button addButton;
        ImageView backImage;
        TextView titleToolbarText;
        TextInputEditText titleEditText, categoryEditText, addressEditText, dateEditText, startTimeEditText,
            endTimeEditText, imageUrleEditText, urlPaymentEditText, priceEditText;
        string category;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_add_event);
            InitComponentView();
            InitView();
        }

        public void InitComponentView()
        {
            addButton = (Button)FindViewById(Resource.Id.addButton);
            backImage = (ImageView)FindViewById(Resource.Id.backImage);
            titleToolbarText = (TextView)FindViewById(Resource.Id.titleToolbarText);
            titleEditText = (TextInputEditText)FindViewById(Resource.Id.titleEditText);
            categoryEditText = (TextInputEditText)FindViewById(Resource.Id.categoryEditText);
            addressEditText = (TextInputEditText)FindViewById(Resource.Id.addressEditText);
            dateEditText = (TextInputEditText)FindViewById(Resource.Id.dateEditText);
            startTimeEditText = (TextInputEditText)FindViewById(Resource.Id.startTimeEditText);
            endTimeEditText = (TextInputEditText)FindViewById(Resource.Id.endTimeEditText);
            imageUrleEditText = (TextInputEditText)FindViewById(Resource.Id.imageUrleEditText);
            urlPaymentEditText = (TextInputEditText)FindViewById(Resource.Id.urlPaymentEditText);
            priceEditText = (TextInputEditText)FindViewById(Resource.Id.priceEditText);
        }

        public void InitView()
        {
            category = Intent.GetStringExtra("CATEGORY");
            backImage.Click += delegate { Finish(); };
            titleToolbarText.Text = GetString(Resource.String.add_event);
            categoryEditText.Text = category;
            categoryEditText.Enabled = false;
            categoryEditText.Focusable = false;
            addButton.Click += delegate { CreateEventObject(); };
        }

        public void CreateEventObject()
        {
            if (!validateEditText())
            {
                Toast.MakeText(this, GetString(Resource.String.input_empty), ToastLength.Short).Show();
                return;
            }
            else
            {
                AddPersistentData();
                Finish();
            }
        }

        public void AddPersistentData() {
            DataManager.RealmInstance.Write(() =>
            {               
                EventData eventData = new EventData
                {
                    Title = titleEditText.Text,
                    Category = category,
                    Address = addressEditText.Text,
                    Date = dateEditText.Text,
                    StartTime = startTimeEditText.Text,
                    EndTime = endTimeEditText.Text,
                    ImageUrl = imageUrleEditText.Text,
                    Price = Double.Parse(priceEditText.Text),
                    UrlPago = urlPaymentEditText.Text
                };
                DataManager.RealmInstance.Add(eventData);
            });
        }

        private bool validateEditText()
        {
            if (!string.IsNullOrEmpty(titleEditText.Text) && !string.IsNullOrEmpty(addressEditText.Text) &&
                !string.IsNullOrEmpty(dateEditText.Text) && !string.IsNullOrEmpty(startTimeEditText.Text) &&
                !string.IsNullOrEmpty(endTimeEditText.Text) && !string.IsNullOrEmpty(imageUrleEditText.Text) &&
                !string.IsNullOrEmpty(urlPaymentEditText.Text) && !string.IsNullOrEmpty(priceEditText.Text))
            {
                return true;
            }
            return false;
        }

        
    }
}

