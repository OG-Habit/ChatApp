using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ChatAppDayataWoogue
{
    public class UserModel : INotifyPropertyChanged
    {
        string _Uid { get; set; }
        public string Uid { 
            get { return _Uid; }  
            set { _Uid = value; OnPropertyChanged(nameof(Uid)); } 
        }
        string _Email { get; set; }
        public string Email { 
            get { return _Email; }
            set { _Email = value; OnPropertyChanged(nameof(Email)); }
        }
        string _Name { get; set; }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; OnPropertyChanged(nameof(Name)); }
        }
        /*
         * User Type
         * 0 - Email
         * 1 - Social Google
         * 2 - Social Facebook
         */
        int _UserType { get; set; }
        public int UserType
        {
            get { return _UserType; }
            set { _UserType = value; OnPropertyChanged(nameof(UserType)); }
        }
        DateTime _CreatedAt { get; set; }
        public DateTime CreatedAt
        {
            get { return _CreatedAt; }
            set { _CreatedAt = value; OnPropertyChanged(nameof(CreatedAt)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName= "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
