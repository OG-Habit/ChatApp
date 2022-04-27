using Android.Content;
using Android.Graphics.Drawables;
using ChatAppDayataWoogue.CustomRenderers;
using ChatAppDayataWoogue.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace ChatAppDayataWoogue.Droid
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if(Control != null)
            {
                var view = (CustomEntry) Element;
                var background = new GradientDrawable();
                background.SetStroke(view.BorderWidth, Color.Black.ToAndroid());
                background.SetCornerRadius(view.BorderRadius);

                Control.SetBackground(background);
                Control.SetPadding(view.PaddingLeft, view.PaddingTop, view.PaddingRight, view.PaddingBot);
            }
        }
    }
}