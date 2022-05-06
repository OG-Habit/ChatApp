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
        bool isSignedInValue { get; set; }
        public bool IsSignedIn
        {
            set
            {
                isSignedInValue = value;
                App.Current.Properties[KEY_ISSIGNEDIN] = isSignedInValue;
                App.Current.SavePropertiesAsync();
                OnPropertyChanged();
            }
            get
            {
                if(App.Current.Properties.ContainsKey(KEY_ISSIGNEDIN)) 
                {
                    isSignedInValue = Convert.ToBoolean(App.Current.Properties[KEY_ISSIGNEDIN]);
                }
                return isSignedInValue;
            }
        }
        UserModel loggedInUserValue { get; set; }
        public UserModel LoggedInUser
        {
            set
            {
                loggedInUserValue = value;
                App.Current.Properties[KEY_LOGGEDIN] = JsonConvert.SerializeObject(loggedInUserValue);
                App.Current.SavePropertiesAsync();
                OnPropertyChanged();
            }
            get
            {
                if(loggedInUserValue == null && App.Current.Properties.ContainsKey(KEY_LOGGEDIN))
                {
                    loggedInUserValue = JsonConvert.DeserializeObject<UserModel>(App.Current.Properties[KEY_LOGGEDIN].ToString());
                }
                return loggedInUserValue;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void  OnPropertyChanged([CallerMemberName] string propertyChanged = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyChanged));
        }
    }
}
