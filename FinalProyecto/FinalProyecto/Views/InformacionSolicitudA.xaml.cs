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
    public partial class InformacionSolicitudA : ContentPage
    {
        String appID;
        int IDSolicitud;
        int ID;

        public InformacionSolicitudA(String AppID, int idSolicitud, int id)
        {
            InitializeComponent();

            appID = AppID;
            IDSolicitud = idSolicitud;
            ID = id;
        }

        private async void send_Clicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.1.35");
            string url = string.Format("/WSXamarin/users/updaterequest/{0}", IDSolicitud);
            var response = await client.GetAsync(url);
            var result = response.Content.ReadAsStringAsync().Result;

            if (string.IsNullOrEmpty(result) || result == "null" || !response.IsSuccessStatusCode)
            {
                await DisplayAlert("Alerta", "Solicitud no existe", "cerrar");
            }
            else
            {
                string url2 = string.Format("/WSXamarin/users/acceptfriendnotification/{0}", appID);
                await client.GetAsync(url2); 
                string url3 = string.Format("/WSXamarin/users/newfriend/{0}/{1}", ID, App.Current.Properties["Id"].ToString());
                await client.GetAsync(url3);
                await DisplayAlert("System", "Solicitud Aceptada", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}