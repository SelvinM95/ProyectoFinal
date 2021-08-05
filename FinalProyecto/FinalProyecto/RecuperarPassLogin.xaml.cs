using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProyecto
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecuperarPassLogin : ContentPage
    {
        public RecuperarPassLogin()
        {
            InitializeComponent();
        }

        private async void EnviarCorreo_Clicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://3.15.208.156");
            string url = string.Format("/WSXamarin/users/recover/{0}", mail.Text);
            await client.GetAsync(url);

            await DisplayAlert("Alerta", "Se ha Enviado un Correo Electrónico con la Contraseña Recuperada", "cerrar");
            Application.Current.MainPage = new LoginAndRegister(App.Current);
        }
    }
}