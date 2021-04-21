using ProiectPDMXamarin.Models;
using ProiectPDMXamarin.Pages;
using Xamarin.Forms;
namespace ProiectPDMXamarin_Login
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            User user = new User();
            user.FirstName = "Simona";
            user.LastName = "Pascal";
            user.Birthday = "1998-03-26";
            user.Gender = "Female";
            user.PhoneNumber = "0828292922";
            user.Password = "bau bau";
            user.EmailAddress = "simo@gmail.com";
            MainPage = new NavigationPage(new MasterPage(user));
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