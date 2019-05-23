using Acr.UserDialogs;
using FernandoRibeiro.Interfaces;
using FernandoRibeiro.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FernandoRibeiro.Helpers
{
    public class Utils
    {
        public static async Task<GeocoderPositionModel> GetGeolocation()
        {
            GeocoderPositionModel position = new GeocoderPositionModel();

            try
            {
                position = await Services.GeolocatorService.GetGeocoderPosition();
            }
            catch (Exception)
            {
                UserDialogs.Instance.Alert("Erro ao obter sua localização! Verifique se a opção de localização está ativa", Constants.AppName, "OK");
            }

            return position;
        }

    }
    
}
