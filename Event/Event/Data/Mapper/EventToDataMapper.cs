using System;
using System.Collections.Generic;
using Event.Commons.Utils;
using Event.Event.Domain.Model;

namespace Event.Event.Data.Mapper
{
    public class EventToDataMapper
    {
        static EventToDataMapper instance = null;

        public EventToDataMapper()
        {
        }

        public static EventToDataMapper Instance
        {
            get
            {
                if (instance == null)
                    instance = new EventToDataMapper();
                return instance;
            }
        }

        public EventData Map(EventDomain eventDomain)
        {
            EventData eventTransferDomain = new EventData
            {
                Title = eventDomain.Title,
                Category = eventDomain.Category,
                Address = eventDomain.Address,
                Date = eventDomain.Date,
                StartTime = eventDomain.StartTime,
                EndTime = eventDomain.EndTime,
                ImageUrl = eventDomain.ImageUrl,
                Price = eventDomain.Price,
                UrlPago = eventDomain.UrlPago
            };
            
            return eventTransferDomain;
        }
    }
}

