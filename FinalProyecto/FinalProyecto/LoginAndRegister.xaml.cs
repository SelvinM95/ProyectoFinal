using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProyecto
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginAndRegister : ContentPage
    {
        public LoginAndRegister()
        {
            InitializeComponent();
        }

        private  async void InicioSesion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CodigoLogin());
        }

        private async void RecuperarPass_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecuperarPassLogin());
        }

        private async void RegistroCuenta_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroLogin());
        }
    }
}