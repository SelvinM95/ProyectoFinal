using MediaManager;
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
    public partial class VideoPlayGrupos : ContentPage
    {
        public VideoPlayGrupos()
        {
            InitializeComponent();
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

        }
    }
}