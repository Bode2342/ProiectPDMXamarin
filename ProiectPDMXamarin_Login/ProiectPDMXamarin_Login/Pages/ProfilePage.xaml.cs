using ProiectPDMXamarin_Login.Models;
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
        User user;
        DaoUser daoUser;
        public ProfilePage(User u)
        {
            InitializeComponent();

            user = u;
            daoUser = new DaoUser();
            daoUser.AddUser(user);
            updateUI(user);
            

        }

        void updateUI(User user)
        {
            FirstName.Text = user.FirstName;
            LastName.Text = user.LastName;
            EmailAddress.Text = user.EmailAddress;
            PhoneNumber.Text = user.PhoneNumber;
            DateTime date = DateTime.Parse(user.Birthday);
            Birthday.Date = date;
            Gender.SelectedItem = user.Gender;

        }

        private void Save_Button_Clicked(object sender, EventArgs e)
        {
            user.FirstName = FirstName.Text;
            user.LastName = LastName.Text;
            user.PhoneNumber = PhoneNumber.Text;
            user.Gender = Gender.SelectedItem.ToString();
            user.Birthday = Birthday.ToString();
            user.EmailAddress = EmailAddress.Text;
            daoUser.updateUser(user); 

        }

    
    }
}