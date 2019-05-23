using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FernandoRibeiro.Droid;
using FernandoRibeiro.Helpers;
using FernandoRibeiro.Interfaces;

[assembly:Xamarin.Forms.Dependency(typeof(AndroidMethods))]
namespace FernandoRibeiro.Droid
{
    public class AndroidMethods : ExitAppInterface
    {
        public void ExitApp()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }

    public class GPSAndroid : IGPSAndroid
    {
        public void CheckGPSEnabled()
        {
            LocationManager locationManager = (LocationManager)Application.Context.GetSystemService(Context.LocationService);

            if (locationManager.IsProviderEnabled(LocationManager.GpsProvider) == false)
            {
                AlertDialog.Builder dialog = new AlertDialog.Builder(Application.Context);
                AlertDialog alert = dialog.Create();
                alert.SetTitle(Constants.AppName);
                alert.SetMessage("Seu GPS não está ativo, por favor ative para continuar.");
                alert.SetButton("OK", (c, ev) =>
                {
                    Intent intentGps = new Intent(Android.Provider.Settings.ActionLocationSourceSettings);
                    Application.Context.StartActivity(intentGps);
                });
                alert.Show();
            }
        }
    }
}