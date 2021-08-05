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
    public partial class NuevoGrupo : ContentPage
    {
        string result;
        public NuevoGrupo()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            string url = string.Format("http://3.15.208.156/WSXamarin/users/myfriends/{0}", App.Current.Properties["Id"].ToString());
            ConsultManager manager = new ConsultManager();
            var res = await manager.getUsers(url);

            if (res != null)
            {
                ListStudent.ItemsSource = res;
            }
        }

        private void ListStudent_ItemTapped(object sender, ItemTappedEventArgs e)
        { 
        } 
        private  void checkItem_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            
        }

        private void unirme_Clicked(object sender, EventArgs e)
        {
           
        }
    }

    }