
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Event.Commons;
using Event.Commons.Utils;
using Event.Event.Data;
using Event.Event.Presentation.Contract;
using static Android.App.DatePickerDialog;

namespace Event.Event.Presentation.Activity
{
    [Activity(Label = "AddEventActivity", Theme = "@style/ThemeNoActionBar", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
           Android.Content.PM.ConfigChanges.Orientation,
           ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class AddEventActivity : AppCompatActivity, BaseActivity, AddEventContract.View, IOnDateSetListener
    {
        private string category;
        private string URL_MERCADO_PAGO = "https://www.mercadopago.com.mx/paid?&utm_source=google&utm_medium=cpc&utm_campaign=MLM_MP_G_AO_GEN_ALL_BRAND_ALL_CONV_EXACT&matt_tool=53751208&matt_word=&gclid=CjwKCAjwpqCZBhAbEiwAa7pXeWwrWSV-hlxBJNvNNyWXAMTKafKXwTcqu_X9qfdKSdiBNbTgx68uRBoC7SUQAvD_BwE";
        Button addButton;
        ImageView backImage;
        TextView titleToolbarText;
        TextInputEditText titleEditText, categoryDetailEditText, addressEditText, dateEditText, startTimeEditText,
            endTimeEditText, imageUrleEditText, urlPaymentEditText, priceEditText;
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_add_event);
            InitComponentView();
            InitView();
        }

        public void InitComponentView()
        {
            addButton = (Button)FindViewById(Resource.Id.addButton);
            backImage = (ImageView)FindViewById(Resource.Id.backImage);
            titleToolbarText = (TextView)FindViewById(Resource.Id.titleToolbarText);
            titleEditText = (TextInputEditText)FindViewById(Resource.Id.titleEditText);
            categoryDetailEditText = (TextInputEditText)FindViewById(Resource.Id.categoryDetailEditText);
            addressEditText = (TextInputEditText)FindViewById(Resource.Id.addressEditText);
            dateEditText = (TextInputEditText)FindViewById(Resource.Id.dateEditText);
            startTimeEditText = (TextInputEditText)FindViewById(Resource.Id.startTimeEditText);
            endTimeEditText = (TextInputEditText)FindViewById(Resource.Id.endTimeEditText);
            imageUrleEditText = (TextInputEditText)FindViewById(Resource.Id.imageUrleEditText);
            urlPaymentEditText = (TextInputEditText)FindViewById(Resource.Id.urlPaymentEditText);
            priceEditText = (TextInputEditText)FindViewById(Resource.Id.priceEditText);
        }

        public void InitView()
        {
            category = Intent.GetStringExtra("CATEGORY");
            backImage.Click += delegate { Finish(); };
            titleToolbarText.Text = GetString(Resource.String.add_event);
            categoryDetailEditText.Text = category.ToString();
            categoryDetailEditText.Enabled = false;
            categoryDetailEditText.Focusable = false;
            urlPaymentEditText.Text = URL_MERCADO_PAGO;
            dateEditText.Touch += delegate { ShowDialog(1); };
            addButton.Click += delegate { CreateEventObject(); };
        }

        public void CreateEventObject()
        {
            if (!validateEditText())
            {
                Toast.MakeText(this, GetString(Resource.String.input_empty), ToastLength.Short).Show();
                return;
            }
            else
            {
                AddPersistentData();
                Finish();
            }
        }

        public void AddPersistentData() {
            DataManager.RealmInstance.Write(() =>
            {               
                EventData eventData = new EventData
                {
                    Title = titleEditText.Text,
                    Category = category,
                    Address = addressEditText.Text,
                    Date = dateEditText.Text,
                    StartTime = startTimeEditText.Text,
                    EndTime = endTimeEditText.Text,
                    ImageUrl = imageUrleEditText.Text,
                    Price = Double.Parse(priceEditText.Text),
                    UrlPago = urlPaymentEditText.Text
                };
                DataManager.RealmInstance.Add(eventData);
            });
        }

        private bool validateEditText()
        {
            if (!string.IsNullOrEmpty(titleEditText.Text) && !string.IsNullOrEmpty(addressEditText.Text) &&
                !string.IsNullOrEmpty(dateEditText.Text) && !string.IsNullOrEmpty(startTimeEditText.Text) &&
                !string.IsNullOrEmpty(endTimeEditText.Text) && !string.IsNullOrEmpty(imageUrleEditText.Text) &&
                !string.IsNullOrEmpty(urlPaymentEditText.Text) && !string.IsNullOrEmpty(priceEditText.Text))
            {
                return true;
            }
            return false;
        }     

        protected override Dialog OnCreateDialog(int id)
        {
            HideKeyboard(titleEditText);
            HideKeyboard(addressEditText);
            HideKeyboard(startTimeEditText);
            HideKeyboard(endTimeEditText);
            HideKeyboard(imageUrleEditText);
            HideKeyboard(urlPaymentEditText);
            HideKeyboard(priceEditText);          
            var datePickerFechaElaboracion = new DatePickerDialog(this, this, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            datePickerFechaElaboracion.DatePicker.MaxDate = GeneralUtils.SetMaxDate(185);
            datePickerFechaElaboracion.DatePicker.MinDate = GeneralUtils.SetMinDate();
            return datePickerFechaElaboracion;
        }

        public void HideKeyboard(TextInputEditText editText)
        {
            InputMethodManager inputMethodManager = (InputMethodManager)GetSystemService(Context.InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(editText.WindowToken, 0);
        }

        public void OnDateSet(DatePicker view, int year, int month, int dayOfMonth)
        {
            dateEditText.Text = GeneralUtils.DateFormat(year, month, dayOfMonth);
        }
    }
}