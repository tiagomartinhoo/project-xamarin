﻿using Android;
using System;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;

namespace App5
{

    public partial class App : Application
    {
        public static IResourceContainer ResourceContainer { get; private set; }

        string url = "https://www.google.com/";
        public App()
        {
            InitializeComponent();

            if (!IsValidUrl(url))
            {
                Console.WriteLine("Invalid URL.");
                return;
            }

            Current.Properties["appUrl"] = url;
            MainPage = new MainPage(url);
        }

        private static bool IsValidUrl(string url)
        {
            if (string.IsNullOrEmpty(url)) return false;

            Uri uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult) &&
                          (uriResult.Scheme == Uri.UriSchemeHttp ||
                           uriResult.Scheme == Uri.UriSchemeHttps);
        }

    }
}
