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

[assembly: UsesPermission(Android.Manifest.Permission.Internet)]
namespace RottonTomatoesApp
{

	public class MovieItem : Item
	{
		public String Heading;
		public String SubHeading;
		public String ImagePath;

		public MovieItem (String heading, String subHeading, String ImagePath)
		{
			this.Heading = heading;
			this.SubHeading = subHeading;
			this.ImagePath = ImagePath;
		}

		int Item.getViewType(){
			return 1;
		}
		View Item.getView(LayoutInflater inflater, View convertView){
			var view = convertView;
			if (view == null) // no view to re-use
				view = inflater.Inflate(Resource.Layout.ListItemMovie, null);
			
			//view.FindViewById<TextView>(Resource.Id.Text1).Text = Heading;
			//view.FindViewById<TextView>(Resource.Id.Text2).Text = SubHeading;

			var webClient = new WebClient ();
			var imageBytes = webClient.DownloadData(ImagePath);
			Bitmap imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);

			//view.FindViewById<ImageView> (Resource.Id.MovieImage).SetImageBitmap (imageBitmap);
			return view;
		}
	}
}

