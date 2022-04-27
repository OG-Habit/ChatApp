using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChatAppDayataWoogue.CustomRenderers
{
    public class CustomLabel : Label
    {
        public static readonly BindableProperty MaxWidthProperty = BindableProperty.Create(nameof(MaxWidth), typeof(int), typeof(CustomLabel));
        public int MaxWidth
        {
            get { return (int)GetValue(MaxWidthProperty); }
            set { SetValue(MaxWidthProperty, value); }
        }
    }
}
