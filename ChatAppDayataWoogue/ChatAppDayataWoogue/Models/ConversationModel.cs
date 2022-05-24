using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppDayataWoogue.Models
{
    public class ConversationModel : BaseModel
    {
        string id { get; set; }
        public string Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }

        string message { get; set; }
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged(); }
        }

        string converseeId { get; set; }
        public string ConverseeId
        {
            get { return converseeId; }
            set { converseeId = value; OnPropertyChanged(); }   
        }

        string createdAt { get; set; }
        public string CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; OnPropertyChanged(); } 
        }
    }
}
