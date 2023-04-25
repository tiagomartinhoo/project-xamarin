using System;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace App5
{
    public partial class MainPage : ContentPage
    {
        private readonly WebView webView;
        public bool isOnInitialPage = true;

        public MainPage(string url)
        {
            InitializeComponent();

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                webView = new WebView
                {
                    Source = url,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };

                Content = webView;
                webView.Navigating += On_Navigating;
            }
            else
            {
                DisplayAlert("No connection", "Check your internet connection and try again.", "OK");
            }
        }

        protected override bool OnBackButtonPressed()
        {
            if (!isOnInitialPage)
            {
                webView.GoBack();
                return true;
            }
            else
            {
                return base.OnBackButtonPressed();
            }
        }

        private async void On_Navigating(object sender, WebNavigatingEventArgs args)
        {
            // Check if the URL being navigated to is a link.
            if (args.Url.StartsWith("http") || args.Url.StartsWith("https"))
            {
                // Check if the URL's host is different from the application's host.
                var appUri = new Uri(Application.Current.Properties["appUrl"].ToString());
                var uri = new Uri(args.Url);
                if (uri.Host != appUri.Host)
                {
                    args.Cancel = true;
                    await Launcher.OpenAsync(args.Url);
                }
                else
                {
                    isOnInitialPage = appUri == uri;
                }
            }
        }
    }
}
