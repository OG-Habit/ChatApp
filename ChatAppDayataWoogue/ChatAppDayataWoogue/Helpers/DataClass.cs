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
        bool _IsSignedIn { get; set; }
        public bool IsSignedIn
        {
            set
            {
                _IsSignedIn = value;
                App.Current.Properties[KEY_ISSIGNEDIN] = _IsSignedIn;
                App.Current.SavePropertiesAsync();
                OnPropertyChanged();
            }
            get
            {
                if(App.Current.Properties.ContainsKey(KEY_ISSIGNEDIN)) 
                {
                    _IsSignedIn = Convert.ToBoolean(App.Current.Properties[KEY_ISSIGNEDIN]);
                }
                return _IsSignedIn;
            }
        }
        UserModel _LoggedInUser { get; set; }
        public UserModel LoggedInUser
        {
            set
            {
                _LoggedInUser = value;
                App.Current.Properties[KEY_LOGGEDIN] = JsonConvert.SerializeObject(_LoggedInUser);
                App.Current.SavePropertiesAsync();
                OnPropertyChanged();
            }
            get
            {
                if(_LoggedInUser == null && App.Current.Properties.ContainsKey(KEY_LOGGEDIN))
                {
                    _LoggedInUser = JsonConvert.DeserializeObject<UserModel>(App.Current.Properties[KEY_LOGGEDIN].ToString());
                }
                return _LoggedInUser;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void  OnPropertyChanged([CallerMemberName] string propertyChanged = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyChanged));
        }
    }
}
