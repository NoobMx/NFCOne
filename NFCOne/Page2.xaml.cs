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
        public Page2(int ID, string NumeroTarjeta, string NombreCompleto)
        {
            InitializeComponent();


            //MAIN PAGE
            // Lógica para inicializar la página y mostrar los datos
            lblID.Text = "ID: " + ID.ToString();
            lblnombreCompleto.Text = "Nonbre: " + NombreCompleto;
            lblIdTag.Text = "Tag: " + NumeroTarjeta;
        }
    }
}