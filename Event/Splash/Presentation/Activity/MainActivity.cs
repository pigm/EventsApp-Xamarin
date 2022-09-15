using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Event.Home.Presentation.Activity;

namespace Event
{

    [Activity(Label = "@string/app_name", Theme = "@style/SplashStyle", MainLauncher = true, ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Task startupWork = new Task(() =>
            {
                Task.Delay(10000);
            });

            startupWork.ContinueWith(async t => {
                try {
                    StartActivity(new Intent(this, typeof(HomeActivity)));
                }
                catch (Exception e) {
                    Log.Error("Splash", e.Message);
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());

            startupWork.Start();
        }

    }
}