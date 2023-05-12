using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Resources;
using System.Reflection;

namespace App5
{
    public partial class MainPage : ContentPage
    {
        private readonly WebView webView;
        public bool isOnInitialPage = true;
        private readonly ResourceContainer _resourceContainer;

        public MainPage(string url)
        {
            InitializeComponent();

            var resourceManager = new ResourceManager(ResourceContainer.ResourceId, typeof(App).GetTypeInfo().Assembly);
            _resourceContainer = new ResourceContainer(resourceManager, new Localize());

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
                DisplayNoInternetAlert();
            }
        }

        protected override bool OnBackButtonPressed()
        {
            if (!isOnInitialPage)
            {
                webView.GoBack();
            }
            else
            {
                DisplayExitAlert();
            }
            return true;
        }

        private async void On_Navigating(object sender, WebNavigatingEventArgs args)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                DisplayNoInternetAlert();
                return;
            }
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

        private async void DisplayNoInternetAlert()
        {
            Content = null;

            var title = _resourceContainer.GetString("NO_INTERNET_CONNECTION_TITLE");
            var message = _resourceContainer.GetString("NO_INTERNET_CONNECTION_MESSAGE");

            await DisplayAlert(title, message, "OK");

            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }

        private async void DisplayExitAlert()
        {
            var title = _resourceContainer.GetString("LEAVE_CONFIRMATION_TITLE");
            var message = _resourceContainer.GetString("LEAVE_CONFIRMATION_MESSAGE");
            var yes = _resourceContainer.GetString("YES"); ;
            var no = _resourceContainer.GetString("NO"); ;
            
            bool confirm = await DisplayAlert(title, message, yes, no);

            if (confirm)
            {
                System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            }
        }
    }
}
