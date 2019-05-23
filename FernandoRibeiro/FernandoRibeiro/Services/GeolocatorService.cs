using FernandoRibeiro.Models;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace FernandoRibeiro.Services
{
    public class GeolocatorService 
    {
        public static async Task<GeocoderPositionModel> GetGeocoderPosition()
        {
            GeocoderPositionModel geocoderPositionModel = new GeocoderPositionModel();

            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
            var geoCoderPosition = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);

            // Reverse geocoding
            var geocoder = new Geocoder();
            var addresses = await geocoder.GetAddressesForPositionAsync(geoCoderPosition);

            List<string> addressParse = new List<string>();

            foreach (var address in addresses)
            {
                addressParse.Add(address);
            }

            geocoderPositionModel.AddressString = addressParse.First();
            geocoderPositionModel.Latitude = string.Format("{0:0.0000000}", position.Latitude).ToString();
            geocoderPositionModel.Longitude = string.Format("{0:0.0000000}", position.Longitude).ToString();

            return geocoderPositionModel;
        }
    }
}