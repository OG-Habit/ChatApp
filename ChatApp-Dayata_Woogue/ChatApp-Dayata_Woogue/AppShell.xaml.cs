using ChatApp_Dayata_Woogue.ViewModels;
using ChatApp_Dayata_Woogue.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ChatApp_Dayata_Woogue
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
