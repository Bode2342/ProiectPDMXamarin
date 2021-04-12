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
    public partial class MasterPage : MasterDetailPage
    {
        List<MenuItems> menu;
        public User user;
        public MasterPage(User user)
        {

            InitializeComponent();
           // MasterPage.ListView.ItemSelected += ListView_ItemSelected;
           
            menu = new List<MenuItems>();

            menu.Add(new MenuItems { OptionName = "Recipes", IconName = "Images/recipes_icon.png" });
            menu.Add(new MenuItems { OptionName = "Add a meal", IconName = "Images/add_a_meal_icon.png" });
            menu.Add(new MenuItems { OptionName = "Meals", IconName = "Images/meals_icon.png" });
            menu.Add(new MenuItems { OptionName = "Profile", IconName = "Images/profile_icon.png" });
            menu.Add(new MenuItems { OptionName = "Body index", IconName = "Images/body_index_icon.png" });
            
            navigationList.ItemsSource = menu;
            this.user = user;
            Detail = new NavigationPage(new ProfilePage(user));
            updateUI(user);
        }

        void updateUI(User user)
        {
            
            NameLabel.Text = user.FirstName + " " + user.LastName;
            DateTime zeroTime = new DateTime(1, 1, 1);

            DateTime a = DateTime.Now;
            DateTime b = DateTime.Parse(user.Birthday);

            TimeSpan span = a - b;

            int years = (zeroTime + span).Year - 1;
            UserInfo.Text = user.Gender + " - " + years + " years old";     
        }



        private void Item_Tapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                var item = e.Item as MenuItems;
                updateUI(user);
                switch (item.OptionName)
                {
                    case "Recipes":
                        {
                            Detail = new NavigationPage(new RecipesPage());
                            IsPresented = false;
                        }
                        break;
                    case "Profile":
                        {
                            
                            Detail.Navigation.PushAsync(new ProfilePage(user));
                            IsPresented = false;
                        }
                        break;
                   
                }
            }
            catch (Exception ex)
            {

            }
        }
    }

    public class MenuItems
    {
        public string OptionName { get; set; }
        public string IconName { get; set; }
    }


}



