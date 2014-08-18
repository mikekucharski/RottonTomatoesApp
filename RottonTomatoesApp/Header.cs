using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
//using Android.Util;

namespace RottonTomatoesApp
{
	public class Header : Item
	{
		String name;
		public Header (String name)
		{
			this.name = name;
		}

		int Item.getViewType(){
			return 0;
		}

		View Item.getView(LayoutInflater inflater, View convertView){
			View view = convertView;
			if (convertView == null) // no view to re-use, create new
				view = (View) inflater.Inflate (Resource.Layout.ListItemHeader, null);

			view.FindViewById<TextView> (Resource.Id.headerrr).Text = name;
			return view;
		}
	}
}

