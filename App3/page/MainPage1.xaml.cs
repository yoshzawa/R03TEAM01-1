using Xamarin.Forms;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App3.page

{
    public partial class MainPage1 : ContentPage
    {
        public MainPage1()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
             {
                 await CrossMedia.Current.Initialize();

                 if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                 {
                     await DisplayAlert("No Camera", ":( No camera available.", "OK");
                     return;
                 }

                 var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                 {
                     Directory = "Sample",
                     Name = "test.jpg"
                 });

                 if (file == null)
                     return;

                 await DisplayAlert("File Location", file.Path, "OK");

                 image.Source = ImageSource.FromStream(() =>
                 {
                     var stream = file.GetStream();
                     return stream;
                 });
             };
        }
    }
}
