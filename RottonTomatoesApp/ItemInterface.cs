using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

public interface Item {
	int getViewType();
	View getView(LayoutInflater inflater, View convertView);
}