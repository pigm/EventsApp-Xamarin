using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Event.Commons.Utils;
using Event.Home.Presentation.Activity;

namespace Event
{

    [Activity(Label = "@string/app_name", Theme = "@style/SplashStyle", MainLauncher = true, ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity, BaseActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            InitView();
        }

        public void InitComponentView()
        {
            throw new NotImplementedException();
        }

        public void InitView()
        {
            Task startupWork = new Task(() =>
            {
                Task.Delay(10000);
            });

            startupWork.ContinueWith(v =>
            {
                try
                {
                    StartActivity(new Intent(this, typeof(HomeActivity)));
                    Finish();
                }
                catch (Exception e)
                {
                    Log.Error("Splash", e.Message);
                }

                return Task.CompletedTask;
            }, TaskScheduler.FromCurrentSynchronizationContext());

            startupWork.Start();
        }

    }
}