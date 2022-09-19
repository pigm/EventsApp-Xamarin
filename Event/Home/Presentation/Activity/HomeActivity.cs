using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Com.Gigamole.Infinitecycleviewpager;
using Event.Commons.Utils;
using Event.Home.Data.Model;
using Event.Home.Presentation.Adapter;

namespace Event.Home.Presentation.Activity
{
    [Activity(Label = "HomeActivity", Theme = "@style/ThemeNoActionBar", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class HomeActivity : AppCompatActivity, BaseActivity
    {
        HorizontalInfiniteCycleViewPager viewPager;
        List<CategoryData> listEvent = new List<CategoryData>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_home);
            InitComponentView();
            InitView();
        }

        public void InitComponentView()
        {
            viewPager = FindViewById<HorizontalInfiniteCycleViewPager>(Resource.Id.viewPager);
        }

        public void InitView()
        {
            InitData();
            viewPager.Adapter = new HomeAdapter(this, listEvent);
        }

        private void InitData()
        {
            listEvent.Add(new CategoryData(Constants.CONCERTS, Resource.Drawable.img_concerts));
            listEvent.Add(new CategoryData(Constants.CINEMA, Resource.Drawable.img_cinema));
            listEvent.Add(new CategoryData(Constants.PODCAST, Resource.Drawable.img_podcast));
            listEvent.Add(new CategoryData(Constants.FIFA_WORLD_CUP, Resource.Drawable.img_qatar));
            listEvent.Add(new CategoryData(Constants.THEATER, Resource.Drawable.img_theater));
            listEvent.Add(new CategoryData(Constants.STANDUP, Resource.Drawable.img_standup));
            listEvent.Add(new CategoryData(Constants.LOLLAPALOZA, Resource.Drawable.img_lollapaloza));
        }
    }
}
