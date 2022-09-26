using System;
using Android.Content;
using Android.Widget;
using Event.Commons.Utils;
using Event.Event.Data.Mapper;
using Event.Event.Presentation.Contract;
using static Android.Provider.CalendarContract;

namespace Event.Event.Presentation.Presenter
{
    public class EventDetailPresenter: EventDetailContract.Presenter
    {       
        static EventDetailPresenter instance = null;

        public EventDetailPresenter()
        {
        }

        public static EventDetailPresenter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventDetailPresenter();                  
                }
                return instance;
            }
        }

        public void ShowIconForCategory(Context context, string category, ImageView categoryImage, TextView categoryText)
        {
            GeneralUtils.ValidateIconForCategory(category, categoryImage, context);
            categoryText.Text = context.GetString(Resource.String.category_detail) + " " + category.ToLower() + ".";
        }        
    }
}

