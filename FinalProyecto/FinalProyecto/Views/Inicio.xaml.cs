using FinalProyecto.Classes;
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
        public Inicio()
        {
            InitializeComponent(); 
        }


        protected async override void OnAppearing()
        {
            string url = string.Format("http://192.168.1.42/WSXamarin/users/all/{0}", App.Current.Properties["Id"].ToString());
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
            await Navigation.PushAsync(new SolicitudAlumnos());
        }
    }
}