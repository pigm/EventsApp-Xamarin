using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Widget;
using Event.Commons;
using Event.Commons.Utils;
using Event.Event.Data;
using Event.Event.Data.Mapper;
using Event.Event.Domain.Model;
using Event.Event.Presentation.Contract;
using Event.Home.Presentation.Presenter;

namespace Event.Event.Presentation.Presenter
{
    public class ListEventPresenter: ListEventContract.Presenter
    {
        EventToDomainMapper mapperEventToDomain = EventToDomainMapper.Instance;
        EventToDataMapper mapperEventToData = EventToDataMapper.Instance;
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
            GeneralUtils.ValidateIconForCategory(category, categoryImage, context);            
        }

        public List<EventDomain> GetListEvent(string category)
        {
            List<EventData> listEventDataFilterCategory = DataManager.RealmInstance.All<EventData>().Where(w => w.Category == category).ToList<EventData>();
            return mapperEventToDomain.Map(listEventDataFilterCategory);
        }

        public EventData SetObjectTransfer(EventDomain eventDomain) {
            return mapperEventToData.Map(eventDomain);
        }
    }
}

