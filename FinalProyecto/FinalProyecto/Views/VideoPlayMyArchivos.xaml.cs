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
    public partial class VideoPlayMyArchivos : ContentPage
    {
        public VideoPlayMyArchivos()
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

        private void imageEliminar_Tapped(object sender, EventArgs e)
        {

        }
    }
}