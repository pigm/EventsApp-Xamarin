using System;
using Android.OS;

namespace Event.Event.Data
{
    public class EventData
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

        public EventData(string title, string category, string address, string date, string startTime, string endTime, string imageUrl, double price, string urlPago)
        {
            this.Title = title;
            this.Category = category;
            this.Address = address;
            this.Date = date;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.ImageUrl = imageUrl;
            this.Price = price;
            this.UrlPago = urlPago;
        }
    }
}

