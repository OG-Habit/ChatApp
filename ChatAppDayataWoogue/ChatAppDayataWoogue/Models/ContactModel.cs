using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppDayataWoogue.Models
{
    public class ContactModel : BaseModel
    {
        string id { get; set; }
        public string Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }

        string contactId { get; set; }
        public string ContactId
        {
            get { return contactId; }
            set { contactId = value; OnPropertyChanged(); }
        }

        string contactName { get; set; }
        public string ContactName
        {
            get { return contactName; }
            set { contactName = value; OnPropertyChanged(); }
        }

        string contactEmail { get; set; }
        public string ContactEmail
        {
            get { return contactEmail; }
            set { contactEmail = value; OnPropertyChanged(); }
        }

        DateTime createdAt { get; set; }
        public DateTime CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; OnPropertyChanged(); }
        }
    }
}
