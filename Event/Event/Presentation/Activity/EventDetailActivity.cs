
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
using Event.Event.Presentation.Presenter;
using Newtonsoft.Json;
using Org.Json;
using static Android.Content.ClipData;
using static Android.Icu.Text.Transliterator;

namespace Event.Event.Presentation.Activity
{
    [Activity(Label = "EventDetailActivity", Theme = "@style/ThemeNoActionBar", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
           Android.Content.PM.ConfigChanges.Orientation,
           ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class EventDetailActivity : AppCompatActivity, BaseActivity
    {
        private EventData eventData;
        Button paymentDetailButton;
        LinearLayout optionsButton;
        ImageView eventDetailImage, backImage, optionsImage, categoryDetailImage;
        TextView titleEventDetailText, dayDetailText, monthDetailText,
            startTimeDetailText, endTimeDetailText, addressEventDetailText,
            priceEventDetailText, titleToolbarText, categoryText;
        EventDetailPresenter presenter = EventDetailPresenter.Instance;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_detail_event);
            InitComponentView();
            InitView();
        }

        public void InitComponentView()
        {
            optionsButton = (LinearLayout)FindViewById(Resource.Id.optionsButton);
            optionsImage = (ImageView)FindViewById(Resource.Id.optionsImage);
            backImage = (ImageView)FindViewById(Resource.Id.backImage);
            categoryDetailImage = (ImageView)FindViewById(Resource.Id.categoryDetailImage);
            categoryText = (TextView)FindViewById(Resource.Id.categoryText);
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
        }

        public void InitView()
        {
            eventData = JsonConvert.DeserializeObject<EventData>(Intent.GetStringExtra("EVENT"));
            optionsButton.Visibility = ViewStates.Visible;
            optionsImage.Click += delegate
            {
                ShowMenu();
            };
            backImage.Click += delegate
            {
                Finish();
            };
            titleToolbarText.Text = GetString(Resource.String.events_detail);
            SetDataView(eventData);
            paymentDetailButton.Click += delegate
            {
                GoToUrlPayment();
            };
            presenter.ShowIconForCategory(this, eventData.Category, categoryDetailImage, categoryText);
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
            Toast.MakeText(this, GetString(Resource.String.message_detele_event), ToastLength.Short).Show();
            Finish();
        }

        private void GoToUpdateEvent()
        {
            Intent goToUpdateEvent = new Intent(this, typeof(UpdateEventActivity));
            goToUpdateEvent.PutExtra("EVENT", JsonConvert.SerializeObject(eventData));
            StartActivityForResult(goToUpdateEvent, Constants.FROM_DETAIL_TO_UPDATE);
        }

        private void GoToUrlPayment()
        {
            Android.Net.Uri uri = Android.Net.Uri.Parse(eventData.UrlPago);
            Intent i = new Intent(Intent.ActionView);
            i.SetData(uri);
            StartActivity(i);
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }

        private void ShowMenu()
        {
            PopupMenu popupMenu = new PopupMenu(this, optionsImage);
            popupMenu.Inflate(Resource.Menu.menu_event_options);
            popupMenu.MenuItemClick += (s, arg) =>
            {
                switch (arg.Item.ItemId)
                {
                    case Resource.Id.delete:
                        DeleteEvent();
                        break;
                    default:
                        GoToUpdateEvent();
                        break;
                }
            };
            popupMenu.Show();
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            //adapter = ((ListEventAdapter)eventGridView.Adapter);
            if (requestCode == Constants.FROM_DETAIL_TO_UPDATE
                && resultCode == Result.Ok
                && data != null)
            {
                eventData = JsonConvert.DeserializeObject<EventData>(data.GetStringExtra("EVENT"));
                SetDataView(eventData);
            }
        }

        private void SetDataView(EventData data) {
            eventDetailImage.SetImageBitmap(GeneralUtils.LoadImageFromWebOperations(data.ImageUrl));
            titleEventDetailText.Text = data.Title;
            dayDetailText.Text = data.Date.Substring(0, 2);
            monthDetailText.Text = data.Date.Substring(3, 3);
            startTimeDetailText.Text = "De " + data.StartTime;
            endTimeDetailText.Text = data.EndTime;
            addressEventDetailText.Text = data.Address;
            var price = String.Format("{0:N0}", data.Price);
            priceEventDetailText.Text = "$" + price + ".00 MXN";
        }
    }
}