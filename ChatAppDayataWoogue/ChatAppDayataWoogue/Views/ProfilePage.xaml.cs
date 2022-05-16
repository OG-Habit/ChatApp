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
        DataClass dataClass = DataClass.GetInstance;
        public ProfilePage()
        {
            InitializeComponent();
            LabelUsername.Text = dataClass.LoggedInUser.Name;
            LabelEmail.Text = dataClass.LoggedInUser.Email;
        }

        private async void Signout(object sender, EventArgs e)
        {
            FirebaseAuthResponseModel res = new FirebaseAuthResponseModel();
            res = DependencyService.Get<IFirebaseAuthService>().SignOut();

            if(res.Status == true)
            {
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
            else
            {
                await DisplayAlert("Error", res.Response, "Okay");
            }
        }
    }
}