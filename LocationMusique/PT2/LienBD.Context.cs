﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace PT2
{
    
    public partial class MusiquePT2_DEntities : DbContext
    {
        public MusiquePT2_DEntities()
            : base("name=MusiquePT2_DEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ABONNÉS> ABONNÉS { get; set; }
        public virtual DbSet<ALBUMS> ALBUMS { get; set; }
        public virtual DbSet<EDITEURS> EDITEURS { get; set; }
        public virtual DbSet<EMPRUNTER> EMPRUNTER { get; set; }
        public virtual DbSet<GENRES> GENRES { get; set; }
        public virtual DbSet<PAYS> PAYS { get; set; }
    }
}
