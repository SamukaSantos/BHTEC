using Octokit;
using System.Threading.Tasks;

namespace Sample.Service
{
    public class GitService : IGitService
    {

        #region Methods

        public async Task<User> GetUserAsync(string userName)
        {
            var client = new GitHubClient(new ProductHeaderValue("MeetupChallenge"));
            return await client.User.Get(userName);
        } 
        #endregion

    }
}
