using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChatAppDayataWoogue.Constants;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatAppDayataWoogue.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            LabelUsername.Text = App.Current.Properties[KEY_USERNAME].ToString();
            LabelEmail.Text = (string)App.Current.Properties[KEY_EMAIL];
        }

        private async void Signout(object sender, EventArgs e)
        {
            App.Current.Properties.Clear();
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}