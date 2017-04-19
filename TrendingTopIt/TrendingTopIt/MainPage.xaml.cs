using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TrendingTopIt
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            var np = new NavigationPage(this);
            
            Application.Current.MainPage = np;
           // new NavigationPage(this);
          //  NavigationPage.SetHasNavigationBar(this, true);


        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new SignUpPage());
            //App.Navigation.InsertPageBefore(new SignUpPage(), this);
            // await Navigation.PopAsync();
            //   Navigation.PushAsync(new SignUpPage());
            //  await Navigation.PushAsync(new SignUpPage());
            //  App.Current.MainPage = new NavigationPage(new SignUpPage());
            if (Device.OS == TargetPlatform.iOS)
            {
                await Navigation.PopToRootAsync();
            }
            Application.Current.MainPage = new SignUpPage();
        }
        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            // Navigation.InsertPageBefore(new MainPage(), this);
            // await Navigation.PushAsync(new MainPage());
            //  App.Current.MainPage = new NavigationPage(new MainPage());
            if (Device.OS == TargetPlatform.iOS)
            {
                await Navigation.PopToRootAsync();
            }
            Application.Current.MainPage = new Login();


            // Navigation.InsertPageBefore(new MainPage(), this);
            //  await Navigation.PopAsync();
            /*var user = new User
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text
            };

            var isValid = AreCredentialsCorrect(user);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new MainPage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = "Login failed";
                //passwordEntry.Text = string.Empty;
            }*/
        }

        /*   bool AreCredentialsCorrect(User user)
           {
               return user.Username == Constants.Username && user.Password == Constants.Password;
           }*/
        }
}
