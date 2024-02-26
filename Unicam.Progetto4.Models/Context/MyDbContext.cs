﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto4.Models.Entities;

namespace Unicam.Progetto4.Models.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<Risorsa> Risorse { get; set; }
        public DbSet<RisorsaTipologia> RisorseTipologia { get; set; }
        public DbSet<Utente> Utenti { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseSqlServer("data source=localhost;Initial catalog=Progetto;User Id=progetto;Password=progetto;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly); // Assembly = dll = progetto
            base.OnModelCreating(modelBuilder);
        }
    }
}