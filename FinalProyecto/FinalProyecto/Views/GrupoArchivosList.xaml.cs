﻿using Acr.UserDialogs;
using FinalProyecto.Classes;
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
    public partial class GrupoArchivosList : ContentPage
    {
        byte[] File;
        
        public GrupoArchivosList()
        {
            InitializeComponent(); 
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            UserDialogs.Instance.ShowLoading("Cargando");

            string url = string.Format("http://3.15.208.156/WSXamarin/files/getfiles/{0}/{1}", "Archivos", App.Current.Properties["idGroup"]);
            ConsultManager manager = new ConsultManager();
            var res = await manager.getFile(url);

            if (res != null)
            {
                ListStudent.ItemsSource = res;
            }
            UserDialogs.Instance.HideLoading();
        }


        private async  void uploaded_Clicked(object sender, EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("Subiendo Archivo");
            var customFileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    {
                        DevicePlatform.Android, new[] {
                            "application/pdf",
                            "application/rar",
                            "application/zip",
                            "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                            "application/vnd.openxmlformats-officedocument.presentationml.presentation"
                        }
                    }
                });

            var options = new PickOptions
            {
                FileTypes = customFileType,
            };

            
            var file = await Xamarin.Essentials.FilePicker.PickAsync(options);

            if (file == null)
            {
                UserDialogs.Instance.HideLoading();
            }
            else
            {
                String extension = Path.GetExtension(file.FullPath);
 
                File = System.IO.File.ReadAllBytes(file.FullPath);
                String baseFile = Convert.ToBase64String(File);

                var archivo = new Archivo
                {
                    idUser = Convert.ToInt32(App.Current.Properties["Id"].ToString()),
                    idTeam = Convert.ToInt32(App.Current.Properties["idGroup"].ToString()),
                    teamName = App.Current.Properties["nameGroup"].ToString(),
                    filePath = baseFile,
                    fileType = "Archivos",
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
                    recargar(); 
                }
            }

        }

        public async void recargar()
        {
            UserDialogs.Instance.ShowLoading("Cargando");

            string url = string.Format("http://3.15.208.156/WSXamarin/files/getfiles/{0}/{1}", "Archivos", App.Current.Properties["idGroup"]);
            ConsultManager manager = new ConsultManager();
            var res = await manager.getFile(url);

            if (res != null)
            {
                ListStudent.ItemsSource = res;
            }
            UserDialogs.Instance.HideLoading();
        }
    }
}