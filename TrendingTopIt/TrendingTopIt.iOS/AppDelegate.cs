﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace TrendingTopIt.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
            /*Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeModule())
                          .With(new Plugin.Iconize.Fonts.MaterialModule())
                          .With(new Plugin.Iconize.Fonts.MeteoconsModule())
                          .With(new Plugin.Iconize.Fonts.TypiconsModule());*/
            global::Xamarin.Forms.Forms.Init ();
           // FormsPlugin.Iconize.iOS.IconControls.Init();
            LoadApplication (new TrendingTopIt.App ());
            var x = typeof(Xamarin.Forms.Themes.DarkThemeResources);
            x = typeof(Xamarin.Forms.Themes.LightThemeResources);
            x = typeof(Xamarin.Forms.Themes.iOS.UnderlineEffect);

            return base.FinishedLaunching (app, options);
		}
	}
}
