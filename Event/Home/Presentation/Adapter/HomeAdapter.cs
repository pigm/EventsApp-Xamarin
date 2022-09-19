using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using Android.Content;
using Android.Graphics;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Java.IO;
using Java.Net;
using Square.Picasso;
using Event.Home.Data.Model;
using Event.Event.Presentation.Activity;

namespace Event.Home.Presentation.Adapter
{
    public class HomeAdapter : PagerAdapter
    {
        Context context;
        List<CategoryData> categoryDataList;

        public HomeAdapter(Context context, List<CategoryData> categoryDataList)
        {
            this.context = context;
            this.categoryDataList = categoryDataList;
        }

        public override int Count => categoryDataList.Count;

        public override bool IsViewFromObject(View view, Java.Lang.Object @object)
        {
            return view == @object;
        }

        public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object @object)
        {
            container.RemoveView((View)@object);
        }

        public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
        {
            View view = LayoutInflater.From(context).Inflate(Resource.Layout.item_card, container, false);

            var cardImage = view.FindViewById<ImageView>(Resource.Id.cardImage);

            cardImage.SetImageResource(categoryDataList[position].ImageUrl);

            view.Click += delegate
            {
                context.StartActivity(new Intent(context, typeof(ListEventActivity)));
            };

            container.AddView(view);
            return view;
        }     
    }
}
