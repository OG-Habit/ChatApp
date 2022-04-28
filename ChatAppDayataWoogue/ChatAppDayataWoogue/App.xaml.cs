using ChatAppDayataWoogue.Services;
using ChatAppDayataWoogue.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatAppDayataWoogue
{
    public partial class App : Application
    {
        public static float screenWidth { get;  set; }
        public static float screenHeight { get; set; }
        public static float appScale { get; set; }

        public App()
        {
            InitializeComponent();
            //DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
