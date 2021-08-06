using Acr.UserDialogs;
using FinalProyecto.Classes;
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
    public partial class AgregarUsuarioGrupos : ContentPage
    {
        string Id;
        string usuarioid;
        public AgregarUsuarioGrupos(string id)
        {
            
            InitializeComponent();
            Id = id;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            UserDialogs.Instance.ShowLoading("Cargando");
            string url = string.Format("http://3.15.208.156/WSXamarin/users/myfriends/{0}", App.Current.Properties["Id"].ToString());
            ConsultManager manager = new ConsultManager();
            var res = await manager.getUsers(url);

            if (res != null)
            {
                ListStudent.ItemsSource = res;
            }
            UserDialogs.Instance.HideLoading();
        }

        private async void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (search.Text == "")
            {
                string url = string.Format("http://3.15.208.156/WSXamarin/users/myfriends/{0}", App.Current.Properties["Id"].ToString());

                ConsultManager manager = new ConsultManager();
                var res = await manager.getUsers(url);

                if (res != null)
                {
                    ListStudent.ItemsSource = res;
                }
            }
            else
            {
                string url = string.Format("http://3.15.208.156/WSXamarin/users/searchuser/{0}/{1}", search.Text, App.Current.Properties["Id"].ToString());

                ConsultManager manager = new ConsultManager();
                var res = await manager.getUsers(url);

                if (res != null)
                {
                    ListStudent.ItemsSource = res;
                }
            }
        }

        private async void ListStudent_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            bool answer = await DisplayAlert("Alerta", "¿Quieres agregar este usuario?", "Yes", "No");
            if (answer == true)
            {
                var obj = (User)e.Item;
                usuarioid = obj.idUser.ToString();

                HttpClient client2 = new HttpClient();
                client2.BaseAddress = new Uri("http://3.15.208.156");
                string url2 = string.Format("/WSXamarin/groups/verifymember/{0}/{1}", Id, usuarioid);
                var response2 = await client2.GetAsync(url2);
                var result2 = response2.Content.ReadAsStringAsync().Result;

                if (string.IsNullOrEmpty(result2) || result2 == "null" || !response2.IsSuccessStatusCode)
                { 
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://3.15.208.156");
                    string url = string.Format("/WSXamarin/groups/addmembers/{0}/{1}", Id, usuarioid);
                    var response = await client.GetAsync(url);
                    var result = response.Content.ReadAsStringAsync().Result;

                    if (string.IsNullOrEmpty(result) || result == "null" || !response.IsSuccessStatusCode)
                    {
                        await DisplayAlert("Error", "Error Al agregar usuario", "OK");

                    }
                    else
                    {
                        await DisplayAlert("Success", "Usuario Agregado", "Ok");
                    }

                }
                else
                {
                    await DisplayAlert("Success", "Usuario ya existe en el grupo", "Ok");
                }
            }
            else
            { 

            }
        }
    }
}