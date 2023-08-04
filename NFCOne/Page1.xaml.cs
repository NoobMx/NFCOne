using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTTPupt;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFCOne
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        PeticionHTTP peticion = new PeticionHTTP("https://nfc.maiysal.com");
        public String datoNfcPublic;
        public Page1(string datoNfc)
        {
            InitializeComponent();
            lblTagIdHexII.Text = datoNfc;
            datoNfcPublic = datoNfc;
            // Suscribirse al evento NFCDetected
            //MessagingCenter.Subscribe<App, string>(this, "NFCDetectado", (sender, tagIdHex) =>
            //{
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        lblTagIdHexII.Text = tagIdHex;
            //    });
            //});
        }

       
        private void btnEviarRegistro_Clicked(object sender, EventArgs e)
        {
            
                Usuario usuario = new Usuario
                {
                    NumeroTarjeta = datoNfcPublic,
                    //NumeroTarjeta = "C5DD2577",
                    NombreCompleto = txtNombre.Text
                };

                String enviarJson = JsonConvertidor.Objeto_Json(usuario);
                peticion.PedirComunicacion("Usuario/agregar", MetodoHTTP.POST, TipoContenido.JSON);
                peticion.enviarDatos(enviarJson);
            
            
            String recibirjson = peticion.ObtenerJson();
        }





        //protected override void OnDisappearing()
        //{
        //    base.OnDisappearing();

        //    // Darse de baja del evento al salir de la página
        //    MessagingCenter.Unsubscribe<App, string>(this, "NFCDetectado");
        //}


    }
}