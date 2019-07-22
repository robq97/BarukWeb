//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Baruk.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pago
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pago()
        {
            this.Personas = new HashSet<Persona>();
        }
    
        public int PagoID { get; set; }
        public int TipoSuscripcion { get; set; }
        public System.DateTime FechaPago { get; set; }
        public int TipoPagoID { get; set; }
        public Nullable<byte> DescuentoID { get; set; }
        public byte TipoMensualidadID { get; set; }
        public Nullable<byte> MorosidadID { get; set; }
        public byte TipoClinteID { get; set; }
    
        public virtual Descuento Descuento { get; set; }
        public virtual Morosidad Morosidad { get; set; }
        public virtual TipoCliente TipoCliente { get; set; }
        public virtual TipoMensualidad TipoMensualidad { get; set; }
        public virtual TipoPago TipoPago { get; set; }
        public virtual TipoSuscripcion TipoSuscripcion1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Persona> Personas { get; set; }
    }
}
