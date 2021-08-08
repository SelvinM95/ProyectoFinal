using Acr.UserDialogs;
using FinalProyecto.Classes;
using FinalProyecto.Models;
using Plugin.DownloadManager;
using Plugin.DownloadManager.Abstractions;
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
    public partial class MisArchivosList : ContentPage
    {
         
        public IDownloadFile File;
        bool isDownloading = true;

        public MisArchivosList()
        {
            InitializeComponent();

        CrossDownloadManager.Current.CollectionChanged += (sender, e) =>
                System.Diagnostics.Debug.WriteLine(
                    "[DownloadManager]" + e.Action +
                    " -> New items:" + (e.NewItems?.Count ?? 0) +
                    " at " + e.NewStartingIndex +
                    " || Old items: " + (e.OldItems?.Count ?? 0) +
                    " at " + e.OldStartingIndex
                    );
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            UserDialogs.Instance.ShowLoading("Cargando");

            string url = string.Format("http://3.15.208.156/WSXamarin/files/getownfiles/{0}/{1}", "Archivos", App.Current.Properties["Id"]);
            ConsultManager manager = new ConsultManager();
            var res = await manager.getFile(url);

            if (res != null)
            {
                ListStudent.ItemsSource = res;
            }
            UserDialogs.Instance.HideLoading();
        }

        public async void DownloadFile(String FileName)
        {
            await Task.Yield();
            // await Navigation.PushPopupAsync(new DownLoadingPage());
            await Task.Run(() =>
            {
                var downloadManager = CrossDownloadManager.Current;
                var file = downloadManager.CreateDownloadFile(FileName);
                downloadManager.Start(file, true);

                while (isDownloading)
                {
                    isDownloading = IsDownloading(file);
                }

            });

            if (!isDownloading)
            {
                await DisplayAlert("Estatus de Descarga", "Archivo descargado", "OK");
            }

        }

        public bool IsDownloading(IDownloadFile File)
        {
            if (File == null) return false;

            switch (File.Status)
            {
                case DownloadFileStatus.INITIALIZED:
                case DownloadFileStatus.PAUSED:
                case DownloadFileStatus.PENDING:
                case DownloadFileStatus.RUNNING:
                    return true;

                case DownloadFileStatus.COMPLETED:
                case DownloadFileStatus.CANCELED:
                case DownloadFileStatus.FAILED:
                    return false;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void AbortDownloading()
        {
            CrossDownloadManager.Current.Abort(File);
        }

        private async void ListStudent_ItemTapped(object sender, ItemTappedEventArgs e)
        { 
            var obj = (Archivo)e.Item;

            bool answer = await DisplayAlert("Alerta", "¿Descargar Archivos?", "Yes", "No");
            if (answer == true)
            {
                DownloadFile(obj.filePath.ToString());
            }
            else
            {

            }
           
        }
    }
}