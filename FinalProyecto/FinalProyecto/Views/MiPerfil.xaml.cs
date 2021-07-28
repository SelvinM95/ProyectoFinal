using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private void CerrarSesion_Clicked(object sender, EventArgs e)
        {

        }
    }
}