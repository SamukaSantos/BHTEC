
using Sample.Service;
using Sample.WinPhone.Service;
using Xamarin.Forms;
using Microsoft.Phone.Tasks;
using System;
using System.Windows;

[assembly: Dependency(typeof(Camera))]
namespace Sample.WinPhone.Service
{
    public class Camera : IWP8MediaPicker
    {

        #region Properties
        public Action<System.IO.Stream, string> Result { get; set; }
        #endregion

        #region Constructor
        public void Show()
        {
            var cameraCaptureTask = new CameraCaptureTask();
            cameraCaptureTask.Completed += new EventHandler<PhotoResult>(cameraCaptureTask_Completed);

            Result = (c , d) => { };

            cameraCaptureTask.Show();
        } 
        #endregion

        #region Handlers

        void cameraCaptureTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                Result(e.ChosenPhoto, e.OriginalFileName);

                

                //Code to display the photo on the page in an image control named myImage.
                //System.Windows.Media.Imaging.BitmapImage bmp = new System.Windows.Media.Imaging.BitmapImage();
                //bmp.SetSource(e.ChosenPhoto);
                //myImage.Source = bmp;
            }
        } 
        #endregion

        
    }
}
