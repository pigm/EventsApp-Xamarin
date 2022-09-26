using System;
using Realms;

namespace Event.Event.Data
{
    public class EventData: RealmObject
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string Address { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }        
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public string UrlPago { get; set; }       
    }
}

