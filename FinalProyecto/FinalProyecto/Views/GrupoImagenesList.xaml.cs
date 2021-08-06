using Acr.UserDialogs;
using FinalProyecto.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GrupoImagenesList : ContentPage
    {
        byte[] File;
        public ObservableCollection<Card> ListDetails { get; set; }
        public GrupoImagenesList()
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

        private async void uploaded_Clicked(object sender, EventArgs e)
        {
            var customFileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    {
                        DevicePlatform.Android, new[] {
                            "image/png",
                            "image/jpeg",
                            "image/gif"
                        }
                    }
                });

            var options = new PickOptions
            {
                FileTypes = customFileType,
            };

            UserDialogs.Instance.ShowLoading("Subiendo Archivo");
            var file = await Xamarin.Essentials.FilePicker.PickAsync(options);

            if (file == null)
                return;


            String extension = Path.GetExtension(file.FullPath);

            File = System.IO.File.ReadAllBytes(file.FullPath);
            String baseFile = Convert.ToBase64String(File);



            var archivo = new Archivo
            {
                idUser = Convert.ToInt32(App.Current.Properties["Id"].ToString()),
                idTeam = Convert.ToInt32(App.Current.Properties["idGroup"].ToString()),
                teamName = App.Current.Properties["nameGroup"].ToString(),
                filePath = baseFile,
                fileType = "Imagenes",
                fileExt = extension,
                uploadDate = DateTime.Now
            };

            var request = new HttpRequestMessage();

            Uri RequestUri = new Uri("http://3.15.208.156/WSXamarin/files/add");
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(archivo);
            var contentJSON = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri, contentJSON);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                UserDialogs.Instance.HideLoading();
                await DisplayAlert("Datos", "Archivo Subido Correctamente", "OK");

            }
        }
    }
}