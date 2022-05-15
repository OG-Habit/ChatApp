using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ChatAppDayataWoogue.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetProperty<T>(ref T store, T value,
            [CallerMemberName] string propertyName = "") 
        {
            if(EqualityComparer<T>.Default.Equals(value, store))
                return false;

            store = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
