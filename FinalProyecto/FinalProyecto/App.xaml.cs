
using FinalProyecto.Classes;
using FinalProyecto.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProyecto
{
    public partial class App : Application, ILoginManager
    {
        static ILoginManager loginManager;
        public static new App Current;
        public static int val;

        public App()
        {
            InitializeComponent();

            Current = this;
            var isLoggedIn = Properties.ContainsKey("IsLoggedIn") ? (bool)Properties["IsLoggedIn"] : false;
            MainPage = isLoggedIn ? new AppShell() : (Page)new LoginModalPage(this);
        }

        public void ShowMainPage()
        {
            MainPage = new AppShell();
        }

        public void ShowRegisterPage()
        {
            MainPage = new NavigationPage(new RegistroLogin());
        }

        public void ShowRecoverPage()
        {
            MainPage = new RecuperarPassLogin();
        }

        public void Logout()
        {
            Properties["IsLoggedIn"] = false;
            MainPage = new LoginModalPage(this);
        }

        public void ReturnToLogin()
        {
            MainPage = new LoginModalPage(this);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
