using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Com.Gigamole.Infinitecycleviewpager;
using Event.Home.Data.Model;
using Event.Home.Presentation.Adapter;

namespace Event.Home.Presentation.Activity
{
    [Activity(Label = "HomeActivity", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class HomeActivity : AppCompatActivity
    {
        HorizontalInfiniteCycleViewPager viewPager;
        List<EventData> listEvent = new List<EventData>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_home);
            InitData();
            viewPager = FindViewById<HorizontalInfiniteCycleViewPager>(Resource.Id.viewPager);
            viewPager.Adapter = new HomeAdapter(this, listEvent);
        }

        private void InitData()
        {
            listEvent.Add(new EventData("Shakira", "Shakira Isabel Mebarak Ripoll (Barranquilla, Colombia; 2 de febrero de 1977), conocida simplemente como Shakira, es una cantautora, bailarina, actriz y empresaria colombiana naturalizada española.", "https://es.wikipedia.org/wiki/Shakira#/media/Archivo:Shakira_for_VOGUE_in_2021_2.png"));
            listEvent.Add(new EventData("Juan Gabriel", "Alberto Aguilera Valadez (Parácuaro, Michoacán, 7 de enero de 1950-Santa Mónica, California, 28 de agosto de 2016), conocido como Juan Gabriel, fue un cantautor y actor mexicano.", "https://es.wikipedia.org/wiki/Juan_Gabriel#/media/Archivo:Juan_Gabriel_---_Pepsi_Center_---_09.26.14_(cropped_2).jpg"));
        }
    }
}
