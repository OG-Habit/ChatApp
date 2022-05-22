using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ChatAppDayataWoogue
{
    public class UserModel : INotifyPropertyChanged
    {
        string uid { get; set; }
        public string Uid { 
            get { return uid; }  
            set { uid = value; OnPropertyChanged(nameof(Uid)); } 
        }
        string email { get; set; }
        public string Email { 
            get { return email; }
            set { email = value; OnPropertyChanged(nameof(Email)); }
        }
        string name { get; set; }
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }
        /*
         * User Type
         * 0 - Email
         * 1 - Social Google
         * 2 - Social Facebook
         */
        int userType { get; set; }
        public int UserType
        {
            get { return userType; }
            set { userType = value; OnPropertyChanged(nameof(UserType)); }
        }
        List<string> contacts;
        public List<string> Contacts
        {
            get => contacts;
            set
            {
                contacts = value;
                OnPropertyChanged();
            }
        }
        DateTime createdAt { get; set; }
        public DateTime CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; OnPropertyChanged(nameof(CreatedAt)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName= "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
