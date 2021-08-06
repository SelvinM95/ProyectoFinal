using Acr.UserDialogs;
using FinalProyecto.Classes;
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
    public partial class MisGrupos : ContentPage
    {
        public MisGrupos()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            UserDialogs.Instance.ShowLoading("Cargando");
            string url = string.Format("http://3.15.208.156/WSXamarin/groups/mygroups/" + App.Current.Properties["Id"].ToString());
            ConsultManager manager = new ConsultManager();
            var res = await manager.getGroups(url);

            if (res != null)
            {
                ListStudent.ItemsSource = res;
            }
            UserDialogs.Instance.HideLoading();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new ArchivosGrupos());
        }

        private async void NuevoGrupo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MisGruposCreados());
        } 
    }
}