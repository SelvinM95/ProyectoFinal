using Acr.UserDialogs;
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
    public partial class ListaAmigos : ContentPage
    {
        public ListaAmigos()
        {
            InitializeComponent();
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

        private async void ListStudent_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            search.Text = "";

            var obj = (User)e.Item;

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

                var detalles = new InformacionAmistad();
                detalles.BindingContext = datos;
                await Navigation.PushAsync(detalles);
            }
        }

        private async void ToolbarSolicitud_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MisSolicitudes());
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
                string url = string.Format("http://3.15.208.156/WSXamarin/users/searchfriend/{0}/{1}", search.Text , App.Current.Properties["Id"].ToString());
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