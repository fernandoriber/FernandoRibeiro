using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FernandoRibeiro.Models
{
    public class GeocoderPositionModel
    {
        public string AddressString { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public string MensagemErro { get; set; }
    }
}