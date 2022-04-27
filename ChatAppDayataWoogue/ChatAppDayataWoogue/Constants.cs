using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChatAppDayataWoogue
{
    internal static class Constants
    {
        public static readonly object DEFAULT_PADDING_VERTICAL = 20;
        public static readonly object DEFAULT_PADDING_HORIZONTAL = 30;
        public static readonly TextAlignment HORIZONTAL_TEXTALIGNMENT_START = TextAlignment.Start;
        public static readonly TextAlignment HORIZONTAL_TEXTALIGNMENT_END = TextAlignment.End;
        public static readonly LayoutOptions HORIZONTAL_START = LayoutOptions.Start;
        public static readonly LayoutOptions HORIZONTAL_END = LayoutOptions.End;
        public static readonly string BGCOLOR_PRIMARY_USER = "#90ee90";
        public static readonly string BGCOLOR_SECONDARY_USER = "#156DC2";
        public static readonly string MSG_EMPTY_CONVO = "You can now start a conversation with this person.";
    }
}
