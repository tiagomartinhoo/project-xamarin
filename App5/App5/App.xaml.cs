using System;
using Xamarin.Forms;

namespace App5
{
    public partial class App : Application
    {
        string url = "https://www.google.com/";
        public App()
        {
            InitializeComponent();
            if (!IsValidUrl(url))
            {
                Console.WriteLine("Invalid URL.");
                return;
            }
            
            Application.Current.Properties["appUrl"] = url;
            MainPage = new MainPage(url);
        }

        public static bool IsValidUrl(string url)
        {
            if (string.IsNullOrEmpty(url)) return false;

            Uri uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult) &&
                          (uriResult.Scheme == Uri.UriSchemeHttp ||
                           uriResult.Scheme == Uri.UriSchemeHttps);
        }

    }
}
