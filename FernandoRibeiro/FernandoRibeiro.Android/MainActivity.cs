using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.CurrentActivity;
using Plugin.Permissions;
using Acr.UserDialogs;
using Android.Locations;
using Android.Content;
using FernandoRibeiro.Helpers;

namespace FernandoRibeiro.Droid
{
    [Activity(Label = "Fernando Ribeiro", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            UserDialogs.Init(this);

            CrossCurrentActivity.Current.Init(this, savedInstanceState);

            Xamarin.FormsMaps.Init(this, savedInstanceState);

            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            //Verifica GPS
            GpsIsOn();

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App());
        }
        
        public void GpsIsOn()
        {
            LocationManager locationManager = (LocationManager)this.GetSystemService(Context.LocationService);

            if(locationManager.IsProviderEnabled(LocationManager.GpsProvider) == false)
            {
                AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                AlertDialog alert = dialog.Create();
                alert.SetTitle(Constants.AppName);
                alert.SetMessage("Seu GPS não está ativo, por favor ative para continuar.");
                alert.SetButton("OK", (c, ev) =>
                {
                    Intent gpsSettingsIntent = new Intent(Android.Provider.Settings.ActionLocationSourceSettings);
                    this.StartActivity(gpsSettingsIntent);
                });
                alert.Show();
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnBackPressed()
        {
            if(Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
            {

            }
            else
            {

            }
        }

    }
}