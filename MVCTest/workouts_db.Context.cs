﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCTest
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class social_workout_app_dbEntities : DbContext
    {
        public social_workout_app_dbEntities()
            : base("name=social_workout_app_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<task> tasks { get; set; }
        public DbSet<user> users { get; set; }
        public DbSet<workout> workouts { get; set; }
        public DbSet<workout1> workouts1 { get; set; }
    }
}
