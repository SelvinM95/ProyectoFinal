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
    public partial class GrupoVideoList : ContentPage
    {
        public ObservableCollection<Card> ListDetails { get; set; }
        public GrupoVideoList()
        {
            InitializeComponent();
            ListDetails = new ObservableCollection<Card>
            {
                  new Card{ImgIcon="profileUser.png", Name= "BERET - DIE...160K).mp3", Fecha = "6 abr. 2021" },
                  new Card{ImgIcon="profileUser.png", Name= "BERET - DIE...160K).mp3", Fecha = "6 abr. 2021" }
            };
            BindingContext = this;
        }

        public class Card
        {
            public string ImgIcon { get; set; }
            public string Name { get; set; }

            public string Fecha { get; set; }

        }
    }
}