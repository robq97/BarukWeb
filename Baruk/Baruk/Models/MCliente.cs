using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Baruk.Models
{
     class MCliente
    {
        //Get y Set de los atributos
        public int CedulaID  { get; set; }
        public int PersonaID { get; set; }
        public int GeneroID { get; set; }
        public string Comentarios { get; set; }
        public int PagoID { get; set; }
        public int RutinaClienteID { get; set; }
        public int WodID { get; set; }
        public int TipoClienteID { get; set; }
        public string UsuarioCliente { get; set; }
        public string PasswrdCliente { get; set; }
        
    }
}