using FinalProyecto.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProyecto
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CodigoLogin : ContentPage
    {
        String tmpPass, verificationCode, base64Img, name, nCount, telephone, mail, Birthdate, Carrera;

        public CodigoLogin(String tmppassword, String code, String base64, String nombre, String ncount, String tel, String email, String birthdate, String carrera)
        {
            InitializeComponent();

            tmpPass = tmppassword;
            verificationCode = code;
            base64Img = base64;
            name = nombre;
            nCount = ncount;
            telephone = tel;
            mail = email;
            Birthdate = birthdate;
            Carrera = carrera;
        }

        private async void EnviarCorreo_Clicked(object sender, EventArgs e)
        {
            if (code.Text == verificationCode)
            {
                var user = new User
                {
                    NameUser = name,
                    nCountUser = nCount,
                    telUser = telephone,
                    emailUser = mail,
                    password = tmpPass,
                    fotoUser = base64Img,
                    birthdateUser = Birthdate,
                    carreraUser = Carrera,
                    AppIDUser = Preferences.Get("TokenApp", "")
                };

                var request = new HttpRequestMessage();
                Uri RequestUri = new Uri("http://192.168.1.35/WSXamarin/users/add");

                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(user);
                var contentJSON = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(RequestUri, contentJSON);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    await DisplayAlert("Datos", "Cuenta Creada y Verificada, Por favor Inicie Sesión", "OK");
                    Application.Current.MainPage = new LoginAndRegister(App.Current);
                }
            }
            else
            {
                await DisplayAlert("Verificación", "Token Incorrecto", "OK");
            }
        }
    }
}