using FinalProyecto.Models;
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
    public partial class CambioPass : ContentPage
    {
        public CambioPass()
        {
            InitializeComponent();

            nombre.Text = App.Current.Properties["Name"].ToString();
            profile.Source = App.Current.Properties["Path"].ToString();
            cuenta.Text = App.Current.Properties["Account"].ToString();
        }

        private async void guardar_Clicked(object sender, EventArgs e)
        {
            if (npass.Text == cpass.Text) 
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://192.168.1.35");
                string url = string.Format("/WSXamarin/users/updatepass/{0}/{1}", App.Current.Properties["Id"].ToString(), cpass.Text);
                var response = await client.GetAsync(url);
                var result = response.Content.ReadAsStringAsync().Result;

                if (string.IsNullOrEmpty(result) || result == "null" || !response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Alerta", "Las contraseñas deben concordar, Rellene los campos", "cerrar");
                }
                else
                {
                    await DisplayAlert("System", "Contraseña Actualizada", "OK");
                    await Navigation.PopAsync();
                }
            }
            else
            {
                await DisplayAlert("Alerta", "Las contraseñas deben concordar","OK");
            }
        }
    }
}