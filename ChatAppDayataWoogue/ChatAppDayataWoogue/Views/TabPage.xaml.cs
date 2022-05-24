using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChatAppDayataWoogue.Constants;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ChatAppDayataWoogue.CustomViews;

namespace ChatAppDayataWoogue.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabPage : TabbedPage
    {
        DataClass dataClass = DataClass.GetInstance;
        public TabPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            if(dataClass.IsSignedIn == false)
            {
                App.Current.MainPage = new NavigationPage(new LoginPage());
            }
        }

    }
}