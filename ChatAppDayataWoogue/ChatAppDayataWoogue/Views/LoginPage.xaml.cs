using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ChatAppDayataWoogue.Constants;
using ChatAppDayataWoogue.CustomViews;
using Plugin.CloudFirestore;

namespace ChatAppDayataWoogue.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        DataClass dataClass = DataClass.GetInstance;
        public LoginPage()
        {
            InitializeComponent();

        }

        private void TogglePasswordVisibility(object sender, EventArgs e)
        {
            bool IsPassword = EntryPassword.IsPassword;
            EntryPassword.IsPassword = !IsPassword;
            BtnTogglePasswordVisibility.Text = IsPassword ? "Hide" : "Show";
        }

        async void GoToSignup(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync($"{nameof(SignupPage)}");
            await Navigation.PushModalAsync(new SignupPage());
        }

        async void GoToForgotPassword(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync($"{nameof(SignupPage)}");
            await Navigation.PushAsync(new ForgotPasswordPage());
        }

        private async void Login(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(EntryEmail.Text) && string.IsNullOrEmpty(EntryPassword.Text))
            {
                bool retryBool = await DisplayAlert("Error", "Missing field/s. Retry?", "Yes", "No");
                if(retryBool)
                    RestartEntries();
            }
            else
            {
                Loading.IsVisible = true;
                FirebaseAuthResponseModel res = new FirebaseAuthResponseModel();
                res = await DependencyService.Get<IFirebaseAuthService>().LoginWithEmailPassword(EntryEmail.Text, EntryPassword.Text);

                if(res.Status == true)
                {
                    //await Shell.Current.GoToAsync($"//{nameof(ChatPage)}");
                    App.Current.MainPage = new NavigationPage(new TabPage());
                } 
                else
                {
                    bool retryBool = await DisplayAlert("Error", $"{res.Response} Retry?", "Yes", "No");
                    if (retryBool)
                        RestartEntries();
                }
                Loading.IsVisible = false;
            }
            //if(App.Current.Properties[KEY_EMAIL].ToString().Equals(EntryEmail.Text) &&
            //    App.Current.Properties[KEY_PASSWORD].ToString().Equals(EntryPassword.Text))
            //{
            //    await Shell.Current.GoToAsync($"//{nameof(ChatPage)}");
            //} 
        }

        #region Modular Functions
        void RestartEntries()
        {
            EntryEmail.Text = EntryPassword.Text = string.Empty;
            EntryEmail.Focus();
        }
        #endregion

        protected override void OnAppearing()
        {
            base.OnAppearing();
            EntryEmail.Text = EntryPassword.Text = string.Empty;
        }
        protected override void OnDisappearing()
        {
            base.OnAppearing();
            EntryEmail.Text = EntryPassword.Text = string.Empty;
        }
    }
}