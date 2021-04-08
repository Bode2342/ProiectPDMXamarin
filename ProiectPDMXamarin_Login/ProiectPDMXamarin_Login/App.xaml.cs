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
            MainPage = new ProiectPDMXamarin_Login.Pages.MasterPage();
        
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