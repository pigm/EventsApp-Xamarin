using System;
using System.Collections.Generic;
using Event.Commons.Utils;
using Event.Home.Data.Model;
using Event.Home.Presentation.Contract;
using static Android.Provider.CalendarContract;

namespace Event.Home.Presentation.Presenter
{
    public class HomePresenter: HomeContract.Presenter
    {
        private List<CategoryData> listCategory = new List<CategoryData>();
        static HomePresenter instance = null;

        public HomePresenter()
        {
        }

        public static HomePresenter Instance
        {
            get
            {
                if (instance == null)
                    instance = new HomePresenter();
                return instance;
            }
        }

        public List<CategoryData> SetData()
        {
            listCategory.Add(new CategoryData(Constants.CONCERTS, Resource.Drawable.img_concerts));
            listCategory.Add(new CategoryData(Constants.CINEMA, Resource.Drawable.img_cinema));
            listCategory.Add(new CategoryData(Constants.PODCAST, Resource.Drawable.img_podcast));
            listCategory.Add(new CategoryData(Constants.FIFA_WORLD_CUP, Resource.Drawable.img_qatar));
            listCategory.Add(new CategoryData(Constants.THEATER, Resource.Drawable.img_theater));
            listCategory.Add(new CategoryData(Constants.STANDUP, Resource.Drawable.img_standup));
            listCategory.Add(new CategoryData(Constants.LOLLAPALOZA, Resource.Drawable.img_lollapaloza));
            return listCategory;
        }
    }
}

