using Acr.UserDialogs;
using FinalProyecto.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SolicitudGrupos : ContentPage
    {
        string Id;

        public SolicitudGrupos(string id)
        {
            InitializeComponent();
            Id = id;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            UserDialogs.Instance.ShowLoading("Cargando");

            string url = string.Format("http://3.15.208.156/WSXamarin/groups/members/"+Id);
            ConsultManager manager = new ConsultManager();
            var res = await manager.getUsers(url);

            if (res != null)
            {
                ListStudent.ItemsSource = res;
            }

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://3.15.208.156");
            string url2 = string.Format("/WSXamarin/groups/verifymember/{0}/{1}", Id, App.Current.Properties["Id"].ToString());
            var response = await client.GetAsync(url2);
            var result = response.Content.ReadAsStringAsync().Result;

            if (string.IsNullOrEmpty(result) || result == "null" || !response.IsSuccessStatusCode)
            {
                unirme.IsVisible = true;

            }
            else
            {
                unirme.IsVisible = false;
                labelAdvertencia.IsVisible = true;
            }

            UserDialogs.Instance.HideLoading();
        }


        private async void unirme_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Alerta", "¿Quieres unirte al grupo?", "Yes", "No");
            if (answer == true)
            {
                UserDialogs.Instance.ShowLoading("Cargando");
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://3.15.208.156");
                string url = string.Format("/WSXamarin/groups/addmembers/{0}/{1}", Id, App.Current.Properties["Id"].ToString());
                var response = await client.GetAsync(url);
                var result = response.Content.ReadAsStringAsync().Result;

                  if (string.IsNullOrEmpty(result) || result == "null" || !response.IsSuccessStatusCode)
                  {
                     await DisplayAlert("Error", "Error al unirte", "OK");

                  }
                  else
                  { 
                    await DisplayAlert("Success", "te has unido al grupo", "Ok");
                  }
                UserDialogs.Instance.HideLoading();
                recargar();


            }
            else
            {

            }
        }

        public async void recargar()
        {
            UserDialogs.Instance.ShowLoading("Cargando");

            string url = string.Format("http://3.15.208.156/WSXamarin/groups/members/" + Id);
            ConsultManager manager = new ConsultManager();
            var res = await manager.getUsers(url);

            if (res != null)
            {
                ListStudent.ItemsSource = res;
            }

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://3.15.208.156");
            string url2 = string.Format("/WSXamarin/groups/verifymember/{0}/{1}", Id, App.Current.Properties["Id"].ToString());
            var response = await client.GetAsync(url2);
            var result = response.Content.ReadAsStringAsync().Result;

            if (string.IsNullOrEmpty(result) || result == "null" || !response.IsSuccessStatusCode)
            {
                unirme.IsVisible = true;

            }
            else
            {
                unirme.IsVisible = false;
                labelAdvertencia.IsVisible = true;
            }

            UserDialogs.Instance.HideLoading();

        }



    }
}