<<<<<<< HEAD
﻿using System;
=======
﻿using Newtonsoft.Json;
using System;
>>>>>>> 3bfcfc683aa7bb7bc16fc1182028b53730a35cf9
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
<<<<<<< HEAD
        public Page2(int ID, string NumeroTarjeta, string NombreCompleto)
        {
            InitializeComponent();


            //MAIN PAGE
            // Lógica para inicializar la página y mostrar los datos
            lblID.Text = "ID: " + ID.ToString();
            lblnombreCompleto.Text = "Nonbre: " + NombreCompleto;
            lblIdTag.Text = "Tag: " + NumeroTarjeta;
=======
        public Page2(int Id, string NumeroTarjeta, string NombreCompleto)
        {
            InitializeComponent();

            lblID.Text = "ID: " + Id.ToString();
            lblNoTag.Text = "Número de tarjeta: " + NumeroTarjeta;
            lblUsuario.Text = "Usuario: " + NombreCompleto;
>>>>>>> 3bfcfc683aa7bb7bc16fc1182028b53730a35cf9
        }
    }
}