﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataBaseModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DemoDataofTroopEntities : DbContext
    {
        public DemoDataofTroopEntities()
            : base("name=DemoDataofTroopEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<TaskStack> TaskStack { get; set; }
        public virtual DbSet<Troops> Troops { get; set; }
        public virtual DbSet<Weather> Weather { get; set; }
    }
}
