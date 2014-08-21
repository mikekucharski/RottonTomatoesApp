using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace RottonTomatoesApp
{
	public static class StringHelper
	{
		public static string runtimeConverter(int totalMinutes){
			int hours = totalMinutes / 60;
			int minutes = totalMinutes % 60;
			return hours + " hr. "+ minutes +" min.";
		}

		public static string dateFormatter(string inDate){
			int year = Int32.Parse (inDate.Substring(0,4));
			int month = Int32.Parse (inDate.Substring(5,2));
			int day = Int32.Parse (inDate.Substring(8,2));

			string[] monthStrings = {"January", "February", "March", "April", "May",
					"June", "July", "August", "September", "October", "November", "December"};
			string monthString = monthStrings[month-1];

			return monthString + " " + day + ", " + year;
		}

		public static List<MovieItem> getMoviesFromJson(string json){
			return null;
		}
	}
}

