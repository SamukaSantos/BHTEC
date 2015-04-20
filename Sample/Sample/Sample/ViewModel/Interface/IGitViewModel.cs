using Sample.Service;
using System;
using System.Windows.Input;

namespace Sample.ViewModel.Interface
{
    interface IGitViewModel
    {
        ICommand SearchCommand { get; }
        IGitService Service { get; set; }
        string UserName { get; set; }
    }
}
