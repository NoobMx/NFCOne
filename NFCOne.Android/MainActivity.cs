using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Nfc;
using Android.Content;
using Xamarin.Forms;

namespace NFCOne.Droid
{
    [Activity(Label = "NFCOne", Icon = "@mipmap/ic_nfc", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    [IntentFilter(new[] { NfcAdapter.ActionTagDiscovered }, Categories = new[] { Intent.CategoryDefault})]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private NfcAdapter nfcAdapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            //
            nfcAdapter = NfcAdapter.GetDefaultAdapter(this);

            if (nfcAdapter == null)
            {
                mostrarAlertaNS();
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

                //

        protected override void OnResume()
        {
            base.OnResume();

            if (nfcAdapter != null)
            {
                var intent = new Intent(this, this.GetType()).AddFlags(ActivityFlags.SingleTop);
                var pendingIntent = PendingIntent.GetActivity(this, 0, intent, 0);
                nfcAdapter.EnableForegroundDispatch(this, pendingIntent, null, null);
            }
            
        }

        protected override void OnPause()
        {
            base.OnPause();
            if (nfcAdapter != null)
            {
                nfcAdapter.DisableForegroundDispatch(this);
            }
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);

            if (NfcAdapter.ActionTagDiscovered.Equals(intent.Action))
            {
                // Obtener la etiqueta NFC
                var tag = (Tag)intent.GetParcelableExtra(NfcAdapter.ExtraTag);

                if (tag != null)
                {
                    // Obtener la ID de la etiqueta NFC en bytes
                    byte[] tagId = tag.GetId();

                    // Convertir la ID en un string hexadecimal
                    string tagIdHex = BitConverter.ToString(tagId).Replace("-", "");

                    // Enviar el ID de la tarjeta NFC a través de MessagingCenter
                    MessagingCenter.Send<App, string>((App)Xamarin.Forms.Application.Current, "NFCDetectado", tagIdHex);

                    // Mostrar la ID de la etiqueta NFC en un cuadro de diálogo de alerta
                    //mostrarAlertaTag(tagIdHex);
                }
            }
        }

        private void mostrarAlertaNS()
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("NFC no compatible");
            alert.SetMessage("NFC no es compatible en este dispositivo.");
            alert.SetPositiveButton("OK", (senderAlert, args) => { });
            Dialog dialog = alert.Create();
            dialog.Show();
        }

        private void mostrarAlertaTag(string tagIdHex)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("ID de la etiqueta NFC");
            alert.SetMessage(tagIdHex);
            alert.SetPositiveButton("OK", (senderAlert, args) => { });
            Dialog dialog = alert.Create();
            dialog.Show();
        }
    }
}