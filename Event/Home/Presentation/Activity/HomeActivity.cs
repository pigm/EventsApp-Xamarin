using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Com.Gigamole.Infinitecycleviewpager;
using Event.Commons.Utils;
using Event.Home.Data.Model;
using Event.Home.Presentation.Adapter;
using Event.Home.Presentation.Presenter;

namespace Event.Home.Presentation.Activity
{
    [Activity(Label = "HomeActivity", Theme = "@style/ThemeNoActionBar", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class HomeActivity : AppCompatActivity, BaseActivity
    {
        HomePresenter presenter = HomePresenter.Instance;
        HorizontalInfiniteCycleViewPager viewPager;

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
            var listCategory = presenter.SetData();
            viewPager.Adapter = new HomeAdapter(this, listCategory);
        }
    }
}
