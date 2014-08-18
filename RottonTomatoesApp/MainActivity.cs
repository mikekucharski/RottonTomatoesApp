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
	[Activity (Label = "Rotton Tomatoes", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.Holo.Light")]	
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			this.Title = "Box Office Movies";

			SetContentView (Resource.Layout.Main);
			String url = "http://content6.flixster.com/movie/11/17/98/11179872_mob.jpg";
			List<Item> items = new List<Item> ();
			items.Add(new Header("Opening This Week"));
			items.Add(new MovieItem("Hello", "World", url));
			items.Add(new MovieItem("Hello", "World", url));
			items.Add(new MovieItem("Hello", "World", url));
			items.Add(new Header("Top Box Office"));
			items.Add(new MovieItem("Hello", "World", url));
			items.Add(new MovieItem("Hello", "World", url));
			items.Add(new MovieItem("Hello", "World", url));
			items.Add(new Header("Also In Theaters"));
			items.Add(new MovieItem("Hello", "World", url));
			items.Add(new MovieItem("Hello", "World", url));
			items.Add(new MovieItem("Hello", "World", url));
		
			ListView listview = FindViewById<ListView> (Resource.Id.BoxOfficeMoviesList);
			listview.SetWillNotCacheDrawing (true); // improve list views performance
			listview.Adapter = new BoxOfficeAdapter (this, items);
			listview.ItemClick += (sender, e) => {
				if(items[e.Position].getViewType() == 1){
					Toast.MakeText (this, "You clicked a list item! ", ToastLength.Long).Show();
					var movieActivity = new Intent(this, typeof(MovieActivity));
					movieActivity.
					StartActivity(movieActivity);
				}
			};
		}
	}

}

