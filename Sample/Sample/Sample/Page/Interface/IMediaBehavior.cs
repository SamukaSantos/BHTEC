
using System.Threading.Tasks;
using Xamarin.Forms.Labs.Services.Media;

namespace Sample.Page.Interface
{
    public interface IMediaBehavior
    {
        void Select();
        void Send(string email);
    }
}
