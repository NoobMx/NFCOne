using HTTPupt;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFCOne
{
    public partial class MainPage : ContentPage
    {
        PeticionHTTP peticion = new PeticionHTTP("https://nfc.maiysal.com");
        public MainPage()
        {
            InitializeComponent();

            // Suscribirse al evento NFCDetected
            MessagingCenter.Subscribe<App, string>(this, "NFCDetectado", (sender, tagIdHex) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    lblTagIdHex.Text = tagIdHex;

                    //Usuario usuario = new Usuario
                    //{
                    //    NumeroTarjeta = lblTagIdHex.Text,
                        
                    //};


                    
                    peticion.PedirComunicacion("Usuario/obtener/"+ tagIdHex, MetodoHTTP.GET, TipoContenido.JSON);
                    String recibirjson = peticion.ObtenerJson();

                    if (recibirjson == null)
                    {
                        // Mostrar alerta si el nombre del usuario es nulo o no se encontró el usuario
                        DisplayAlert("Acceso denegado", "No se cuenta con un resgistro en la BD", "Aceptar");

                        lblUsuario.Text = "No existe";
                        Navigation.PushAsync(new Page1(tagIdHex));
                    }
                    else
                    {
                        Usuario usuario = JsonConvert.DeserializeObject<Usuario>(recibirjson);

                        Page2 page2 = new Page2(usuario.ID, usuario.NombreCompleto, usuario.NumeroTarjeta);
                        Navigation.PushAsync(page2);

                        //int id = usuario.ID;
                        //string numeroTarjeta = usuario.NumeroTarjeta;
                        //lblUsuario.Text= usuario.NombreCompleto;
                    }


                });
            });
        }

        

        

        //private void OnNFCDetected(App sender, string nfcId)
        //{
        //    Device.BeginInvokeOnMainThread(() =>
        //    {
        //        lblTagIdHex.Text = "La ID de tu TAG es: " + nfcId;
        //    });
        //}

        
    }
}
