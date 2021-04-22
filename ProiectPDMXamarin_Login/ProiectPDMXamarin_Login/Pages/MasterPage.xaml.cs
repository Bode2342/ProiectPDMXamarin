﻿using ProiectPDMXamarin.Models;
using ProiectPDMXamarin.Services;
using ProiectPDMXamarin.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProiectPDMXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {
        public User user;
        MasterViewModel masterViewModel;
        DaoUser daoUser;
        public MasterPage(User user)
        {
            InitializeComponent();
            daoUser = new DaoUser();
            this.user = user;
            masterViewModel = new MasterViewModel(user);
            BindingContext = masterViewModel;
            navigationList.ItemsSource = masterViewModel.menu;

            Detail = new NavigationPage(new ProfilePage(user));
        }

        private void Item_Tapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                var item = e.Item as MenuItems;
                masterViewModel.UpdateUI(daoUser.searchUserById(user));
                switch (item.OptionName)
                {
                    case "Add a meal":
                        {
                            
                            Detail = new NavigationPage(new AdaugaMasa());
                            IsPresented = false;
                        }
                        break;
                    case "Profile":
                        {

                            Detail.Navigation.PushAsync(new ProfilePage(user));
                            IsPresented = false;
                        }
                        break;
                    case "Meals":
                        {

                            Detail.Navigation.PushAsync(new ListaMese());
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
}