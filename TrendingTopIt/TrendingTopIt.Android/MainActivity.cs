using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TrendingTopIt.Droid
{
	[Activity (Label = "TrendingTopIt", Icon = "@drawable/icon", Theme="@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar; 

			base.OnCreate (bundle);
        /*    ImageCircle.Forms.Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeModule())
                          .With(new Plugin.Iconize.Fonts.MaterialModule())
                          .With(new Plugin.Iconize.Fonts.MeteoconsModule())
                          .With(new Plugin.Iconize.Fonts.TypiconsModule());
            */

            global::Xamarin.Forms.Forms.Init (this, bundle);
//FormsPlugin.Iconize.Droid.IconControls.Init(Resource.Id.toolbar, Resource.Id.tabs);
            LoadApplication (new TrendingTopIt.App ());
            var x = typeof(Xamarin.Forms.Themes.DarkThemeResources);
            x = typeof(Xamarin.Forms.Themes.LightThemeResources);
            x = typeof(Xamarin.Forms.Themes.Android.UnderlineEffect);
            
        }
	}
}

