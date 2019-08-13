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
        public int NumeroCedula { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int GeneroID { get; set; }
        public int DistritoID { get; set; }
        public string Comentarios{ get; set; }
        public int PagoID { get; set; }
        public int RutinaClienteID { get; set; }
        public Nullable<byte> TipoCliente { get; set; }
        public Nullable<int> WODID { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int TipoPersonaID { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }

        //public virtual ICollection<MPersona> Personas { get; set; }
    }
}