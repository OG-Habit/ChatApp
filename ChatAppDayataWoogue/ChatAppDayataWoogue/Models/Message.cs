using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChatAppDayataWoogue.Models
{
    public class Message
    {
        public string Text { get; set; }
        public TextAlignment Alignment { get; set; }
        public LayoutOptions HorizontalOptions { get; set; }
        public string BgColor { get; set; }
    }
}
