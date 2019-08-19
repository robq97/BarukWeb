using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Baruk.Models
{
    public class MPersona
    {
        //Get y Set de los atributos
        public int PersonaID { get; set; }
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public int GeneroID { get; set; }
        public string Apellido { get; set; }
        public string DescTipoClienteID { get; set; }
        public string UsuarioCliente { get; set; }
        public string Email { get; set; }
    }
}