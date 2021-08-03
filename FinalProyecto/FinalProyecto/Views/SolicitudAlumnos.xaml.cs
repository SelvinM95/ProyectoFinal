using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SolicitudAlumnos : ContentPage
    {
        int Id;
        String appID;

        public SolicitudAlumnos(int id, String AppID)
        {
            InitializeComponent();
            Id = id;
            appID = AppID;
        }

        private async void send_Clicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.100.77");
            string url = string.Format("/WSXamarin/users/solicitude/{0}/{1}", App.Current.Properties["Id"].ToString(), Id);
            var response = await client.GetAsync(url);
            var result = response.Content.ReadAsStringAsync().Result;

            if (string.IsNullOrEmpty(result) || result == "null" || !response.IsSuccessStatusCode)
            {
                await DisplayAlert("Alerta", "Usuario no existe", "cerrar");
            }
            else
            {
                string url2 = string.Format("/WSXamarin/users/friendnotification/{0}", appID);
                await client.GetAsync(url2);
                await DisplayAlert("System", "Solicitud Enviada", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}