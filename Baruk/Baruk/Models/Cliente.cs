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
    
    public partial class Cliente
    {
        public short ClienteID { get; set; }
        public short PersonaID { get; set; }
        public byte GeneroID { get; set; }
        public string Comentarios { get; set; }
        public int PagoID { get; set; }
        public Nullable<short> RutinaClienteID { get; set; }
        public int WODID { get; set; }
        public byte TipoClienteID { get; set; }
        public string UsuarioCliente { get; set; }
        public string PasswrdCliente { get; set; }
    
        public virtual Persona Persona { get; set; }
        public virtual TipoCliente TipoCliente { get; set; }
        public virtual Genero Genero { get; set; }
        public virtual Pago Pago { get; set; }
        public virtual RutinasClientesAvanzado RutinasClientesAvanzado { get; set; }
        public virtual WOD WOD { get; set; }
    }
}