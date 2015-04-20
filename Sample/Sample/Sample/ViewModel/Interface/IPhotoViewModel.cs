using System;
using System.Windows.Input;

namespace Sample.ViewModel
{
    public interface IPhotoViewModel
    {
        ICommand SelectCommand { get; }
        ICommand SendCommand { get; }
    }
}
