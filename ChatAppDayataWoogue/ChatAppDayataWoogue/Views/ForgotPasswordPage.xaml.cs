using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ChatAppDayataWoogue.Constants;

namespace ChatAppDayataWoogue.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPasswordPage : ContentPage
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();
        }

        private async void SendResetPasswordEmail(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EntryEmail.Text))
            {
                await DisplayAlert("Error", "Please enter your email address", "Okay");
            }
            else
            {
                Loading.IsVisible = true;
                FirebaseAuthResponseModel res = new FirebaseAuthResponseModel();
                res = await DependencyService.Get<IFirebaseAuthService>().ResetPassword(EntryEmail.Text);

                if (res.Status == true)
                {
                    await DisplayAlert("Success", res.Response, "Okay");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", res.Response, "Okay");
                }
                Loading.IsVisible = false;
            }
        }

    }
}