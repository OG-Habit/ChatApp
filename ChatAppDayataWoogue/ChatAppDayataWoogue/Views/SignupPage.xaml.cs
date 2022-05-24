using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChatAppDayataWoogue.Constants;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ChatAppDayataWoogue.CustomViews;
using Plugin.CloudFirestore;

namespace ChatAppDayataWoogue.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : ContentPage
    {
        DataClass dataClass = DataClass.GetInstance;
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
            //await Shell.Current.GoToAsync($".."); 
            await Navigation.PopModalAsync(true);
        }
        
        private async void SignUp(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(EntryEmail.Text) || string.IsNullOrEmpty(EntryUsername.Text) ||
                string.IsNullOrEmpty(EntryPassword.Text) || string.IsNullOrEmpty(EntryConfirmPassword.Text))
            {
                await DisplayAlert("Error", "Missing field/s", "Okay");
            } 
            else
            {
                if (!ArePassowrdsMatched())
                {
                    await DisplayAlert("Error", "Passwords don't match.", "Okay");
                    EntryConfirmPassword.Text = string.Empty;
                    EntryConfirmPassword.Focus();
                    App.Current.Properties[KEY_EMAIL] = EntryEmail.Text;
                    App.Current.Properties[KEY_PASSWORD] = EntryPassword.Text;
                    App.Current.Properties[KEY_USERNAME] = EntryUsername.Text;
                    await Application.Current.SavePropertiesAsync();
                    //await DisplayAlert("Success", "You have successfully create an account", "Continue");
                    //await Shell.Current.GoToAsync("..");
                    //await Navigation.PopAsync();
                } else
                {
                    Loading.IsVisible = true;
                    FirebaseAuthResponseModel res = new FirebaseAuthResponseModel();
                    res = await DependencyService.Get<IFirebaseAuthService>().SignUpWithEmailPassword(EntryUsername.Text, EntryEmail.Text, EntryPassword.Text);

                    if(res.Status == true)
                    {
                        try
                        {
                            await CrossCloudFirestore.Current
                                .Instance
                                .GetCollection("users")
                                .GetDocument(dataClass.LoggedInUser.Uid)
                                .SetDataAsync(dataClass.LoggedInUser);
                            await DisplayAlert("Success", res.Response, "Okay");
                            //await Shell.Current.GoToAsync("..");
                            await Navigation.PopModalAsync(true);
                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Error", ex.Message, "Okay");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Error", res.Response, "Okay");
                    }
                    Loading.IsVisible = false;
                }
            }
        }

        private bool ArePassowrdsMatched()
        {
            return EntryPassword.Text.Equals(EntryConfirmPassword.Text);
        }
    }
}