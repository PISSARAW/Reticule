﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Reticule.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ReticuleBaseEntities : DbContext
    {
        public ReticuleBaseEntities()
            : base("name=ReticuleBaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Equipement_Fixe> Equipement_Fixe { get; set; }
        public virtual DbSet<Equipement_Mobile> Equipement_Mobile { get; set; }
        public virtual DbSet<Reserver> Reservers { get; set; }
        public virtual DbSet<Salle> Salles { get; set; }
    }
}
