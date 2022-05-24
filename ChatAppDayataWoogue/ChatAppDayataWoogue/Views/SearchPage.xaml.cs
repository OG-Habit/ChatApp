using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ChatAppDayataWoogue.CustomViews;
using ChatAppDayataWoogue.Models;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Plugin.CloudFirestore;

namespace ChatAppDayataWoogue.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        private ObservableCollection<UserModel> Result = new ObservableCollection<UserModel>();
        DataClass dataClass = DataClass.GetInstance;

        public SearchPage()
        {
            InitializeComponent();
        }

        public SearchPage(string SearchEmail)
        {
            InitializeComponent();
            AddResult(SearchEmail);
        }

        async void AddResult(string SearchEmail)
        {
            Loading.IsVisible = true;
            var documents = await CrossCloudFirestore.Current.Instance
                                .GetCollection("users")
                                .WhereEqualsTo("Email", SearchEmail)
                                .GetDocumentsAsync();
            foreach (var documentChange in documents.DocumentChanges)
            {
                var json = JsonConvert.SerializeObject(documentChange.Document.Data);
                var obj = JsonConvert.DeserializeObject<UserModel>(json);
                Result.Add(obj);
            }
            ResultsList.ItemsSource = Result;
            Loading.IsVisible = false;
            ResultsList.IsVisible = true;
            if (Result.Count == 0)
            {
                await DisplayAlert("Error", "User not found", "Okay");
                await Navigation.PopModalAsync(true);
            }
        }

        async void AddContact(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as UserModel; //tapped contact's user details
            //check if isOwner
            if (String.Equals(dataClass.LoggedInUser.Uid, item.Uid))
            {
                await DisplayAlert("Failed", "Cannot add yourself as a contact.", "Okay");
                await Navigation.PopModalAsync(true);
            }
            //check if connection already established
            else if (dataClass.LoggedInUser.Contacts != null && dataClass.LoggedInUser.Contacts.Contains(item.Uid))
            {
                await DisplayAlert("Failed", "You both already have a connection.", "Okay");
                await Navigation.PopModalAsync(true);
            }
            //add the contact
            else
            {
                bool confirm = await DisplayAlert("Add contact", $"Would you like to add {item.Name}?", "Yes", "No");
                if (confirm)
                {
                    Loading.IsVisible = true;
                    ContactModel NewContact = new ContactModel()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ContactId = new String[] { dataClass.LoggedInUser.Uid, item.Uid },
                        ContactName = new String[] { dataClass.LoggedInUser.Name, item.Name },
                        ContactEmail = new String[] { dataClass.LoggedInUser.Email, item.Email },
                        CreatedAt = DateTime.UtcNow.ToString("u")
                    };
                    //new contact item
                    await CrossCloudFirestore.Current.Instance
                                    .GetCollection("contacts")
                                    .GetDocument(NewContact.Id)
                                    .SetDataAsync(NewContact);
                    //update owner's contact list to add tapped person's contact
                    if (dataClass.LoggedInUser.Contacts == null)
                        dataClass.LoggedInUser.Contacts = new List<string>();
                    dataClass.LoggedInUser.Contacts.Add(item.Uid);
                    await CrossCloudFirestore.Current.Instance
                                    .GetCollection("users")
                                    .GetDocument(dataClass.LoggedInUser.Uid)
                                    .UpdateDataAsync(new { Contacts = dataClass.LoggedInUser.Contacts });
                    //update tapped person's contact list to add owner's contact
                    if (item.Contacts == null)
                        item.Contacts = new List<string>();
                    item.Contacts.Add(dataClass.LoggedInUser.Uid);
                    await CrossCloudFirestore.Current.Instance
                                    .GetCollection("users")
                                    .GetDocument(item.Uid)
                                    .UpdateDataAsync(new { Contacts = item.Contacts });
                    Loading.IsVisible = false;
                    await DisplayAlert("Success", "Contact added!", "Okay");
                    await Navigation.PopModalAsync(true);
                }
            }
        }

        async void ExitPage(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(true);
        }
    }
}