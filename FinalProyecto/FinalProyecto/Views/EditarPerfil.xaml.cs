using FinalProyecto.Models;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarPerfil : ContentPage
    {
        byte[] image;

        public EditarPerfil()
        {
            InitializeComponent();

            nombre.Text = App.Current.Properties["Name"].ToString();
            profile.Source = App.Current.Properties["Path"].ToString();
            cuenta.Text = App.Current.Properties["Account"].ToString();
            carrera.Text = App.Current.Properties["Carrera"].ToString();
            date.Text = App.Current.Properties["Birthday"].ToString();
            tel.Text = App.Current.Properties["Telephone"].ToString();
            correo.Text = App.Current.Properties["Email"].ToString();
        }

        private async void EditFtos_Tapped(object sender, EventArgs e)
        {
            if (CrossMedia.Current.IsTakePhotoSupported)
            {
                var mediaOption = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Large,
                    CompressionQuality = 75,
                };

                var imagen = await CrossMedia.Current.PickPhotoAsync(mediaOption);

                image = GetImageBytes(imagen);

                if (imagen != null)
                {
                    profile.Source = ImageSource.FromStream(() =>
                    {
                        var stream = imagen.GetStream();
                        imagen.Dispose();
                        return stream;
                    });
                }
            }
        }

        private byte[] GetImageBytes(MediaFile file)
        {
            byte[] ImageBytes;
            using (var memoryStream = new MemoryStream())
            {
                file.GetStream().CopyTo(memoryStream);
                ImageBytes = memoryStream.ToArray();
            }
            return ImageBytes;
        }

        private async void CambioPass_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CambioPass());
        }

        private async void guardar_Clicked(object sender, EventArgs e)
        {
            String base64 = Convert.ToBase64String(image);

            var user = new User
            {
                NameUser = App.Current.Properties["Name"].ToString(),
                nCountUser = App.Current.Properties["Account"].ToString(),
                telUser = tel.Text,
                fotoUser = base64,
                emailUser = correo.Text,
                birthdateUser = date.Text,
                carreraUser = carrera.Text
            };

            var request = new HttpRequestMessage();
            Uri RequestUri = new Uri("http://192.168.1.35/WSXamarin/users/update/" + App.Current.Properties["Id"].ToString());

            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(user);
            var contentJSON = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri, contentJSON);
            var result = response.Content.ReadAsStringAsync().Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var res = JsonConvert.DeserializeObject<User>(result);

                App.Current.Properties["Name"] = "";
                App.Current.Properties["Account"] = "";
                App.Current.Properties["Telephone"] = "";
                App.Current.Properties["Carrera"] = "";
                App.Current.Properties["Email"] = "";
                App.Current.Properties["Birthday"] = "";
                App.Current.Properties["Path"] = "";

                App.Current.Properties["Name"] = res.NameUser;
                App.Current.Properties["Account"] = res.nCountUser;
                App.Current.Properties["Telephone"] = res.telUser;
                App.Current.Properties["Carrera"] = res.carreraUser;
                App.Current.Properties["Email"] = res.emailUser;
                App.Current.Properties["Birthday"] = res.birthdateUser;
                App.Current.Properties["Path"] = res.fotoUser;

                await DisplayAlert("Datos", "Datos Actualizados", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}