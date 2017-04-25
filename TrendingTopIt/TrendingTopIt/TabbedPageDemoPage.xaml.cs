using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendingTopIt;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace TrendingTopIt
{
    public class TabbedPageDemoPageCS : TabbedPage
{
    public TabbedPageDemoPageCS()
    {
        var booleanConverter = new NonNullToBooleanConverter();

        ItemTemplate = new DataTemplate(() => {
            var nameLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };
            nameLabel.SetBinding(Label.TextProperty, "Name");

            var image = new Image { WidthRequest = 200, HeightRequest = 200 };
            image.SetBinding(Image.SourceProperty, "PhotoUrl");

            var familyLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            };
            familyLabel.SetBinding(Label.TextProperty, "Family");
      var contentPage = new ContentPage
      {
          Icon = "Icon.png",
          Content = new StackLayout
          {
              Padding = new Thickness(5, 25),
              Children = {
            nameLabel,
            image,
            new StackLayout {
              Padding = new Thickness (50, 10),
              Children = {
                new StackLayout {
                  Orientation = StackOrientation.Horizontal,
                  Children = {
                    new Label { Text = "Family:", HorizontalOptions = LayoutOptions.FillAndExpand },
                    familyLabel
                  }
                }
              }
            }
          }
          }
      };
            contentPage.SetBinding(TitleProperty, "Name");
            return contentPage;
        });
        ItemsSource = MonkeyDataModel.All;
    }
}
}