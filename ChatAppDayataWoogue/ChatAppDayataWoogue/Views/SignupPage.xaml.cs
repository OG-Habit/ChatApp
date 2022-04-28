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
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
        }
        
        private void TogglePasswordVisibility(object sender, EventArgs e)
        {
            Button b = ((Button)sender);
            AbsoluteLayout ab = (AbsoluteLayout)b.Parent;
            Entry en = (Entry)ab.Children[0];
            bool IsPassword = en.IsPassword;
            en.IsPassword = !IsPassword;
            b.Text = IsPassword ? "Hide" : "Show";
        }

        async void GoToLoginPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
        
        private async void SignUp(object sender, EventArgs e)
        {
            if(ArePassowrdsMatched())
            {
                App.Current.Properties[KEY_EMAIL] = EntryEmail.Text;
                App.Current.Properties[KEY_PASSWORD] = EntryPassword.Text;
                App.Current.Properties[KEY_USERNAME] = EntryUsername.Text;
                await Application.Current.SavePropertiesAsync();
                await DisplayAlert("Success", "You have successfully create an account", "Continue");
                App.Current.MainPage = new NavigationPage(new LoginPage());
            }
        }

        private bool ArePassowrdsMatched()
        {
            return EntryPassword.Text.Equals(EntryConfirmPassword.Text);
        }
    }
}