using Microsoft.WindowsAzure.Storage;
using Plugin.Media;
using Plugin.Media.Abstractions;
using ProiectPDMXamarin_Login.Models;
using ProiectPDMXamarin_Login.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProiectPDMXamarin_Login.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        private User user;
        private DaoUser daoUser;
        private MediaFile mediaFile;
        public string URL { get; set; }
        public ProfilePage(User u)
        {
            InitializeComponent();

            user = u;
            daoUser = new DaoUser();
            daoUser.AddUser(user);
            updateUI(user);
            

        }

        private void updateUI(User user)
        {
            
            FirstName.Text = user.FirstName;
            LastName.Text = user.LastName;
            EmailAddress.Text = user.EmailAddress;
            PhoneNumber.Text = user.PhoneNumber;
            DateTime date = DateTime.Parse(user.Birthday);
            Birthday.Date = date;
            Gender.SelectedItem = user.Gender;
            if(user.ProfileImage != null)
            {
                Stream stream = new MemoryStream(user.ProfileImage);
                imageView.Source = ImageSource.FromStream(() => stream);
            }

        }



        private void Save_Button_Pressed(object sender, EventArgs e)
        {
            user.FirstName = FirstName.Text;
            user.LastName = LastName.Text;
            user.PhoneNumber = PhoneNumber.Text;
            user.Gender = Gender.SelectedItem.ToString();
            user.Birthday = Birthday.Date.ToString();
            user.EmailAddress = EmailAddress.Text;
            daoUser.updateUser(user);
            
            userInformation.Text = user.FirstName + " - " + user.LastName + " - " + user.PhoneNumber + " - " + user.Gender + " - " + user.Birthday + " - " + user.EmailAddress;
            
        }
        public byte[] imageToByteArray()
        {
            using (var memoryStream = new MemoryStream())
            {
                mediaFile.GetStream().CopyTo(memoryStream);
                mediaFile.Dispose();
                return memoryStream.ToArray();
            }

        }
        private async void SelectPictureBtn_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Error", "This is not support on your device.", "OK");
                return;
            }
            else
            {
                var mediaOption = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };
                mediaFile = await CrossMedia.Current.PickPhotoAsync();
                if(mediaFile != null)
                {
                    imageView.Source = ImageSource.FromStream(() => mediaFile.GetStream());
                    user.ProfileImage = imageToByteArray();
                    daoUser.saveProfileImage(user);
                }

            }
        }


        private async void TakePictureBtn_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":(No Camera available.)", "OK");
                return;
            }
            else
            {
                mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "myImage.jpg"
                });

                if(mediaFile != null)
                {
                    imageView.Source = ImageSource.FromStream(() => mediaFile.GetStream());
                    user.ProfileImage = imageToByteArray();
                    daoUser.saveProfileImage(user);
                }
                
                var mediaOption = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };
                
            }
        }


    }
}