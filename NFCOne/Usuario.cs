using System;
using System.Collections.Generic;
using System.Text;

namespace NFCOne
{
    internal class Usuario
    {
        public int ID { get; set; }
        public String NumeroTarjeta { get; set; }
        public String NombreCompleto { get; set; }
    }

    public class NFCData
    {
        public int Id { get; set; }
        public string NumeroTarjeta { get; set; }
        public string NombreCompleto { get; set; }
    }
    //public class UsuarioDTO
    //{
    //    public int ID { get; set; }
    //    public String NumeroTarjeta { get; set; }
    //    public String NombreCompleto { get; set; }
    //}
}
