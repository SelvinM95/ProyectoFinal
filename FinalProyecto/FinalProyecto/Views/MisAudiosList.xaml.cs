using Acr.UserDialogs;
using FinalProyecto.Classes;
using FinalProyecto.Models;
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
    public partial class MisAudiosList : ContentPage
    {
         
        public MisAudiosList()
        {
            InitializeComponent(); 
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            UserDialogs.Instance.ShowLoading("Cargando");

            string url = string.Format("http://3.15.208.156/WSXamarin/files/getownfiles/{0}/{1}", "Audios", App.Current.Properties["Id"]);
            ConsultManager manager = new ConsultManager();
            var res = await manager.getFile(url);

            if (res != null)
            {
                ListStudent.ItemsSource = res;
            }
            UserDialogs.Instance.HideLoading();
        }

        private async void ListStudent_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var obj = (Archivo)e.Item;

            var detail = new Archivo
            {
                filePath = obj.filePath,
                fileName = obj.fileName
            };

            var detalles = new AudioPlayMyArchivos(obj.fileName.ToString(), obj.filePath.ToString(), obj.idFile.ToString());
            detalles.BindingContext = detail;
            await Navigation.PushAsync(detalles);
        }
    }
}