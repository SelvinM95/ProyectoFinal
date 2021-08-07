using MediaManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AudioPlayGrupos : ContentPage
    {
        String Name;
        String Path;

        public AudioPlayGrupos(string filename, string filepath)
        {
            InitializeComponent();
            Name = filename;
            Path = filepath;
        }

        protected override bool OnBackButtonPressed()
        {
            if (true)
            {
                CrossMediaManager.Current.Stop();
                CrossMediaManager.Current.Notification.ShowPlayPauseControls = false;
                Navigation.PopAsync();
                return true;

            }
        }

        private void imageDescargar_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(Path));
        }
    }
}