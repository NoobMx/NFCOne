using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFCOne
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2(int Id, string NumeroTarjeta, string NombreCompleto)
        {
            InitializeComponent();

            lblID.Text = "ID: " + Id.ToString();
            lblNoTag.Text = "Número de tarjeta: " + NumeroTarjeta;
            lblUsuario.Text = "Usuario: " + NombreCompleto;
        }
    }
}