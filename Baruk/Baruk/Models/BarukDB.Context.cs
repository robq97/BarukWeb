﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CROSSFITBARUKEntities : DbContext
    {
        public CROSSFITBARUKEntities()
            : base("name=CROSSFITBARUKEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Descuento> Descuentoes { get; set; }
        public virtual DbSet<Genero> Generoes { get; set; }
        public virtual DbSet<Morosidad> Morosidads { get; set; }
        public virtual DbSet<Pago> Pagoes { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<RutinasClientesAvanzado> RutinasClientesAvanzados { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TipoCliente> TipoClientes { get; set; }
        public virtual DbSet<TipoMensualidad> TipoMensualidads { get; set; }
        public virtual DbSet<TipoPago> TipoPagoes { get; set; }
        public virtual DbSet<TipoPersona> TipoPersonas { get; set; }
        public virtual DbSet<TipoRutinaAvanzada> TipoRutinaAvanzadas { get; set; }
        public virtual DbSet<TipoSuscripcion> TipoSuscripcions { get; set; }
        public virtual DbSet<WOD> WODs { get; set; }
    }
}
