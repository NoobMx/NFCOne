using HTTPupt;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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

            // Suscribirse al evento NFCDetectado
            MessagingCenter.Subscribe<App, string>(this, "NFCDetectado", (sender, tagIdHex) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    lblTagIdHex.Text = tagIdHex;

                    // Verificar la conexión a Internet
                    bool tieneConexionInternet = Connectivity.NetworkAccess == NetworkAccess.Internet;

                    if (!tieneConexionInternet)
                    {
                        lblTagIdHex.Text = "Conéctate a una red para obtener los datos";
                    }
                    else
                    {
                        peticion.PedirComunicacion("Usuario/obtener/" + tagIdHex, MetodoHTTP.GET, TipoContenido.JSON);
                        String recibirjson = peticion.ObtenerJson();

                        if (recibirjson == null)
                        {
                            lblExistencia.Text = "No existe";
                            Navigation.PushAsync(new Page1(tagIdHex));
                        }
                        else
                        {
                            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(recibirjson);
                            int id = usuario.ID;
                            string numeroTarjeta = usuario.NumeroTarjeta;
                            string nombreColpleto = usuario.NombreCompleto;
                            Navigation.PushAsync(new Page2(id, numeroTarjeta, nombreColpleto));
                        }
                    }

                });
            });
        }
    }
}
