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
    public partial class NuevoGrupo : ContentPage
    {
        public ObservableCollection<Card> ListDetails { get; set; }
        public NuevoGrupo()
        {
            InitializeComponent();
            ListDetails = new ObservableCollection<Card>
            {
                new Card{  Name= "Selvin Onan Maldonado Reyes", Correo = "correo@gmail.com", Cuenta = "201610040226"},
                 new Card{  Name= "Jerry Isai Garcia Galeas", Correo = "correo@gmail.com", Cuenta = "201610040226"},
                  new Card{  Name= "Aldenis Eduardo Miranda Cisnado", Correo = "correo@gmail.com", Cuenta = "201610040226"},
                  new Card{  Name= "Marvin Alberto Pineda Trosty", Correo = "correo@gmail.com", Cuenta = "201610040226"}
            };
            BindingContext = this;
        }

        public class Card
        {
            public string Name { get; set; }

            public string Correo { get; set; }

            public string Cuenta { get; set; }

        }
    }
}