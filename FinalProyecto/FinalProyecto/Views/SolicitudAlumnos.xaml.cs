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

        protected async override void OnAppearing()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://3.15.208.156");
            string url = string.Format("/WSXamarin/users/getfriend/{0}/{1}", App.Current.Properties["Id"].ToString(), Id);
            var response = await client.GetAsync(url);
            var result = response.Content.ReadAsStringAsync().Result;

            if (string.IsNullOrEmpty(result) || result == "null" || !response.IsSuccessStatusCode)
            {
                string url2 = string.Format("/WSXamarin/users/getrequest/{0}/{1}", App.Current.Properties["Id"].ToString(), Id);
                var response2 = await client.GetAsync(url2);
                var result2 = response2.Content.ReadAsStringAsync().Result;

                if (string.IsNullOrEmpty(result2) || result2 == "null" || !response2.IsSuccessStatusCode)
                {
                    labelProceso.IsVisible = false;
                    labelAmistad.IsVisible = false;
                    send.IsVisible = true;
                }
                else 
                {
                    labelProceso.IsVisible = true;
                    labelAmistad.IsVisible = false;
                    send.IsVisible = false;
                }
            }
            else
            {
                labelAmistad.IsVisible = true;
                send.IsVisible = false;
            }
        }

        private async void send_Clicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://3.15.208.156");
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
                labelProceso.IsVisible = true;
                send.IsVisible = false;
                await Navigation.PopAsync();
            }
        }
    }
}