using System;
using Event.Home.Data.Model;
using System.Collections.Generic;

namespace Event.Home.Presentation.Contract
{
    public interface HomeContract
    {
        public interface View
        {

        }

        public interface Presenter
        {
            List<CategoryData> SetData();
        }
    }
}

