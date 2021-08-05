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
    public partial class MisGruposCreados : ContentPage
    {
        string nombre;
        public MisGruposCreados()
        {
            InitializeComponent();
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
                    await DisplayAlert("Resultado", nombre.ToString(), "OK");
                }
                else
                {
                    await DisplayAlert("Resultado", "Canceló la creación", "OK");
                }

                
            }
        }
    }
}