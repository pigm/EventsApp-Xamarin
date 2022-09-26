using System;
using Android.Content;
using Android.Widget;

namespace Event.Event.Presentation.Contract
{
    public interface EventDetailContract
    {
        public interface View
        {

        }

        public interface Presenter
        {
            void ShowIconForCategory(Context context, string category, ImageView categoryImage, TextView categoryText);
        }
    }
}

