using Android.Content;
using ChatAppDayataWoogue.CustomRenderers;
using ChatAppDayataWoogue.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace ChatAppDayataWoogue.Droid.CustomRenderers
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        public CustomButtonRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
            {
                Control.SetPadding(0, 0, 0, 0);  
            }
        }
    }
}