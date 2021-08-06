using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MiPerfil : ContentPage
    {
        public MiPerfil()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            UserDialogs.Instance.ShowLoading("Cargando");


            nombre.Text = App.Current.Properties["Name"].ToString();
            profile.Source = App.Current.Properties["Path"].ToString();
            cuenta.Text = App.Current.Properties["Account"].ToString();
            carrera.Text = App.Current.Properties["Carrera"].ToString();
            telefono.Text = App.Current.Properties["Telephone"].ToString();
            correo.Text = App.Current.Properties["Email"].ToString();
            fecha.Text = App.Current.Properties["Birthday"].ToString();

            UserDialogs.Instance.HideLoading();
        }

        private async void imageEditar_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditarPerfil());
        }

        private async void EditarButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditarPerfil());
        }

        private async void imageGrupo_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MisGrupos());
        }

        private async  void GruposButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MisGrupos());
        }

        private async void imgAmigos_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaAmigos());
        }

        private async void amigosButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaAmigos());
        }

        private async void CerrarSesion_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Alerta", "¿Cerrar Sesión?", "Yes", "No");
            if (answer == true)
            {
                App.Current.Logout();
            }
            else
            {

            }
            
        }
    }
}