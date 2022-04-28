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
    public class ConversationPageViewModel : INotifyPropertyChanged
    {
        public string MessageText { get; set; }
        public ICommand AddMessageCommand => new Command(AddMessage);
        private ObservableCollection<Message> _Messages;
        public ObservableCollection<Message> Messages
        {
            get => _Messages;
            set { _Messages = value; OnPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public ConversationPageViewModel()
        {
            PopulateData();
        }

        private void PopulateData()
        {
            Messages = new ObservableCollection<Message>
            {
                new Message { Text = "Text 2 adslfadlfsdlfkasldfkmasdfkmsalfmsadlfkmsadpfmpsdafmpdsmfp     asdpfmsadf", Alignment = HORIZONTAL_TEXTALIGNMENT_START, HorizontalOptions=HORIZONTAL_START, BgColor=BGCOLOR_SECONDARY_USER},
                new Message { Text = "Text 3 asdffffffffffffffffffffffffffffffffff asdf sadf asdf asd fasd fsd fasdf asdf asdf as fsad fasd fs fas  sadf sd", Alignment = HORIZONTAL_TEXTALIGNMENT_END, HorizontalOptions=HORIZONTAL_END, BgColor=BGCOLOR_PRIMARY_USER }
                //new Message { Text = "Text 4", Alignment = HORIZONTAL_TEXTALIGNMENT_START, HorizontalOptions=HORIZONTAL_START, BgColor=BGCOLOR_SECONDARY_USER },
                //new Message { Text = "Text 2 adslfadlfsdlfkasldfkmasdfkmsalfmsadlfkmsadpfmpsdafmpdsmfp     asdpfmsadf", Alignment = HORIZONTAL_TEXTALIGNMENT_START, HorizontalOptions=HORIZONTAL_START, BgColor=BGCOLOR_SECONDARY_USER},
                //new Message { Text = "Text 3 asdffffffffffffffffffffffffffffffffff asdf sadf asdf asd fasd fsd fasdf asdf asdf as fsad fasd fs fas  sadf sd", Alignment = HORIZONTAL_TEXTALIGNMENT_END, HorizontalOptions=HORIZONTAL_END, BgColor=BGCOLOR_PRIMARY_USER },
                //new Message { Text = "Text 4", Alignment = HORIZONTAL_TEXTALIGNMENT_START, HorizontalOptions=HORIZONTAL_START, BgColor=BGCOLOR_SECONDARY_USER },
                //new Message { Text = "Text 2 adslfadlfsdlfkasldfkmasdfkmsalfmsadlfkmsadpfmpsdafmpdsmfp     asdpfmsadf", Alignment = HORIZONTAL_TEXTALIGNMENT_START, HorizontalOptions=HORIZONTAL_START, BgColor=BGCOLOR_SECONDARY_USER},
                //new Message { Text = "Text 3 asdffffffffffffffffffffffffffffffffff asdf sadf asdf asd fasd fsd fasdf asdf asdf as fsad fasd fs fas  sadf sd", Alignment = HORIZONTAL_TEXTALIGNMENT_END, HorizontalOptions=HORIZONTAL_END, BgColor=BGCOLOR_PRIMARY_USER },
                //new Message { Text = "Text 4", Alignment = HORIZONTAL_TEXTALIGNMENT_START, HorizontalOptions=HORIZONTAL_START, BgColor=BGCOLOR_SECONDARY_USER },
                //new Message { Text = "Text 2 adslfadlfsdlfkasldfkmasdfkmsalfmsadlfkmsadpfmpsdafmpdsmfp     asdpfmsadf", Alignment = HORIZONTAL_TEXTALIGNMENT_START, HorizontalOptions=HORIZONTAL_START, BgColor=BGCOLOR_SECONDARY_USER},
                //new Message { Text = "Text 3 asdffffffffffffffffffffffffffffffffff asdf sadf asdf asd fasd fsd fasdf asdf asdf as fsad fasd fs fas  sadf sd", Alignment = HORIZONTAL_TEXTALIGNMENT_END, HorizontalOptions=HORIZONTAL_END, BgColor=BGCOLOR_PRIMARY_USER },
                //new Message { Text = "Text 2 adslfadlfsdlfkasldfkmasdfkmsalfmsadlfkmsadpfmpsdafmpdsmfp     asdpfmsadf", Alignment = HORIZONTAL_TEXTALIGNMENT_START, HorizontalOptions=HORIZONTAL_START, BgColor=BGCOLOR_SECONDARY_USER},
                //new Message { Text = "Text 3 asdffffffffffffffffffffffffffffffffff asdf sadf asdf asd fasd fsd fasdf asdf asdf as fsad fasd fs fas  sadf sd", Alignment = HORIZONTAL_TEXTALIGNMENT_END, HorizontalOptions=HORIZONTAL_END, BgColor=BGCOLOR_PRIMARY_USER },
                //new Message { Text = "Text 4", Alignment = HORIZONTAL_TEXTALIGNMENT_START, HorizontalOptions=HORIZONTAL_START, BgColor=BGCOLOR_SECONDARY_USER },
                //new Message { Text = "Text 2 adslfadlfsdlfkasldfkmasdfkmsalfmsadlfkmsadpfmpsdafmpdsmfp     asdpfmsadf", Alignment = HORIZONTAL_TEXTALIGNMENT_START, HorizontalOptions=HORIZONTAL_START, BgColor=BGCOLOR_SECONDARY_USER},
                //new Message { Text = "Text 3 asdffffffffffffffffffffffffffffffffff asdf sadf asdf asd fasd fsd fasdf asdf asdf as fsad fasd fs fas  sadf sd", Alignment = HORIZONTAL_TEXTALIGNMENT_END, HorizontalOptions=HORIZONTAL_END, BgColor=BGCOLOR_PRIMARY_USER },
            };
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddMessage()
        {
            Messages.Add(new Message { 
                Text = MessageText, 
                Alignment = HORIZONTAL_TEXTALIGNMENT_END, 
                HorizontalOptions=HORIZONTAL_END,
                BgColor=BGCOLOR_PRIMARY_USER
            });
        }
    }
}
