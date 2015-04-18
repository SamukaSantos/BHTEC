using System.Net;
using System;
using Xamarin.Forms;
using Octokit;
using System.Threading.Tasks;


namespace Sample.Service
{
    public class GitService
    {


		public   Octokit.User GetUserAsync (string username)
		 {
	
		
			var client = new GitHubClient(new ProductHeaderValue("DesafioMeetup"));
			          

			return  client.User.Get(username).Result;


			           

		}

    }
}
