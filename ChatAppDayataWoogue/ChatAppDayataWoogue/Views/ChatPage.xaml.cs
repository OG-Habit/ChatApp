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
    public partial class ChatPage : ContentPage
    {
        private ObservableCollection<ContactModel> ContactList = new ObservableCollection<ContactModel>();
        DataClass dataClass = DataClass.GetInstance;

        public ChatPage()
        {
            InitializeComponent();
            CrossCloudFirestore.Current.Instance
                .GetCollection("contacts")
                .WhereArrayContains("ContactId", dataClass.LoggedInUser.Uid)
                .AddSnapshotListener((snapshot, error) =>
                {
                    Loading.IsVisible = true;
                    if (snapshot != null)
                    {
                        foreach (var documentChange in snapshot.DocumentChanges)
                        {
                            var json = JsonConvert.SerializeObject(documentChange.Document.Data);
                            var obj = JsonConvert.DeserializeObject<ContactModel>(json);
                            switch (documentChange.Type)
                            {
                                case DocumentChangeType.Added:
                                    ContactList.Add(obj);
                                    break;
                                case DocumentChangeType.Modified:
                                    if (ContactList.Where(c => c.Id == obj.Id).Any())
                                    {
                                        var item = ContactList.Where(c => c.Id == obj.Id).FirstOrDefault();
                                        item = obj;
                                    }
                                    break;
                                case DocumentChangeType.Removed:
                                    if (ContactList.Where(c => c.Id == obj.Id).Any())
                                    {
                                        var item = ContactList.Where(c => c.Id == obj.Id).FirstOrDefault();
                                        ContactList.Remove(item);
                                    }
                                    break;
                            }
                        }
                    }
                    ContactsList.ItemsSource = ContactList;
                    emptyListLabel.IsVisible = ContactList.Count == 0;
                    ContactsList.IsVisible = !(ContactList.Count == 0);
                    Loading.IsVisible = false;
                });
        }

        async void GoToConversation(object sender, ItemTappedEventArgs e)
        {
            //await Shell.Current.GoToAsync($"//{nameof(TabPage)}");
            var item = e.Item as ContactModel;
            await Navigation.PushAsync(new ConversationPage(item), true);
        }

        async void GoToSearch(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync($"//{nameof(TabPage)}");
            if (String.IsNullOrEmpty(ContactEntry.Text))
            {
                await DisplayAlert("Error", "Please enter the email address of the contact person you wish to search for.", "Okay");
            }
            else
            {
                await Navigation.PushModalAsync(new SearchPage(ContactEntry.Text), true);
            }
            
        }

        private void ToogleClearButton(object sender, EventArgs e)
        {
            ClearButton.IsVisible = !String.IsNullOrEmpty(ContactEntry.Text);
        }

        private void ClearEntry(object sender, EventArgs e)
        {
            ContactEntry.Text = "";
            ClearButton.IsVisible = false;
        }
    }
}