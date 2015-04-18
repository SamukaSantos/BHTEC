using System.Net;
using System;
using Xamarin.Forms;


namespace Sample.Service
{
    public class GitService
    {
		public void User GetUser(string user)
		{
			WebRequest requestPic = WebRequest.Create(string.Format("https://api.github.com/users/{0}",user));
			object request;
			requestPic.BeginGetResponse (FeedDownloaded, request);
		}

		void FeedDownloaded (IAsyncResult result)
		{
			var request = result.AsyncState as HttpWebRequest;

			try {
				var response = request.EndGetResponse (result);
				//(response.GetResponseStream ()).re;
			//	Newtonsoft.Json.JsonConvert.DeserializeObject<User>(response.GetResponseStream());
		
			} catch (Exception e) {
				
			}
		}
    }
}
