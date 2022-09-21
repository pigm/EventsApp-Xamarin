using System;
using Android.Content;
using Android.Widget;
using Event.Commons.Utils;
using Event.Event.Presentation.Contract;
using Event.Home.Presentation.Presenter;

namespace Event.Event.Presentation.Presenter
{
    public class ListEventPresenter: ListEventContract.Presenter
    {
        static ListEventPresenter instance = null;

        public ListEventPresenter()
        {
        }

        public static ListEventPresenter Instance
        {
            get
            {
                if (instance == null)
                    instance = new ListEventPresenter();
                return instance;
            }
        }

        public void ShowIconForCategory(string category, ImageView categoryImage, Context context)
        {
            if (category.Equals(Constants.CONCERTS) || category.Equals(Constants.LOLLAPALOZA))
            {
                categoryImage.SetImageDrawable(context.GetDrawable(Resource.Drawable.ic_concert));
                return;
            }
            else if (category.Equals(Constants.FIFA_WORLD_CUP))
            {
                categoryImage.SetImageDrawable(context.GetDrawable(Resource.Drawable.ic_sport));
                return;
            }
            else if (category.Equals(Constants.THEATER))
            {
                categoryImage.SetImageDrawable(context.GetDrawable(Resource.Drawable.ic_culture));
                return;
            }
            else if (category.Equals(Constants.STANDUP))
            {
                categoryImage.SetImageDrawable(context.GetDrawable(Resource.Drawable.ic_standup));
                return;
            }
            else
            {
                categoryImage.SetImageDrawable(context.GetDrawable(Resource.Drawable.ic_other));
            }
        }
    }
}

