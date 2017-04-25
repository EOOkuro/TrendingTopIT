using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TrendingTopIt
{
	public partial class App : Application
	{
        public static bool IsUserLoggedIn;
        public App ()
		{
            InitializeComponent();
           // MainPage = new TabbedPageDemoPage();

             // MainPage = new NavigationPage { BarBackgroundColor = Color.Black, BarTextColor = Color.White };

           //  MainPage.Navigation.PushAsync(new TabbedPageDemoPage());
              var np = new NavigationPage(new MainPage());
             MainPage = np;
            InitializeComponent();
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

	}
}
