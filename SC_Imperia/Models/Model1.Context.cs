﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SC_Imperia.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IMPERIA_DB : DbContext
    {
        public IMPERIA_DB()
            : base("name=IMPERIA_DB")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Senior_staff> Senior_staff { get; set; }
        public virtual DbSet<Sports_equipment> Sports_equipment { get; set; }
        public virtual DbSet<Supplier_sports_nutrition> Supplier_sports_nutrition { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Type_sports_hall> Type_sports_hall { get; set; }
        public virtual DbSet<Type_sub> Type_sub { get; set; }
    }
}
