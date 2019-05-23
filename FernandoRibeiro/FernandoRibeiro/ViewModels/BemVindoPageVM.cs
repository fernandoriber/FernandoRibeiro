using Acr.UserDialogs;
using FernandoRibeiro.Helpers;
using FernandoRibeiro.Interfaces;
using FernandoRibeiro.Models;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Position = Xamarin.Forms.Maps.Position;

namespace FernandoRibeiro.ViewModels
{
    public class BemVindoPageVM : BaseViewModel
    {
        private DeviceInfoModel infoModel = new DeviceInfoModel();
        public DeviceInfoModel InfoModel
        {
            get { return infoModel; }
            set { SetProperty(ref infoModel, value); }
        }

        private string todayDate;
        public string TodayDate
        {
            get { return todayDate; }
            set { SetProperty(ref todayDate, value); }
        }

        private string dayOfweek;
        public string DayOfweek
        {
            get { return dayOfweek; }
            set { SetProperty(ref dayOfweek, value); }
        }

        private string geolocation;
        public string Geolocation
        {
            get { return geolocation; }
            set { SetProperty(ref geolocation, value); }
        }

        private bool isVisible;
        public bool IsVisible
        {
            get { return isVisible; }
            set { SetProperty(ref isVisible, value); }
        }

        public Command GetLocationCommand { get; set; }

        public BemVindoPageVM()
        { 
            GetData();
            GetLocationCommand = new Command(async () => await GetLocation());
        }       

        private void GetData()
        {
            UserDialogs.Instance.ShowLoading("Carregando informações...");

            try
            {
                IsVisible = false;
                SetDate();
                SetDeviceInfo();
            }
            catch (Exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Erro ao inicializar o aplicativo!", Constants.AppName, "OK");
            }

            UserDialogs.Instance.HideLoading();
        }

        private async Task GetLocation()
        {
            UserDialogs.Instance.ShowLoading("Obtendo localização...");

            GeocoderPositionModel positionModel = new GeocoderPositionModel();
            try
            {
                positionModel = await Utils.GetGeolocation();

                if (positionModel.AddressString != null)
                {
                    IsVisible = true;
                    Geolocation = positionModel.AddressString;
                }
                else
                {
                    Geolocation = "Localização não obtida";
                }

                ChangeProperty(nameof(Geolocation));

            }
            catch (Exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Erro ao obter localização!", Constants.AppName, "OK");
            }

            UserDialogs.Instance.HideLoading();
        }

        private void SetDate()
        {
            try
            {
                dayOfweek = DateTime.Now.ToString("dddd", new CultureInfo("pt-BR")).ToUpper() + " - ";
                ChangeProperty(nameof(dayOfweek));

                todayDate = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
                ChangeProperty(nameof(todayDate));
                
            }
            catch (Exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Erro ao obter a data atual!", Constants.AppName, "OK");                
            }
        }

        private void SetDeviceInfo()
        {   
            try
            {
                InfoModel.Model = DeviceInfo.Model;
                InfoModel.Manufacturer = DeviceInfo.Manufacturer;
                InfoModel.DeviceName = DeviceInfo.Name;
                InfoModel.VersionString = DeviceInfo.VersionString;
                InfoModel.Platform = DeviceInfo.Platform.ToString();
            }
            catch (Exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Erro ao obter informações do dispositivo!", Constants.AppName, "OK");              
            }

            ChangeProperty(nameof(InfoModel));
        }
    }
}