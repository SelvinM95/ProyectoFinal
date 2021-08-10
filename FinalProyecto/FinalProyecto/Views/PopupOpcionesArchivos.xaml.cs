using Plugin.DownloadManager;
using Plugin.DownloadManager.Abstractions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupOpcionesArchivos : PopupPage
    {
        String Name;
        String Path;
        String id;

        public IDownloadFile File;
        bool isDownloading = true;

        public PopupOpcionesArchivos(string filename, string filepath, string idfile)
        {
            InitializeComponent();

            Name = filename;
            Path = filepath;
            id = idfile;

            CrossDownloadManager.Current.CollectionChanged += (sender, e) =>
           System.Diagnostics.Debug.WriteLine(
               "[DownloadManager]" + e.Action +
               " -> New items:" + (e.NewItems?.Count ?? 0) +
               " at " + e.NewStartingIndex +
               " || Old items: " + (e.OldItems?.Count ?? 0) +
               " at " + e.OldStartingIndex
               );
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

        private async void descargar_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Alerta", "¿Descargar Archivos?", "Yes", "No");
            if (answer == true)
            {
                DownloadFile(Path);
            }
            else
            {

            }
        }

        private async void eliminar_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Alerta", "¿Eliminar Archivo?", "Yes", "No");
            if (answer == true)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://3.15.208.156");
                string url = string.Format("/WSXamarin/files/delete/{0}", id);
                var response = await client.GetAsync(url);
                var result = response.Content.ReadAsStringAsync().Result;

                if (string.IsNullOrEmpty(result) || result == "null" || !response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Alerta", "Error al Eliminar Archivo", "OK"); 
                    
                }
                else
                {
                    await DisplayAlert("Alerta", "Archivo Eliminado", "cerrar");
                    await Navigation.PopAsync();
                    await PopupNavigation.Instance.PopAsync();
                   
                }
            }
            else
            {

            }
        }
    }
}