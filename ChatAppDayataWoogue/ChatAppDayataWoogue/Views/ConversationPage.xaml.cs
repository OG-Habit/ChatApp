using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChatAppDayataWoogue.Constants;
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
    public partial class ConversationPage : ContentPage
    {
        ObservableCollection<ConversationModel> ConversationList = new ObservableCollection<ConversationModel>();
        ContactModel Person;
        DataClass dataClass = DataClass.GetInstance;
        public ConversationPage()
        {
            InitializeComponent();
        }

        public ConversationPage(ContactModel person)
        {
            InitializeComponent();
            Person = person;
            string name = String.Equals(Person.ContactName[0], dataClass.LoggedInUser.Name) ? Person.ContactName[1] : Person.ContactName[0];
            PersonName.Text = name;
            CrossCloudFirestore.Current.Instance
                .GetCollection("contacts")
                .GetDocument(Person.Id)
                .GetCollection("conversations")
                .OrderBy("CreatedAt", false)
                .AddSnapshotListener((snapshot, error) =>
                {
                    ConversationListView.ItemsSource = ConversationList;
                    if (snapshot != null)
                    {
                        foreach (var documentChange in snapshot.DocumentChanges)
                        {
                            var json = JsonConvert.SerializeObject(documentChange.Document.Data);
                            var obj = JsonConvert.DeserializeObject<ConversationModel>(json);
                            switch (documentChange.Type)
                            {
                                case DocumentChangeType.Added:
                                    ConversationList.Add(obj);
                                    break;
                                case DocumentChangeType.Modified:
                                    if (ConversationList.Where(c => c.Id == obj.Id).Any())
                                    {
                                        var item = ConversationList.Where(c => c.Id == obj.Id).FirstOrDefault();
                                        item = obj;
                                    }
                                    break;
                                case DocumentChangeType.Removed:
                                    if (ConversationList.Where(c => c.Id == obj.Id).Any())
                                    {
                                        var item = ConversationList.Where(c => c.Id == obj.Id).FirstOrDefault();
                                        ConversationList.Remove(item);
                                    }
                                    break;
                            }
                            var conv = ConversationListView.ItemsSource.Cast<object>().LastOrDefault();
                            ConversationListView.ScrollTo(conv, ScrollToPosition.End, false);
                        }
                    }
                    EmptyListLabel.IsVisible = ConversationList.Count == 0;
                    ConversationListView.IsVisible = !(ConversationList.Count == 0);
                });
        }

        private void ToggleSendButton(object sender, EventArgs e)
        {
            SendButton.IsEnabled = !(String.IsNullOrEmpty(EditorTextInput.Text));
        }
        async void SendMessage(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(EditorTextInput.Text))
            {
                await DisplayAlert("Error", "Please type your message", "Okay");
            }
            else
            {
                ConversationModel NewMessage = new ConversationModel()
                {
                    Id = Guid.NewGuid().ToString(),
                    ConverseeId = dataClass.LoggedInUser.Uid,
                    Message = EditorTextInput.Text,
                    CreatedAt = DateTime.UtcNow.ToString("u")
                };
                //new contact item
                await CrossCloudFirestore.Current.Instance
                                .GetCollection("contacts")
                                .GetDocument(Person.Id)
                                .GetCollection("conversations")
                                .GetDocument(NewMessage.Id)
                                .SetDataAsync(NewMessage);
                EditorTextInput.Text = String.Empty;
            }
        }
        async void ExitConversation(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync($"//{nameof(TabPage)}");
            await Navigation.PopAsync();
        }
    }
}