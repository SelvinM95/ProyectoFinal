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
    public partial class MisArchivosGeneralList : ContentPage
    {
        public ObservableCollection<Card> ListDetails { get; set; }
        public MisArchivosGeneralList()
        {
            InitializeComponent();
            ListDetails = new ObservableCollection<Card>
            {
                  new Card{ImgIcon="profileUser.png", Name= "Aldenis Eduardo Miranda Cisnado"}
            };
            BindingContext = this;
        }

        public class Card
        {
            public string ImgIcon { get; set; }
            public string Name { get; set; }

        }
    }
}