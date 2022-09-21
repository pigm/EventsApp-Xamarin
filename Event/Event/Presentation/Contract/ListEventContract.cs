using System;
using Event.Home.Data.Model;
using System.Collections.Generic;
using Android.Widget;
using Android.Content;

namespace Event.Event.Presentation.Contract
{
    public interface ListEventContract
    {
        public interface View
        {
     
        }

        public interface Presenter
        {
            void ShowIconForCategory(string category, ImageView categoryImage, Context context);
        }
    }
}

