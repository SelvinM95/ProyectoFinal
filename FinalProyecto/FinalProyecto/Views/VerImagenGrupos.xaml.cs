using Plugin.DownloadManager;
using Plugin.DownloadManager.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerImagenGrupos : ContentPage
    { 
        String Name;
        String Path;
        String id;

        public IDownloadFile File;
        bool isDownloading = true;

        public VerImagenGrupos(string filename, string filepath, string idfile)
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

        private async void imageDescargar_Tapped(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Alerta", "¿Descargar Archivo?", "Yes", "No");
            if (answer == true)
            {
                DownloadFile(Path);
            }
            else
            {

            }
        }

        private void imageEliminar_Tapped(object sender, EventArgs e)
        {

        }
    }
}