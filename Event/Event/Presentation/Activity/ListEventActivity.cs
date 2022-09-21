
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
using Event.Commons.Utils;
using Event.Event.Presentation.Adapter;
using Event.Event.Presentation.Presenter;
using static Android.Webkit.WebSettings;
using static System.Net.Mime.MediaTypeNames;
using Event.Event.Data;
using Newtonsoft.Json;
using static Android.Provider.CalendarContract;
using static Android.Icu.Text.Transliterator;
using Event.Commons;
using static Android.Support.V7.Widget.RecyclerView;
using System.Runtime.Remoting.Contexts;
using Org.Json;
using Event.Event.Presentation.Contract;
using Android.Views.InputMethods;

namespace Event.Event.Presentation.Activity
{
    [Activity(Label = "ListEventActivity", Theme = "@style/ThemeNoActionBar", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
            Android.Content.PM.ConfigChanges.Orientation,
            ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ListEventActivity : AppCompatActivity, BaseActivity, ListEventContract.View
    {
        Button addEventButton;
        GridView eventGridView;
        ImageView backImage, categoryImage;
        TextView titleToolbarText;
        ListEventPresenter presenter = ListEventPresenter.Instance;
        string category;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_list_event);
            InitComponentView();
            InitView();
        }

        public void InitComponentView()
        {
            addEventButton = (Button)FindViewById(Resource.Id.addEventButton);
            eventGridView = (GridView) FindViewById(Resource.Id.eventGridView);
            backImage = (ImageView)FindViewById(Resource.Id.backImage);
            categoryImage = (ImageView)FindViewById(Resource.Id.categoryImage);
            titleToolbarText = (TextView)FindViewById(Resource.Id.titleToolbarText);
        }

        public void InitView()
        {
            category = Intent.GetStringExtra("CATEGORY");
            addEventButton.Click += delegate {
                GoToAddEvent();
            };
            backImage.Click += delegate { OnBackPressed(); };
            titleToolbarText.Text = category;
            List<EventData> listEventDataFilterCategory = DataManager.RealmInstance.All<EventData>().Where(w => w.Category == category).ToList<EventData>();          
            ListEventAdapter adapter = new ListEventAdapter(this, listEventDataFilterCategory);
            eventGridView.Adapter = adapter;
            eventGridView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args) {
                GoToEventDetail(JsonConvert.SerializeObject(listEventDataFilterCategory[args.Position]));
            };
            presenter.ShowIconForCategory(category, categoryImage, this);
        }

        protected override void OnResume()
        {
            base.OnResume();
            ListEventAdapter adapter = ((ListEventAdapter)eventGridView.Adapter);
            List<EventData> listEventDataFilterCategory = DataManager.RealmInstance.All<EventData>().Where(w => w.Category == category).ToList<EventData>();
            adapter.RefillItems(listEventDataFilterCategory);
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }

        private void GoToAddEvent() {
            Intent goToAddEventActivity = new Intent(this, typeof(AddEventActivity));
            goToAddEventActivity.PutExtra("CATEGORY", category);
            StartActivity(goToAddEventActivity);
        }

        private void GoToEventDetail(string jsonObject) {
            Intent goToDetailEvent = new Intent(this, typeof(EventDetailActivity));
            goToDetailEvent.PutExtra("EVENT", jsonObject);
            StartActivity(goToDetailEvent);
        }     
    }
}