using System;
namespace Event.Event.Presentation.Contract
{
    public interface AddEventContract
    {
        public interface View
        {
            void CreateEventObject();
            void AddPersistentData();
        }

        public interface Presenter
        {

        }
    }
}

