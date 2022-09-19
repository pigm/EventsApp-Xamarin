
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
using Event.Event.Presentation.Presenter;

namespace Event.Event.Presentation.Activity
{
    [Activity(Label = "HomeActivity", Theme = "@style/ThemeNoActionBar", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
            Android.Content.PM.ConfigChanges.Orientation,
            ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ListEventActivity : AppCompatActivity, BaseActivity
    {
        ListEventPresenter presenter = ListEventPresenter.Instance;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_list_event);
        }

        public void InitComponentView()
        {
            throw new NotImplementedException();
        }

        public void InitView()
        {
            throw new NotImplementedException();
        }
    }
}

