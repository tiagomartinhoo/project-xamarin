using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;

namespace App5.Droid
{

    [Activity(Label = "App5", Icon = "@mipmap/app_icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        
        public override void OnBackPressed()
        {
            MainPage mainPage = Xamarin.Forms.Application.Current.MainPage as MainPage;

            if (mainPage != null && mainPage.isOnInitialPage)
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(this);

                builder
                    .SetMessage(Resources.GetString(Resource.String.leave_confirmation_message))
                    .SetPositiveButton(Resources.GetString(Resource.String.yes), (dialog, args) =>
                        {
                            // Close the activity
                            Finish();
                        })
                    .SetNegativeButton(Resources.GetString(Resource.String.no), (dialog, args) => { });

                builder.Show();
            }
            else
            {
                base.OnBackPressed();
            }
        }
    }
}