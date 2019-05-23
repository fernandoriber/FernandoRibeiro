using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FernandoRibeiro.Models
{
    public class DeviceInfoModel
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string DeviceName { get; set; }
        public string VersionString { get; set; }
        public string Platform { get; set; }
        public string Idiom { get; set; }
    }
}