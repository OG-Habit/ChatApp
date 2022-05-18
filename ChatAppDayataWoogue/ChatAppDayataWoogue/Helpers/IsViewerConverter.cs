using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Text;
using System.Globalization;
using ChatAppDayataWoogue.Models;

namespace ChatAppDayataWoogue
{
    public class IsViewerConverter : IValueConverter
    {
        DataClass dataClass = DataClass.GetInstance;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        { 
            bool retVal = false;

            if(value != null)
            {
                ConversationModel conversation = value as ConversationModel;

                if (conversation.ConverseeId.Equals(dataClass.LoggedInUser.Uid))
                    retVal = true;
            }

            return retVal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
