using ChatAppDayataWoogue.Models;
using static ChatAppDayataWoogue.Constants;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChatAppDayataWoogue.ViewModels
{
    public class ConversationPageViewModel : BaseViewModel
    {
        public ICommand AddMessageCommand { get; }
        public ConversationPageViewModel()
        {
            Messages = new ObservableCollection<Message>();

            AddMessageCommand = new Command(AddMessage);

            PopulateData();
        }

        private void PopulateData()
        {
            Messages.Add(new Message { Text = "Text 1 adslfadlfsdlfkasldfkmasdfkmsalfmsadlfkmsadpfmpsdafmpdsmfp     asdpfmsadf", Side = "left" });
            Messages.Add(new Message { Text = "Text 2 adslfadlfsdlfkasldfkmasdfkmsalfmsadlfkmsadpfmpsdafmpdsmfp     asdpfmsadf", Side = "left" });
            Messages.Add(new Message { Text = "Text 3 adslfadlfsdlfkasldfkmasdfkmsalfmsadlfkmsadpfmpsdafmpdsmfp     asdpfmsadf", Side = "right" });
            Messages.Add(new Message { Text = "Text 4 adslfadlfsdlfkasldfkmasdfkmsalfmsadlfkmsadpfmpsdafmpdsmfp     asdpfmsadf", Side = "left" });
        }

        private void AddMessage()
        {
            Messages.Add(new Message { 
                Text = MessageText, 
                Side = "right"
            });
            MessageText = "";
        }

        #region Getters Setters
        private ObservableCollection<Message> _messages;
        public ObservableCollection<Message> Messages
        {
            get => _messages;
            set => SetProperty(ref _messages, value);
        }
        public string MessageText { get; set; }
        #endregion
    }
}
