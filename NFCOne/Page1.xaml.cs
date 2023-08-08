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

       
        private async void btnEviarRegistro_Clicked(object sender, EventArgs e)
        {
<<<<<<< HEAD
            String nombreCompleto = txtNombre.Text;
            
=======
            string nombre = txtNombre.Text;

            if (string.IsNullOrEmpty(nombre))
            {
                // Mostrar una alerta o mensaje indicando que el campo está vacío
                DisplayAlert("Campo Vacío...", "Debe ingresar un nombre.", "Aceptar");
            }
            else
            {
>>>>>>> 3bfcfc683aa7bb7bc16fc1182028b53730a35cf9
                Usuario usuario = new Usuario
                {
                    NumeroTarjeta = datoNfcPublic,
                    NombreCompleto = txtNombre.Text
                };

            if (string.IsNullOrEmpty(nombreCompleto))
            {
                await DisplayAlert("Alerta", "El campo de nombre no puede estar vacío", "OK");
            }
            else
            {
                                String enviarJson = JsonConvertidor.Objeto_Json(usuario);
                peticion.PedirComunicacion("Usuario/agregar", MetodoHTTP.POST, TipoContenido.JSON);
                peticion.enviarDatos(enviarJson);
<<<<<<< HEAD
                //String recibirjson = peticion.ObtenerJson();
                string recibirjson = await Task.Run(() => peticion.ObtenerJson());
                if (!string.IsNullOrEmpty(recibirjson))
                {
                    await DisplayAlert("Éxito", "El formulario se ha enviado correctamente", "OK");
                }
                else
                {
                    // La respuesta está vacía, lo que indica un problema en la inserción en la base de datos
                    await DisplayAlert("Error", "Hubo un problema al enviar el formulario", "OK");
                }

               
            }
=======


                String recibirjson = peticion.ObtenerJson();
            }      
>>>>>>> 3bfcfc683aa7bb7bc16fc1182028b53730a35cf9
        }





        //protected override void OnDisappearing()
        //{
        //    base.OnDisappearing();

        //    // Darse de baja del evento al salir de la página
        //    MessagingCenter.Unsubscribe<App, string>(this, "NFCDetectado");
        //}


    }
}