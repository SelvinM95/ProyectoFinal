using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProyecto.Classes
{
    public interface ILoginManager
    {
        void ShowRecoverPage();
        void ShowRegisterPage();
        void ReturnToLogin();
        void ShowMainPage();
        void Logout();
    }
}
