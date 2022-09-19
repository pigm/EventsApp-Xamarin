
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

namespace Event.Event.Presentation.Activity
{
    [Activity(Label = "AddEventActivity", Theme = "@style/ThemeNoActionBar", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
           Android.Content.PM.ConfigChanges.Orientation,
           ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class AddEventActivity : AppCompatActivity, BaseActivity
    {
        ImageView backImage;
        TextView titleToolbarText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_add_event);
            InitComponentView();
            InitView();
        }

        public void InitComponentView()
        {
            backImage = (ImageView)FindViewById(Resource.Id.backImage);
            titleToolbarText = (TextView)FindViewById(Resource.Id.titleToolbarText);
        }

        public void InitView()
        {
            backImage.Click += delegate { Finish(); };
            titleToolbarText.Text = GetString(Resource.String.add_event);
        }
    }
}

