using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FinalProyecto.Classes
{
    public class LoginModalPage : CarouselPage
    {
        ContentPage login;

        public LoginModalPage(ILoginManager ilm)
        {
            login = new LoginAndRegister(ilm);

            this.Children.Add(login);
            MessagingCenter.Subscribe<ContentPage>(this, "Login", (sender) =>
            {
                this.SelectedItem = login;
            });
        }
    }
}
