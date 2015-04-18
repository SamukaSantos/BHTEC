using Octokit;
using System.Threading.Tasks;

namespace Sample.Service
{
    public class GitService
    {
        public Task<User> GetUserAsync (string username)
        {
            var client = new GitHubClient(new ProductHeaderValue("DesafioMeetup"));
            var user = client.User.Get(username);

            return user;
        }
    }
}
