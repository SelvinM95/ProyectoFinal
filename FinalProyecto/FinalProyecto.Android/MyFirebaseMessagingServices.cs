using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Media;
using Android.Util;
using Firebase.Messaging;
using Xamarin.Essentials;

namespace FinalProyecto.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        const string TAG = "MyFirebaseMsgService";
        AndroidNotificationManager androidNotification = new AndroidNotificationManager();
        public override void OnMessageReceived(RemoteMessage message)
        {
            IDictionary<string, string> MensajeData = message.Data;

            string Titulo = MensajeData["notiTitle"];
            string SubTitulo = MensajeData["notiBody"];

            androidNotification.CrearNotificacionLocal(Titulo, SubTitulo);
        }

        public override void OnNewToken(string token)
        {
            base.OnNewToken(token);

            Preferences.Set("TokenApp", token);
        }
    }
}