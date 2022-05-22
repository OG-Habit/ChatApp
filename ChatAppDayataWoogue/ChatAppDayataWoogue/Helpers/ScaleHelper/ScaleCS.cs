﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChatAppDayataWoogue
{
    public static class ScaleCS
    {
        public static float ScaleHeight(this int number, int? iOS = null)
        {
            if(iOS.HasValue && Device.RuntimePlatform == Device.iOS)
                number = iOS.Value;

            return (float)(number * (App.ScreenHeight / 568.0));
        }

        public static float ScaleHeight(this double number, double? iOS = null)
        {
            if (iOS.HasValue && Device.RuntimePlatform == Device.iOS)
                number = iOS.Value;

            return (float)(number * (App.ScreenHeight / 568.0));
        }

        public static float ScaleHeight(this float number, float? iOS = null)
        {
            if (iOS.HasValue && Device.RuntimePlatform != Device.iOS)
                number = iOS.Value;

            return (float)(number * (App.ScreenHeight / 568.0));
        }

        public static float ScaleWidth(this int number, int? iOS = null)
        {
            if (iOS.HasValue && Device.RuntimePlatform == Device.iOS)
                number = iOS.Value;

            return (float)(number * (App.ScreenWidth / 568.0));
        }

        public static float ScaleWidth(this double number, double? iOS = null)
        {
            if (iOS.HasValue && Device.RuntimePlatform == Device.iOS)
                number = iOS.Value;

            return (float)(number * (App.ScreenWidth / 568.0));
        }

        public static float ScaleWidth(this float number, float? iOS = null)
        {
            if (iOS.HasValue && Device.RuntimePlatform != Device.iOS)
                number = iOS.Value;

            return (float)(number * (App.ScreenWidth / 568.0));
        }
    }
}
