using ChatAppDayataWoogue.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChatAppDayataWoogue.DataTemplates
{
    public class ConversationTemplateSelector : DataTemplateSelector
    {
        public DataTemplate RightSideTemplate { get; set; }
        public DataTemplate LeftSideTemplate { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return string.Equals(((Message)item).Side, "left") ? LeftSideTemplate : RightSideTemplate;
        }
    }
}
