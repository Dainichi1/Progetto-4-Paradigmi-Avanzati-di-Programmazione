using Microsoft.EntityFrameworkCore;
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

        public MyDbContext() : base()
        {

        }

        public MyDbContext(DbContextOptions<MyDbContext> config) : base(config)
        {

        }

        //gli sto deicendo che voglio gestire l'entita Risorsa
        public DbSet<Risorsa> Risorse { get; set; }
        public DbSet<RisorsaTipologia> RisorseTipologia { get; set; }
        public DbSet<Utente> Utenti { get; set; }
        public DbSet<Prenotazione> Prenotazioni { get; set; }


        // con questo specifico che deve usare sql server
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseSqlServer("data source=localhost;Initial catalog=Progetto;User Id=progetto;Password=progetto;TrustServerCertificate=True");
        }


        // con questo metodo applico le configurazioni scritte in Configurations che in questo esempio sono nello stesso progetto "Unica.Paradigmi.Models"
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly); // Assembly = dll = progetto
            base.OnModelCreating(modelBuilder);
        }
    }
}
