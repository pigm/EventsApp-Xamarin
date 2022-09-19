
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

namespace Event.Event.Presentation.Activity
{
    [Activity(Label = "ListEventActivity", Theme = "@style/ThemeNoActionBar", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
            Android.Content.PM.ConfigChanges.Orientation,
            ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ListEventActivity : AppCompatActivity, BaseActivity
    {
        Button addEventButton;
        GridView eventGridView;
        ImageView backImage;
        TextView titleToolbarText;
        ListEventPresenter presenter = ListEventPresenter.Instance;

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
            titleToolbarText = (TextView)FindViewById(Resource.Id.titleToolbarText);

        }

        public void InitView()
        {
            addEventButton.Click += delegate { StartActivity(new Intent(this, typeof(AddEventActivity))); };
            backImage.Click += delegate { Finish(); };
            titleToolbarText.Text = GetString(Resource.String.events);
            List<EventData> listEventData = new List<EventData>();
            listEventData.Add(new EventData("Bad bunny, La playa tour", "Concierto", "Arena Monterrey", "20 Noviembre 2022", "18:00", "00:00", "https://i.pinimg.com/736x/7e/d9/a2/7ed9a2493ea2fe2c5ac6a991dc3351fe.jpg", 1500.50, "https://www.mercadopago.com.mx/paid?&utm_source=google&utm_medium=cpc&utm_campaign=MLM_MP_G_AO_GEN_ALL_BRAND_ALL_CONV_EXACT&matt_tool=53751208&matt_word=&gclid=CjwKCAjwpqCZBhAbEiwAa7pXeWwrWSV-hlxBJNvNNyWXAMTKafKXwTcqu_X9qfdKSdiBNbTgx68uRBoC7SUQAvD_BwE"));
            listEventData.Add(new EventData("Karol G, Bichota tour", "Concierto", "Arena Monterrey", "13 Diciembre 2022", "21:00", "00:00", "https://i.pinimg.com/564x/e6/9e/3d/e69e3d1b47fafd4889358435f4e60e97.jpg", 800.00, "https://www.mercadopago.com.mx/paid?&utm_source=google&utm_medium=cpc&utm_campaign=MLM_MP_G_AO_GEN_ALL_BRAND_ALL_CONV_EXACT&matt_tool=53751208&matt_word=&gclid=CjwKCAjwpqCZBhAbEiwAa7pXeWwrWSV-hlxBJNvNNyWXAMTKafKXwTcqu_X9qfdKSdiBNbTgx68uRBoC7SUQAvD_BwE"));
            listEventData.Add(new EventData("Anuel AA, Leyendas tour", "Concierto", "Arena Monterrey", "27 Diciembre 2022", "20:00", "00:00", "https://i.pinimg.com/564x/c8/eb/b9/c8ebb90a996a81b2eb4dba2b1bec93c6.jpg", 1950.00, "https://www.mercadopago.com.mx/paid?&utm_source=google&utm_medium=cpc&utm_campaign=MLM_MP_G_AO_GEN_ALL_BRAND_ALL_CONV_EXACT&matt_tool=53751208&matt_word=&gclid=CjwKCAjwpqCZBhAbEiwAa7pXeWwrWSV-hlxBJNvNNyWXAMTKafKXwTcqu_X9qfdKSdiBNbTgx68uRBoC7SUQAvD_BwE"));
            ListEventAdapter adapter = new ListEventAdapter(this, listEventData);
            eventGridView.Adapter = adapter;      
        }
    }
}