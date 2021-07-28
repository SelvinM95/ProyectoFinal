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
        public ObservableCollection<Card> ListDetails { get; set; }
        public ListaAmigos()
        {
            InitializeComponent();
            ListDetails = new ObservableCollection<Card>
            {
                new Card{ Name= "Selvin Onan Maldonado Reyes", Correo = "correo@gmail.com", Cuenta = "201610040226"},
                 new Card{ Name= "Jerry Isaí Garcia Canelas", Correo = "correo@gmail.com", Cuenta = "201610040226"},
                  new Card{ Name= "Aldenis Eduardo Miranda Cisnado", Correo = "correo@gmail.com", Cuenta = "201610040226"}
            };
            BindingContext = this;
        }

        public class Card
        {
            public string Name { get; set; }

            public string Correo { get; set; }

            public string Cuenta { get; set; }

        }

        private async void ListStudent_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new InformacionAmistad());
        }

        private void ListStudent_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private async void ToolbarSolicitud_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MisSolicitudes());
        }
    }
}