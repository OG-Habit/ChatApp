using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using ChatAppDayataWoogue;

using Xamarin.Forms;
using Firebase;
using AndroidX.AppCompat.App;

namespace ChatAppDayataWoogue.Droid
{
    [Activity(Label = "ChatAppDayataWoogue", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            AppCompatDelegate.DefaultNightMode = AppCompatDelegate.ModeNightNo;

            var density = Resources.DisplayMetrics.Density;
            TabLayoutResource  = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            FirebaseApp.InitializeApp(this);

            App.ScreenWidth = Resources.DisplayMetrics.WidthPixels / density;
            App.ScreenHeight = Resources.DisplayMetrics.HeightPixels / density;

            if (Device.Idiom == TargetIdiom.Phone)
                App.ScreenHeight = (16 * App.ScreenWidth) / 9;

            if(Device.Idiom == TargetIdiom.Tablet)
                App.ScreenWidth = (9 * App.ScreenHeight) / 16;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}