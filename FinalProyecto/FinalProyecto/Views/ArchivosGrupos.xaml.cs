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
    public partial class ArchivosGrupos : ContentPage
    {
        public ObservableCollection<Card> ListDetails { get; set; }
        public ArchivosGrupos()
        {
            InitializeComponent();
            ListDetails = new ObservableCollection<Card>
            {
                  new Card{ImgIcon="profileUser.png", Name= "BERET - DIE...160K).mp3", Fecha = "6 abr. 2021" },
                  new Card{ImgIcon="profileUser.png", Name= "BERET - DIE...160K).mp3", Fecha = "6 abr. 2021" },
                  new Card{ImgIcon="profileUser.png", Name= "BERET - DIE...160K).mp3", Fecha = "6 abr. 2021" },
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

        private async void AudioButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GrupoAudiosList());
        }

        private async void imageAudio_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GrupoAudiosList());
        }

        private async void archivos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GrupoArchivosList());
        }

        private async  void imageFile_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GrupoArchivosList());
        }

        private async void imagenes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GrupoImagenesList());
        }

        private async void imagePicture_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GrupoImagenesList());
        }

        private async void videos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GrupoVideoList());
        }

        private async void imagevideo_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GrupoVideoList());
        }

        private async void todoArchivoButton_Clicked(object sender, EventArgs e)
        {
          
        }

        private async void imagetodoArchivo_Tapped(object sender, EventArgs e)
        {
            
        }
    }
}