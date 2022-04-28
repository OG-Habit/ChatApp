using ChatAppDayataWoogue.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatAppDayataWoogue.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConversationPage : ContentPage
    {
        public ConversationPage()
        {
            InitializeComponent();
            BindingContext = new ConversationPageViewModel();
        }

        private void ClearTextInput(object sender, System.EventArgs e)
        {
            EditorTextInput.Text = "";
        }
    }
}