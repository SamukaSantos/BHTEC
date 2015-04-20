using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sample.ViewModel.Interface
{
    public interface IDetailViewModel
    {
        ICommand TakePhotoCommand { get; }
        ICommand BackCommand { get; }
        Octokit.User User { get; set; }
    }
}
