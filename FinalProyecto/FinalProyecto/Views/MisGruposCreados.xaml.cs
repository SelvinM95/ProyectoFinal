using FinalProyecto.Classes;
using FinalProyecto.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MisGruposCreados : ContentPage
    {
        string nombre;
        public MisGruposCreados()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            string url = string.Format("http://3.15.208.156/WSXamarin/groups/getmygroups/" + App.Current.Properties["Name"].ToString());
            ConsultManager manager = new ConsultManager();
            var res = await manager.getGroups(url);

            if (res != null)
            {
                ListStudent.ItemsSource = res;
            }
        }

        private async void NuevoGrupo_Clicked(object sender, EventArgs e)
        {
            nombre = await DisplayPromptAsync("Registro", "Ingrese Nombre del grupo");
            if (nombre == null)
            {

            }
            else
            {
                bool answer = await DisplayAlert("Alerta", "Quieres guardar este nombre:"+nombre.ToString(), "Yes", "No");
                
                if ( answer == true)
                {
                    var groups = new Groups
                    {
                        teamName = nombre,
                        teamCoordi = App.Current.Properties["Name"].ToString()
                    };

                    var request = new HttpRequestMessage();
                    Uri RequestUri = new Uri("http://3.15.208.156/WSXamarin/groups/add");

                    var client = new HttpClient();
                    var json = JsonConvert.SerializeObject(groups);
                    var contentJSON = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(RequestUri, contentJSON);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        await DisplayAlert("Datos", "Grupo Creado Correctamente", "OK");
                        recargar();
                    }
                }
                else
                {
                    await DisplayAlert("Resultado", "Canceló la creación", "OK");
                }
            }
        }

        public async void recargar()
        {
            string url = string.Format("http://3.15.208.156/WSXamarin/groups/getmygroups/" + App.Current.Properties["Name"].ToString());
            ConsultManager manager = new ConsultManager();
            var res = await manager.getGroups(url);

            if (res != null)
            {
                ListStudent.ItemsSource = res;
            }
        }

        private async void ListStudent_ItemTapped(object sender, ItemTappedEventArgs e)
        { 
            var obj = (Groups)e.Item;

            if (!string.IsNullOrEmpty(obj.idTeam.ToString()))
            {

                var datos = new Groups
                {
                    idTeam = obj.idTeam,
                    teamName = obj.teamName,
                    teamCoordi = obj.teamCoordi
                };

                var detalles = new AgregarUsuarioGrupos(obj.idTeam.ToString());
                detalles.BindingContext = datos;
                await Navigation.PushAsync(detalles);
            }
        }
    }
}