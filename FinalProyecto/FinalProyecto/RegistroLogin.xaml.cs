using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProyecto
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroLogin : ContentPage
    {
        public RegistroLogin()
        {
            InitializeComponent();
        }

        private async void guardar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CodigoLogin());
        }
    }
}