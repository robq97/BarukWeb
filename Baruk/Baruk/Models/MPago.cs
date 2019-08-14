using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Baruk.Models
{
     class MPago
    {
        //Get y Set de los atributos
        public int PagoID { get; set; }
        public int TipoSuscripcion { get; set; }
        public DateTime FechaPago { get; set; }
        public int TipoPagoID { get; set; }
        public int DescuentoID { get; set; }
        public int TipoMensualidadID{ get; set; }
        public int MorosidadID { get; set; }
        public int TipoClienteID{ get; set; }
    }
}