using ChatApp_Dayata_Woogue.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ChatApp_Dayata_Woogue.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}