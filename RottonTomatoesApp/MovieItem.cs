using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using System.Net;
using System.IO;
using Android.Graphics;
using Android.Graphics.Drawables;

[assembly: UsesPermission(Android.Manifest.Permission.Internet)]
namespace RottonTomatoesApp
{

	public class MovieItem : Item
	{
		public string id, title, critics_rating, mpaa_rating, date, imagePath;
		public string[] cast;
		public int score, runtime;

		public MovieItem (string id, string title, int score, string critics_rating, string[] cast,
			              string mpaa_rating, int runtime, string date, string imagePath)
		{
			this.id = id;
			this.title = title;
			this.score = score;
			this.critics_rating = critics_rating;
			this.cast = cast;
			this.mpaa_rating = mpaa_rating;
			this.runtime = runtime;
			this.date = date;
			this.imagePath = imagePath;
		}

		int Item.getViewType(){
			return 1;
		}
		View Item.getView(LayoutInflater inflater, View convertView){
			var view = convertView;
			if (view == null) // no view to re-use
				view = inflater.Inflate(Resource.Layout.ListItemMovie, null);
			
			view.FindViewById<TextView> (Resource.Id.MovieTitle).Text = title;
			view.FindViewById<TextView> (Resource.Id.MovieScore).Text = score + "%";
			view.FindViewById<TextView> (Resource.Id.MovieCast).Text = cast[0] + ", " + cast[1];
			view.FindViewById<TextView> (Resource.Id.MovieRating).Text = mpaa_rating + ", ";
			view.FindViewById<TextView> (Resource.Id.MovieTime).Text = StringHelper.runtimeConverter(runtime);
			view.FindViewById<TextView> (Resource.Id.MovieDate).Text = StringHelper.dateFormatter(date);
			int tomatoImg = (critics_rating == "Certified Fresh") ? Resource.Drawable.good_rating : Resource.Drawable.rotton_rating;
			view.FindViewById<ImageView> (Resource.Id.MovieTomato).SetImageResource(tomatoImg);
	
			var webClient = new WebClient ();
			var imageBytes = webClient.DownloadData(imagePath);
			Bitmap imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);

			//ImageView viewer = view.FindViewById<ImageView> (Resource.Id.MovieImage);
			//Drawable b = viewer.Drawable;
			//Drawable d = new BitmapDrawable (imageBitmap);
			//view.FindViewById<ImageView> (Resource.Id.MovieImage).SetImageDrawable (b);
			//Bitmap a = Bitmap.CreateScaledBitmap (imageBitmap, 500, 500, true);

			view.FindViewById<ImageView> (Resource.Id.MovieImage).SetImageBitmap (imageBitmap);
			return view;
		}
	}
}

