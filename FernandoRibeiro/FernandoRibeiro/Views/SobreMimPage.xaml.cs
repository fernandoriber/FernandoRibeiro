using FernandoRibeiro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FernandoRibeiro.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SobreMimPage : ContentPage
    {
        public SobreMimPage()
        {
            InitializeComponent();
            BindingContext = new SobreMimVM();
        }
    }
}