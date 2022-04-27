using System;
using System.Collections.Generic;
using System.Text;
using static ChatAppDayataWoogue.Constants;
using Xamarin.Forms;

namespace ChatAppDayataWoogue.CustomRenderers
{
    public class CustomButton : Button
    {
        public static readonly BindableProperty PaddingTopProperty = BindableProperty.Create(nameof(PaddingTop), typeof(int), typeof(CustomButton), DEFAULT_PADDING_VERTICAL);
        public int PaddingTop
        {
            get { return (int)GetValue(PaddingTopProperty); }
            set { SetValue(PaddingTopProperty, value); }
        }

        public static readonly BindableProperty PaddingBotProperty = BindableProperty.Create(nameof(PaddingBot), typeof(int), typeof(CustomButton), DEFAULT_PADDING_VERTICAL);
        public int PaddingBot
        {
            get { return (int)GetValue(PaddingBotProperty); }
            set { SetValue(PaddingBotProperty, value); }
        }

        public static readonly BindableProperty PaddingLeftProperty = BindableProperty.Create(nameof(PaddingLeft), typeof(int), typeof(CustomButton), DEFAULT_PADDING_HORIZONTAL);
        public int PaddingLeft
        {
            get { return (int)GetValue(PaddingLeftProperty); }
            set { SetValue(PaddingLeftProperty, value); }
        }

        public static readonly BindableProperty PaddingRightProperty = BindableProperty.Create(nameof(PaddingRight), typeof(int), typeof(CustomButton), DEFAULT_PADDING_HORIZONTAL);
        public int PaddingRight
        {
            get { return (int)GetValue(PaddingRightProperty); }
            set { SetValue(PaddingRightProperty, value); }
        }
    }
}
