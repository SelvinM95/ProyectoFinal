using FinalProyecto.Classes;
using FinalProyecto.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicio : ContentPage
    {
        int id;
        String AppID;

        public Inicio()
        {
            InitializeComponent(); 
        }

        protected async override void OnAppearing()
        {
            string url = string.Format("http://192.168.1.35/WSXamarin/users/all/{0}", App.Current.Properties["Id"].ToString());
            ConsultManager manager = new ConsultManager();
            var res = await manager.getUsers(url);

            if (res != null)
            {
                ListStudent.ItemsSource = res;
            }
        } 

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void ListStudent_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }

        private async void ListStudent_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            search.Text = "";

            var obj = (User)e.Item;

            id = obj.idUser;
            AppID = obj.AppIDUser;

            if (!string.IsNullOrEmpty(obj.idUser.ToString()))
            {

                var datos = new User
                {
                    NameUser = obj.NameUser,
                    nCountUser = obj.nCountUser,
                    carreraUser = obj.carreraUser,
                    emailUser = obj.emailUser,
                    telUser = obj.telUser,
                    birthdateUser = obj.birthdateUser,
                    fotoUser = obj.fotoUser,
                };

                var detalles = new SolicitudAlumnos(id, AppID);
                detalles.BindingContext = datos;
                await Navigation.PushAsync(detalles);
            }
        }

        private async void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (search.Text == "")
            {
                string url = string.Format("http://192.168.1.35/WSXamarin/users/all/{0}", App.Current.Properties["Id"].ToString());

                ConsultManager manager = new ConsultManager();
                var res = await manager.getUsers(url);

                if (res != null)
                {
                    ListStudent.ItemsSource = res;
                }
            }
            else
            {
                string url = string.Format("http://192.168.1.35/WSXamarin/users/searchuser/{0}/{1}", search.Text, App.Current.Properties["Id"].ToString());

                ConsultManager manager = new ConsultManager();
                var res = await manager.getUsers(url);

                if (res != null)
                {
                    ListStudent.ItemsSource = res;
                }
            }
        }
    }
}