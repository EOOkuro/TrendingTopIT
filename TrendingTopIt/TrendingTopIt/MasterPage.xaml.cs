using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendingTopIt.MenuItems;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrendingTopIt
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }
        public MasterPage ()
		{
			InitializeComponent ();
            menuList = new List<MasterPageItem>();

            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            var page1 = new MasterPageItem() { Title = "My Profile", Icon = "Icon.png", TargetType = typeof(TestPage1) };
            var page2 = new MasterPageItem() { Title = "Discover", Icon = "Icon.png", TargetType = typeof(Discover) };
            var page3 = new MasterPageItem() { Title = "Friends", Icon = "Icon.png", TargetType = typeof(TestPage3) };
            var page4 = new MasterPageItem() { Title = "Timeline", Icon = "Icon.png", TargetType = typeof(TestPage1) };
          

            // Adding menu items to menuList
            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);
     

            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(TestPage1)));
           NavigationPage.SetTitleIcon(this, "Icon");
            
        }
         private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e) {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
}
	}
}
