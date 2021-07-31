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
    public partial class Grupos : ContentPage
    {
        public Grupos()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            string url = string.Format("http://192.168.1.42/WSXamarin/groups/all");
            ConsultManager manager = new ConsultManager();
            var res = await manager.getGroups(url);

            if (res != null)
            {
                ListGroup.ItemsSource = res;
            }
        }

 

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

        }

        private async void ToolbarGrupos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MisGrupos());
        }

        private async void ListGroup_ItemTapped(object sender, ItemTappedEventArgs e)
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

                var detalles = new SolicitudGrupos(obj.idTeam.ToString());
                detalles.BindingContext = datos;
                await Navigation.PushAsync(detalles);
            } 
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (search.Text == "")
            {
                String URL = "http://192.168.1.42/WSXamarin/groups/all";

                ConsultManager manager = new ConsultManager();
                var res = await manager.getGroups(URL);

                if (res != null)
                {
                    ListGroup.ItemsSource = res;
                }
            }
            else
            {

                String URL = "http://192.168.1.42/WSXamarin/groups/searchgroup/" + search.Text;

                ConsultManager manager = new ConsultManager();
                var res = await manager.getGroups(URL);

                if (res != null)
                {
                    ListGroup.ItemsSource = res;
                }
            }
        }
    }
}