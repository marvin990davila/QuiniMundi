﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuinielaMundial.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QuinielaEntities1 : DbContext
    {
        public QuinielaEntities1()
            : base("name=QuinielaEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<EncuentroGrupo> EncuentroGrupo { get; set; }
        public virtual DbSet<EncuentroGrupoVati> EncuentroGrupoVati { get; set; }
        public virtual DbSet<Encuentros> Encuentros { get; set; }
        public virtual DbSet<Equipo> Equipo { get; set; }
        public virtual DbSet<EquipoGrupo> EquipoGrupo { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<Invitados> Invitados { get; set; }
        public virtual DbSet<Mundial> Mundial { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<pruevas> pruevas { get; set; }
        public virtual DbSet<Quiniela> Quiniela { get; set; }
        public virtual DbSet<QuinielaVaticinio> QuinielaVaticinio { get; set; }
        public virtual DbSet<Solicitudes> Solicitudes { get; set; }
        public virtual DbSet<TipoQuiniela> TipoQuiniela { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Vaticinio> Vaticinio { get; set; }
        public virtual DbSet<VatiEstado> VatiEstado { get; set; }
    }
}
