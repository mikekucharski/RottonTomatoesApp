using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PortableAPI
{
	public class RTAPI
	{
		public static string getTopBoxOffice()
		{
			var result = string.Empty;
			result = "testing";
			var url = "http://api.rottentomatoes.com/api/public/v1.0/lists/movies/box_office.json?apikey=cmkxka9urm5ann33vayg38eg&limit=1";

			var httpReq = (HttpWebRequest)HttpWebRequest.Create (new Uri (url));

			httpReq.BeginGetResponse ((asyncResult) => {
				asyncResult.AsyncWaitHandle.WaitOne();
				var request = (HttpWebRequest)asyncResult.AsyncState;
				using (var response = (HttpWebResponse)request.  EndGetResponse (asyncResult))     {    
					asyncResult.AsyncWaitHandle.WaitOne();
					var rs = response.GetResponseStream ();
					result="OMG";
					//var jOb = (JObject)JObject.Load (rs);
					//JToken token = JObject.Parse(jOb);
					//String[] m = token.SelectToken().ToArray();
				}


			}, httpReq);


					//JObject json = JObject.Parse(result);
					//JArray jMovies = (JArray)json["movies"];
			return result;
		}

		public static string getOpeningThisWeek()
		{
			string stringData = "{}";
			return stringData;
		}
	}
}



