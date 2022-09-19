using System;
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
    }
}

