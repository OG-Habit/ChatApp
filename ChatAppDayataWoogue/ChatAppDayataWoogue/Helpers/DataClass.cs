using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static ChatAppDayataWoogue.Constants;
using System.Text;
using ChatAppDayataWoogue;
using System.Linq;
using Newtonsoft.Json;

namespace ChatAppDayataWoogue
{
    public class DataClass : INotifyPropertyChanged
    {
        static DataClass dataClass;
        public static DataClass GetInstance
        {
            get
            {
                if(dataClass == null)
                {
                    dataClass = new DataClass();
                }
                return dataClass;
            }
        }
        bool isSignedIn { get; set; }
        public bool IsSignedIn
        {
            set
            {
                isSignedIn = value;
                App.Current.Properties[KEY_ISSIGNEDIN] = isSignedIn;
                App.Current.SavePropertiesAsync();
                OnPropertyChanged();
            }
            get
            {
                if(App.Current.Properties.ContainsKey(KEY_ISSIGNEDIN)) 
                {
                    isSignedIn = Convert.ToBoolean(App.Current.Properties[KEY_ISSIGNEDIN]);
                }
                return isSignedIn;
            }
        }
        UserModel loggedInUser { get; set; }
        public UserModel LoggedInUser
        {
            set
            {
                loggedInUser = value;
                App.Current.Properties[KEY_LOGGEDIN] = JsonConvert.SerializeObject(loggedInUser);
                App.Current.SavePropertiesAsync();
                OnPropertyChanged();
            }
            get
            {
                if(loggedInUser == null && App.Current.Properties.ContainsKey(KEY_LOGGEDIN))
                {
                    loggedInUser = JsonConvert.DeserializeObject<UserModel>(App.Current.Properties[KEY_LOGGEDIN].ToString());
                }
                return loggedInUser;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void  OnPropertyChanged([CallerMemberName] string propertyChanged = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyChanged));
        }
    }
}
