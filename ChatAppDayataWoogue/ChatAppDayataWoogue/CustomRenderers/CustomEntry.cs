using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using static ChatAppDayataWoogue.Constants;

namespace ChatAppDayataWoogue.CustomRenderers
{
    public class CustomEntry : Entry
    {
        public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(nameof(BorderWidth), typeof(int), typeof(CustomEntry));
        public int BorderWidth
        {
            get { return (int)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

        public static readonly BindableProperty BorderRadiusProperty = BindableProperty.Create(nameof(BorderRadius), typeof(float), typeof(CustomEntry));
        public float BorderRadius
        {
            get { return (float)GetValue(BorderRadiusProperty); }
            set { SetValue(BorderRadiusProperty, value); }
        }

        public static readonly BindableProperty PaddingTopProperty = BindableProperty.Create(nameof(PaddingTop), typeof(int), typeof(CustomEntry), DEFAULT_PADDING_VERTICAL);
        public int PaddingTop
        {
            get { return (int)GetValue(PaddingTopProperty); }
            set { SetValue(PaddingTopProperty, value); }
        }

        public static readonly BindableProperty PaddingBotProperty = BindableProperty.Create(nameof(PaddingBot), typeof(int), typeof(CustomEntry), DEFAULT_PADDING_VERTICAL);
        public int PaddingBot
        {
            get { return (int)GetValue(PaddingBotProperty); }
            set { SetValue(PaddingBotProperty, value); }
        }

        public static readonly BindableProperty PaddingLeftProperty = BindableProperty.Create(nameof(PaddingLeft), typeof(int), typeof(CustomEntry), DEFAULT_PADDING_HORIZONTAL);
        public int PaddingLeft
        {
            get { return (int)GetValue(PaddingLeftProperty); }
            set { SetValue(PaddingLeftProperty, value); }
        }

        public static readonly BindableProperty PaddingRightProperty = BindableProperty.Create(nameof(PaddingRight), typeof(int), typeof(CustomEntry), DEFAULT_PADDING_HORIZONTAL);
        public int PaddingRight
        {
            get { return (int)GetValue(PaddingRightProperty); }
            set { SetValue(PaddingRightProperty, value); }
        }
    }
}
