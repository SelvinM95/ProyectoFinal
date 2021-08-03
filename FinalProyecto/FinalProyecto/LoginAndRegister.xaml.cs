using FinalProyecto.Classes;
using FinalProyecto.Models;
using Newtonsoft.Json;
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
    public partial class LoginAndRegister : ContentPage
    {
        ILoginManager iml = null;

        public LoginAndRegister(ILoginManager ilm)
        {
            InitializeComponent();
            iml = ilm;
        }

        private  async void InicioSesion_Clicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.100.77");
            string url = string.Format("/WSXamarin/login/get/{0}/{1}", userName.Text, userPassword.Text);
            var response = await client.GetAsync(url);
            var result = response.Content.ReadAsStringAsync().Result;

            if (string.IsNullOrEmpty(result) || result == "null" || !response.IsSuccessStatusCode)
            {
                await DisplayAlert("Alerta", "Usuario o Contraseña Incorrecto", "cerrar");
            }
            else
            {
                var res = JsonConvert.DeserializeObject<User>(result);

                App.Current.Properties["Id"] = res.idUser;
                App.Current.Properties["Name"] = res.NameUser;
                App.Current.Properties["Account"] = res.nCountUser;
                App.Current.Properties["Telephone"] = res.telUser;
                App.Current.Properties["Carrera"] = res.carreraUser;
                App.Current.Properties["Email"] = res.emailUser;
                App.Current.Properties["Birthday"] = res.birthdateUser;
                App.Current.Properties["Path"] = res.fotoUser;
                App.Current.Properties["IsLoggedIn"] = true;

                iml.ShowMainPage();
            }
        }

        private void RecuperarPass_Tapped(object sender, EventArgs e)
        {
            iml.ShowRecoverPage();
        }

        private void RegistroCuenta_Tapped(object sender, EventArgs e)
        {
            iml.ShowRegisterPage();
        }
    }
}