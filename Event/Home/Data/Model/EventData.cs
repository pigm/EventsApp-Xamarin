using System;
namespace Event.Home.Data.Model
{
    public class EventData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public EventData(string Name, string Description, string ImageUrl)
        {
            this.Name = Name;
            this.Description = Description;
            this.ImageUrl = ImageUrl;
        }

    }
}
