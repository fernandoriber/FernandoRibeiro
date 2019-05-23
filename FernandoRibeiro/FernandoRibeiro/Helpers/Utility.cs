using FernandoRibeiro.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FernandoRibeiro.Helpers
{
    public class Utility
    {
        public static void GpsIsOn()
        {
            DependencyService.Get<IGPSAndroid>().CheckGPSEnabled();
        }
    }
}
