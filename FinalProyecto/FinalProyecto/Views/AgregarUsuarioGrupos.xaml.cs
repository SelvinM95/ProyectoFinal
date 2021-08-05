﻿using FinalProyecto.Classes;
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
            string url = string.Format("http://3.15.208.156/WSXamarin/users/myfriends/{0}", App.Current.Properties["Id"].ToString());
            ConsultManager manager = new ConsultManager();
            var res = await manager.getUsers(url);

            if (res != null)
            {
                ListStudent.ItemsSource = res;
            }
        }

        private async void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (search.Text == "")
            {
                string url = string.Format("http://3.15.208.156/WSXamarin/users/all/{0}", App.Current.Properties["Id"].ToString());

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
            var obj = (User)e.Item;
            usuarioid = obj.idUser.ToString();

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
                await Navigation.PopAsync();
            }
        }
    }
}