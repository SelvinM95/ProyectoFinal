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
    public partial class EditarPerfil : ContentPage
    {
        public EditarPerfil()
        {
            InitializeComponent();
        }

        private async void EditFtos_Tapped(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "Ha presionado la foto", "OK");
        }

        private async void CambioPass_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CambioPass());
        }
    }
}