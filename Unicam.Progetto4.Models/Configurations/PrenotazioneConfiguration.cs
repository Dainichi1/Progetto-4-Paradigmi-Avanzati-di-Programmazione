using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto4.Models.Entities;

// METODO PER FARE IL MAPPING tra la classe Prenotazione e la tabella del db prenotazioni
namespace Unicam.Progetto4.Models.Configurations
{
    // questa classe è una configurazione per l'oggetto "prenotazione"
    public class PrenotazioneConfiguration : IEntityTypeConfiguration<Prenotazione>
    {
        public void Configure(EntityTypeBuilder<Prenotazione> builder)
        {
            builder.ToTable("Prenotazioni"); // la classe prenotazione viene messa dentro la tabella aziende del db
            builder.HasKey(p => p.IdPrenotazione); // la classe ha come chiave IdPrenotazione

            builder.Property(p => p.DataInizio)
                   .IsRequired();

            builder.Property(p => p.DataFine)
                   .IsRequired();

            builder.HasOne(p => p.Risorsa) // Prenotazione ha una Risorsa
                   .WithMany(r => r.Prenotazioni) // Risorsa ha molte Prenotazioni
                   .HasForeignKey(p => p.IdRisorsa) // Chiave esterna in Prenotazione che punta a Risorsa
                   .OnDelete(DeleteBehavior.Restrict); // Imposta il comportamento di cancellazione
        }
    }
}
