<h1 align="center">
    Xamarin Project
</h1>
<h4 align="center">A Project to convert a website into an Android and iOS application.</h4>
<br>

## Description

The project will be developed using [Xamarin](https://dotnet.microsoft.com/en-us/apps/xamarin), a cross-platform for building Android and iOS apps with .NET and C#.

The purpose of this project is to convert a website into an Android and iOS application. The app allows users to browse the website but prevents them from navigating to external websites, instead opening external links in the device's default browser.

## Getting Started

1. Install Visual Studio in a version that supports Xamarin.

2. You need to clone the project as follows:
    ```sh
    git clone https://github.com/tiagomartinhoo/project-xamarin.git
    ```
3. Then open the project in Visual Studio.

4. You can convert your website by changing:

    - `url` variable to the url of your website (found in the [App5/App5/App.xaml.cs](https://github.com/tiagomartinhoo/project-xamarin/blob/main/App5/App5/App.xaml.cs) file):

        ```cs
        string url = "https://www.yourwebsiteurl.com/";
        ```

    - `app_name` variable to the name of your application (found in the [App5/App5.Android/Resources/values/strings.xml](https://github.com/tiagomartinhoo/project-xamarin/blob/main/App5/App5.Android/Resources/values/strings.xml) file):

        ```xml
        <string name="app_name">Your App Name</string>
        ```

    - `app_icon.png` file to the icon you want to have in the app (found in the [App5/App5.Android/Resources/mipmap/](https://github.com/tiagomartinhoo/project-xamarin/blob/main/App5/App5.Android/Resources/mipmap) directory).

    - `splash_screen.png` file to the image you want to be displayed on the splash screen (found in the [App5/App5.Android/Resources/drawable/](https://github.com/tiagomartinhoo/project-xamarin/tree/main/App5/App5.Android/Resources/drawable) directory).

## Usage

Here is an example with the [W3school](https://www.w3schools.com/) website:

<p align="center">
    <img src="https://user-images.githubusercontent.com/80893376/233212510-914ec35e-634a-48d2-b611-b77e319fb877.png">
</p>

