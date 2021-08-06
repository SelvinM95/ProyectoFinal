using Acr.UserDialogs;
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
    public partial class ArchivosGrupos : ContentPage
    {
         
        public ArchivosGrupos()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            UserDialogs.Instance.ShowLoading("Cargando");

            string url = string.Format("http://3.15.208.156/WSXamarin/files/getgroupfiles/{0}", App.Current.Properties["idGroup"]);
            ConsultManager manager = new ConsultManager();
            var res = await manager.getFile(url);

            if (res != null)
            {
                ListStudent.ItemsSource = res;
            }
            UserDialogs.Instance.HideLoading();
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

        private  void todoArchivoButton_Clicked(object sender, EventArgs e)
        {
          
        }

        private  void imagetodoArchivo_Tapped(object sender, EventArgs e)
        {
            
        }
    }
}