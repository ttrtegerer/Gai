﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gai.Entitis
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GaiDbEntities : DbContext
    {
        public GaiDbEntities()
            : base("name=GaiDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<categories> categories { get; set; }
        public virtual DbSet<drivers> drivers { get; set; }
        public virtual DbSet<licence> licence { get; set; }
        public virtual DbSet<status> status { get; set; }
    }
}
