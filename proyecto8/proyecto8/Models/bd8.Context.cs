﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace proyecto8.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class patagones1Entities : DbContext
    {
        public patagones1Entities()
            : base("name=patagones1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cargo_personal> cargo_personal { get; set; }
        public virtual DbSet<categoria_producto> categoria_producto { get; set; }
        public virtual DbSet<estado_glaseado> estado_glaseado { get; set; }
        public virtual DbSet<estado_producto> estado_producto { get; set; }
        public virtual DbSet<personal> personal { get; set; }
        public virtual DbSet<producto> producto { get; set; }
        public virtual DbSet<producto_glaseado> producto_glaseado { get; set; }
        public virtual DbSet<producto_proceso> producto_proceso { get; set; }
        public virtual DbSet<proveedor> proveedor { get; set; }
        public virtual DbSet<proveedor_producto> proveedor_producto { get; set; }
        public virtual DbSet<registro_compra> registro_compra { get; set; }
        public virtual DbSet<telefono_personal> telefono_personal { get; set; }
    }
}