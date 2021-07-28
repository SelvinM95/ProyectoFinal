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
    public partial class MisGrupos : ContentPage
    {
        public ObservableCollection<Card> ListDetails { get; set; }
        public MisGrupos()
        {
            InitializeComponent();
            ListDetails = new ObservableCollection<Card>
            {
                new Card{  Name= "Programación Movil II", Tutor = "Ing. Ricardo Lagos"},
                 new Card{  Name= "Computación Grafica-Visual", Tutor = "Ing. Cristian Escobar" },
                  new Card{  Name= "Internet de las Cosas (IoT)", Tutor = "Ing. Aramis Diaz" },
                  new Card{  Name= "Ecuaciones Diferenciales", Tutor = "Ing. Karla Paz" }
            };
            BindingContext = this;
        }

        public class Card
        { 
            public string Name { get; set; }

            public string Tutor { get; set; }

        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new ArchivosGrupos());
        }

        private async void NuevoGrupo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NuevoGrupo());
        } 
    }
}