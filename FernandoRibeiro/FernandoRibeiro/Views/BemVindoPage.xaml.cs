using Acr.UserDialogs;
using FernandoRibeiro.Interfaces;
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
    public partial class BemVindoPage : ContentPage
    {
        public BemVindoPage()
        {
            InitializeComponent();
            BindingContext = new BemVindoPageVM();
        }

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                if(await UserDialogs.Instance.ConfirmAsync("Tem certeza que deseja sair?", "Fernando Ribeiro", "Sim", "Não"))
                {
                    base.OnBackButtonPressed();

                    DependencyService.Get<ExitAppInterface>().ExitApp();
                }
            });

            return true;
        }
    }
}