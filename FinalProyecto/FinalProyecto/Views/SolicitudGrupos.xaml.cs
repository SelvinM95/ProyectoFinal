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
    public partial class SolicitudGrupos : ContentPage
    {
        string Id;

        public SolicitudGrupos(string id)
        {
            InitializeComponent();
            Id = id;
        }

        protected async override void OnAppearing()
        {
            string url = string.Format("http://3.15.208.156/WSXamarin/groups/members/"+Id);
            ConsultManager manager = new ConsultManager();
            var res = await manager.getUsers(url);

            if (res != null)
            {
                ListStudent.ItemsSource = res;
            }
        }


        private async void unirme_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "Ha presionado este boton", "OK");
        }
    }
}