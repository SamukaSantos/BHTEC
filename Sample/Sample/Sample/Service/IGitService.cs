using Octokit;
using System.Threading.Tasks;

namespace Sample.Service
{
    public interface IGitService
    {
        Task<User> GetUserAsync(string userName);
    }
}
