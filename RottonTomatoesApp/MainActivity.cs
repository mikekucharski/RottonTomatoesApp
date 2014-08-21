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
using Android.Util;

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
			string res = PortableAPI.RTAPI.getTopBoxOffice ();
			Log.Info ("test", res);
			res = "Hello";
			Log.Info ("test", res);

			string OTW = PortableAPI.RTAPI.getOpeningThisWeek ();
			List<MovieItem> otwMovies = StringHelper.getMoviesFromJson (OTW);


			String url = "http://content6.flixster.com/movie/11/17/98/11179872_mob.jpg";
			//url = "http://developer.xamarin.com/recipes/android/controls/imageview/display_an_image/Images/DisplayImage.png";
			List<Item> items = new List<Item> ();

			string[] cast = {"Joseph-Gordon Levitt", "Johnny Depp"};
			MovieItem m1 = new MovieItem ("123", "The Expendables", 41, "Certified Fresh",
										 cast, "PG-13", 120, "2014-11-08", url);
			MovieItem m2 = new MovieItem ("1234", "Harry Potter", 91, "Certified Fresh",
										 cast, "R", 210, "2001-12-31", url);
			MovieItem m3 = new MovieItem ("12345", "Rio 2", 13, "Rotton",
				                         cast, "PG", 112, "2014-01-01", url);
			items.Add(new Header("Opening This Week"));
			items.Add(m1);
			items.Add(m2);
			items.Add(m3);
			items.Add(new Header("Top Box Office"));
			items.Add(m1);
			items.Add(m2);
			items.Add(m3);
			items.Add(new Header("Also In Theaters"));
			items.Add(m1);
			items.Add(m2);
			items.Add(m3);
		
			ListView listview = FindViewById<ListView> (Resource.Id.BoxOfficeMoviesList);
			listview.SetWillNotCacheDrawing (true); // improve list views performance
			BoxOfficeAdapter b = new BoxOfficeAdapter (this, items);
			listview.Adapter = b;
			listview.ItemClick += (sender, e) => {
				if(items[e.Position].getViewType() == 1){
					//Toast.MakeText (this, "You clicked a list item! ", ToastLength.Long).Show();
					var movieActivity = new Intent(this, typeof(MovieActivity));
					movieActivity.PutExtra("MovieTitle", ((MovieItem) items[e.Position]).title);
					movieActivity.PutExtra("MovieID", ((MovieItem) items[e.Position]).id);
					StartActivity(movieActivity);
				}
			};
		}
	}

}

