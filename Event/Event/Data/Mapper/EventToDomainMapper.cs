using System;
using System.Collections.Generic;
using Event.Commons.Utils;
using Event.Event.Domain.Model;
using Event.Event.Presentation.Presenter;

namespace Event.Event.Data.Mapper
{
    public class EventToDomainMapper
    {
        static EventToDomainMapper instance = null;

        public EventToDomainMapper()
        {
        }

        public static EventToDomainMapper Instance
        {
            get
            {
                if (instance == null)
                    instance = new EventToDomainMapper();
                return instance;
            }
        }

        public List<EventDomain> Map(List<EventData> listEvent)
        {
            List<EventDomain> listEventDomain = new List<EventDomain>();
            foreach (EventData item in listEvent)
            {
                EventDomain eventDomain = new EventDomain
                {
                    Title = item.Title,
                    Category = item.Category,
                    Address = item.Address,
                    Date = item.Date,
                    StartTime = item.StartTime,
                    EndTime = item.EndTime,
                    ImageUrl = item.ImageUrl,
                    ImageBitmap = GeneralUtils.LoadImageFromWebOperations(item.ImageUrl),
                    Price = item.Price,
                    UrlPago = item.UrlPago
                };
                listEventDomain.Add(eventDomain);
            }

            return listEventDomain;
        }
    }
}

