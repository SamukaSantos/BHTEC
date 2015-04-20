
using System;
namespace Sample.Service
{
    public interface IWP8MediaPicker
    {
        void Show();
        Action<System.IO.Stream, string> Result { get; set; }
    }
}
