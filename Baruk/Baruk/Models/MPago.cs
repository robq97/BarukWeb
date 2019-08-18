using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Baruk.Models
{
    public class MPago
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

        public string DescTipoSuscripcion { get; set; }
        public string DescTipoPago { get; set; }
        public string DescTipoDescuento { get; set; }
        public string DescTipoMensualidad { get; set; }
        public string DescMorosidad { get; set; }
        public string DescTipoCliente { get; set; }
        public int Cedula { get; set; }
        public string Nombre { get; set; }

    }
}