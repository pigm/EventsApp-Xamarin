using System;
using Android.Support.Design.Widget;
using Android.Widget;

namespace Event.Event.Presentation.Contract
{
    public interface AddEventContract
    {
        public interface View
        {
            void CreateEventObject();
            void AddPersistentData();
            void HideKeyboard(TextInputEditText editText);
        }

        public interface Presenter
        {

        }
    }
}

