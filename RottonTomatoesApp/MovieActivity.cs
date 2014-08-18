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
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			this.Title = "Movie";

			SetContentView (Resource.Layout.Movie);
		}
	}
}

