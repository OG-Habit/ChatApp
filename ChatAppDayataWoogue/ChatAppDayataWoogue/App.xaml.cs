using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ChatAppDayataWoogue.Constants;

namespace ChatAppDayataWoogue
{
    public partial class App : Application
    {
        public static float ScreenWidth { get;  set; }
        public static float ScreenHeight { get; set; }
        public static float AppScale { get; set; }

        DataClass dataClass = DataClass.GetInstance;
        public App()
        {
            InitializeComponent();
            if (Current.Properties.ContainsKey(KEY_ISSIGNEDIN) && Convert.ToBoolean(Current.Properties[KEY_ISSIGNEDIN])==true)
            {
                MainPage = new NavigationPage(new Views.TabPage());
            }
            else
            {
                MainPage = new NavigationPage(new Views.LoginPage());
            }
            //{
            //    Application.Current.MainPage = new NavigationPage(new SampleTabbedPage(
            //        Application.Current.Properties["name"].ToString(), Application.Current.Properties["email"].ToString()
            //    ));
            //}
            //else
            //{
            //    MainPage = new LoginPage();
            //}
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
