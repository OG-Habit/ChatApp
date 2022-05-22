using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ChatAppDayataWoogue
{
    public class FirebaseAuthResponseModel : INotifyPropertyChanged
    {
        bool status { get; set; }
        public bool Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged(nameof(Status)); }
        }
        string response { get; set; }
        public string Response
        {
            get { return response; }
            set { response = value; OnPropertyChanged(nameof(Response)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
