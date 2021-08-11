using Acr.UserDialogs;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProyecto
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroLogin : ContentPage
    {
        byte[] image;

        public RegistroLogin()
        {
            InitializeComponent();
        }

        private async void guardar_Clicked(object sender, EventArgs e)
        {
            if (profile.Source == null || String.IsNullOrEmpty(nombre.Text) || String.IsNullOrEmpty(correo.Text) || String.IsNullOrEmpty(ncuenta.Text) || String.IsNullOrEmpty(Carrera.Text))
            {
                await DisplayAlert("Alerta", "Porfavor llene todos los campos", "Ok");
            }
            else
            {
                Random r = new Random();
                int randNum = r.Next(1000000);
                String sixDigitNumber = randNum.ToString("D6");

                String TempPassword = GeneratePassword(10);
                String base64 = Convert.ToBase64String(image);
                String name = nombre.Text;
                String ncount = ncuenta.Text;
                String tel = telefono.Text;
                String email = correo.Text;
                String birtdate = date.Date.ToShortDateString();
                String carrera = Carrera.Text;

                UserDialogs.Instance.ShowLoading("Cargando");
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://3.15.208.156");
                string url = string.Format("/WSXamarin/users/verification/{0}/{1}/{2}", email, sixDigitNumber, TempPassword);
                var response = await client.GetAsync(url);

                await Navigation.PushAsync(new CodigoLogin(TempPassword, sixDigitNumber, base64, name, ncount, tel, email, birtdate, carrera));
                UserDialogs.Instance.HideLoading();
            }

            
        }

        private async void AddFoto_Clicked(object sender, EventArgs e)
        {
            if (CrossMedia.Current.IsTakePhotoSupported)
            {
                var mediaOption = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Large,
                    CompressionQuality = 70,
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

        protected override bool OnBackButtonPressed()
        {
            if (true)
            {
                Application.Current.MainPage = new LoginAndRegister(App.Current);
                return true;

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

        public static string GeneratePassword(int longitud)
        {
            string contraseña = string.Empty;
            string[] letras = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
            Random EleccionAleatoria = new Random();

            for (int i = 0; i < longitud; i++)
            {
                int LetraAleatoria = EleccionAleatoria.Next(0, 100);
                int NumeroAleatorio = EleccionAleatoria.Next(0, 9);

                if (LetraAleatoria < letras.Length)
                {
                    contraseña += letras[LetraAleatoria];
                }
                else
                {
                    contraseña += NumeroAleatorio.ToString();
                }
            }
            return contraseña;
        }
    }
}