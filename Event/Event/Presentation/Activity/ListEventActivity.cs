
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
using Event.Event.Domain.Model;
using System.Reflection;
using static Android.Service.Carrier.CarrierMessagingService;

namespace Event.Event.Presentation.Activity
{
    [Activity(Label = "ListEventActivity", Theme = "@style/ThemeNoActionBar", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
            Android.Content.PM.ConfigChanges.Orientation,
            ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ListEventActivity : AppCompatActivity, BaseActivity, ListEventContract.View
    {
        private List<EventDomain> listEventDataFilterCategory;
        private ListEventAdapter adapter;
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

            listEventDataFilterCategory = presenter.GetListEvent(category);
            adapter = new ListEventAdapter(this, listEventDataFilterCategory);
            eventGridView.Adapter = adapter;
            eventGridView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args) {
                GoToEventDetail(JsonConvert.SerializeObject(presenter.SetObjectTransfer(listEventDataFilterCategory[args.Position])));
            };
            presenter.ShowIconForCategory(category, categoryImage, this);
        }
      
        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }

        private void GoToAddEvent() {
            Intent goToAddEventActivity = new Intent(this, typeof(AddEventActivity));
            goToAddEventActivity.PutExtra("CATEGORY", category);
            StartActivityForResult(goToAddEventActivity, Constants.FROM_LIST_EVENT_TO_ADD);
        }

        private void GoToEventDetail(string jsonObject) {
            Intent goToDetailEvent = new Intent(this, typeof(EventDetailActivity));
            goToDetailEvent.PutExtra("EVENT", jsonObject);
            StartActivityForResult(goToDetailEvent, Constants.FROM_LIST_EVENT_TO_DETAIL);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            //adapter = ((ListEventAdapter)eventGridView.Adapter);
            if (requestCode == Constants.FROM_LIST_EVENT_TO_ADD || requestCode == Constants.FROM_LIST_EVENT_TO_DETAIL)
            {
                RefreshAdapter();
            }            
        }

        private void RefreshAdapter() {
            listEventDataFilterCategory = presenter.GetListEvent(category);
            adapter.RefillItems(listEventDataFilterCategory);
        }
    }
}