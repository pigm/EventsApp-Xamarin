using System;

namespace Event.Home.Data.Model
{
    public class CategoryData
    {
        public string Name { get; set; }
        public int ImageUrl { get; set; }

        public CategoryData(string Name, int ImageUrl)
        {
            this.Name = Name;
            this.ImageUrl = ImageUrl;
        }
    }
}

