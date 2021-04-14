using System;
using System.Collections.Generic;
using System.Text;

namespace ProiectPDMXamarin_Login.ViewModels
{
    class UserViewModel : INotifyPropertyChanged
    {
        string userName;
        string userDetails;
        public event PropertyChangedEventHandler PropertyChanged;
        public string UserName
        {
            private set { SetProperty(ref userName, value); }
            get { return userName; }
        }

        public void changeName(string name)
        {
            UserName = name;
        }

        public string UserDetails
        {
            private set { SetProperty(ref userDetails, value); }
            get { return userDetails; }
        }

        public void changeInfo(string details)
        {
            UserDetails = details;
        }

        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }

}
}
