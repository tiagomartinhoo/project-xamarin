using System;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace App5
{
    public partial class MainPage : ContentPage
    {
        public MainPage(string url)
        {
            InitializeComponent();

            var webView = new WebView
            {
                Source = url,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            Content = webView;
            webView.Navigating += on_Navigating;
        }

        public async void on_Navigating(object sender, WebNavigatingEventArgs args)
        {
            // Check if the URL being navigated to is a link
            if (args.Url.StartsWith("http") || args.Url.StartsWith("https"))
            {
                // Check if the URL's host is different from the application's host
                var appUri = new Uri(Application.Current.Properties["appUrl"].ToString());
                var uri = new Uri(args.Url);
                if (uri.Host != appUri.Host)
                {
                    args.Cancel = true;
                    await Launcher.OpenAsync(args.Url);
                }
            }
        }
    }
}
