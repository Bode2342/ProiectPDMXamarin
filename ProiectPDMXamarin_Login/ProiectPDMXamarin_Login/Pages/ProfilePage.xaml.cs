using ProiectPDMXamarin_Login.Models;
using ProiectPDMXamarin_Login.ViewModels;
using System;
using System.Collections.Generic;
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
        private UserViewModel userViewModel;
        public ProfilePage(User u)
        {
            InitializeComponent();

            userViewModel = new UserViewModel();
            BindingContext = userViewModel;
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

        }

        private static void updateMasterUI(User user)
        {
            MasterPage page = new MasterPage(user);
            page.NameLabel.Text = user.FirstName + " " + user.LastName;
            DateTime zeroTime = new DateTime(1, 1, 1);

            DateTime a = DateTime.Now;
            DateTime b = DateTime.Parse(user.Birthday);

            TimeSpan span = a.Subtract(b);

            int years = (zeroTime + span).Year - 1;
            page.UserInfo.Text = user.Gender + " - " + years + " years old";
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
            userViewModel.changeName("caca");
            userInformation.Text = user.FirstName + " - " + user.LastName + " - " + user.PhoneNumber + " - " + user.Gender + " - " + user.Birthday + " - " + user.EmailAddress;
            
        }
    }
}