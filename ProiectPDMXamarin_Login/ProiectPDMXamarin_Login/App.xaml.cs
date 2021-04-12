using ProiectPDMXamarin_Login.Models;
using System.Collections.Generic;
using System.Reflection;
using Windows.ApplicationModel.Activation;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;


namespace ProiectPDMXamarin_Login
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new ProiectPDMXamarin_Login.Pages.LoginPage();
            User user = new User();
            user.FirstName = "Simona";
            user.LastName = "Pascal";
            user.Birthday = "1998-03-26";
            user.Gender = "Female";
            user.PhoneNumber = "0828292922";
            user.Password = "bau bau";
            user.EmailAddress = "simo@gmail.com";
            MainPage = new ProiectPDMXamarin_Login.Pages.MasterPage(user);
        
        }

        protected override void OnStart()
        {
            // Handle when your app starts  
        }
        protected override void OnSleep()
        {
            // Handle when your app sleeps  
        }
        protected override void OnResume()
        {
            // Handle when your app resumes  
        }

          
    }
}