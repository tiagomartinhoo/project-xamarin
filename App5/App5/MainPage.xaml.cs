using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Linq;

namespace App5
{
    public partial class MainPage : ContentPage
    {
        private readonly WebView webView;
        private readonly NavigationPage navPage;
        public bool isOnInitialPage = true;
        private int pageCounter = 0;

        public MainPage(string url, NavigationPage navigationPage)
        {
            InitializeComponent();

            navPage = navigationPage;

            webView = new WebView
            {
                Source = url,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            Content = webView;
            webView.Navigating += On_Navigating;
        }

        protected override bool OnBackButtonPressed()
        {
            if (!isOnInitialPage)
            {
                pageCounter--;
                webView.GoBack();
                return true;
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () => await navPage.PopAsync());
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
                    pageCounter++;
                    isOnInitialPage = pageCounter == 1;
                    // Push the initial page onto the navigation stack.
                    if (isOnInitialPage && !navPage.Navigation.NavigationStack.Contains(this))
                    {
                        await navPage.PushAsync(this);
                    }
                }
            }
        }
    }
}
