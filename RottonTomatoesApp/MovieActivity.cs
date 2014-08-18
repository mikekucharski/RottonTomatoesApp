using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RottonTomatoesApp
{
	[Activity (Label = "MovieActivity", Icon = "@drawable/icon", Theme = "@android:style/Theme.Holo.Light")]			
	public class MovieActivity : Activity
	{
		private string id, title;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Movie);
			id = Intent.GetStringExtra ("MovieID") ?? "Data not available";
			title = Intent.GetStringExtra ("MovieTitle") ?? "Data not available";

			this.Title = title;
			Toast.MakeText (this, "You clicked list item " + id, ToastLength.Long).Show();
		}
	}
}

