﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FightClub
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DnDInfoEntities : DbContext
    {
        public DnDInfoEntities()
            : base("name=DnDInfoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Enemy> Enemies { get; set; }
        public virtual DbSet<Hero> Heroes { get; set; }
        public virtual DbSet<Spell> Spells { get; set; }
        public virtual DbSet<Weapon> Weapons { get; set; }
    }
}
