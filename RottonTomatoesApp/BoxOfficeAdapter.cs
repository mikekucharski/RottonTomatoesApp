using System;
using System.Collections.Generic;

using Android.App;
using Android.Views;
using Android.Widget;

namespace RottonTomatoesApp
{
	public class BoxOfficeAdapter : ArrayAdapter<Item> {
	
		LayoutInflater inflater;

		public BoxOfficeAdapter(Activity context, List<Item> items) : base(context, 0, items)
		{
			inflater = context.LayoutInflater;
		}
			
		public override int GetItemViewType (int position)
		{
			return this.GetItem(position).getViewType ();
		}

		public override int ViewTypeCount {
			get {
				return 2;
			}
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			return GetItem(position).getView(inflater, convertView);
		}
	}
}

