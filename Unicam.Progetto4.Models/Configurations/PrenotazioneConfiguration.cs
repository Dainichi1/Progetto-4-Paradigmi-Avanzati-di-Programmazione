using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto4.Models.Entities;

namespace Unicam.Progetto4.Models.Configurations
{
    public class PrenotazioneConfiguration : IEntityTypeConfiguration<Prenotazione>
    {
        public void Configure(EntityTypeBuilder<Prenotazione> builder)
        {
            builder.ToTable("Prenotazioni");
            builder.HasKey(p => p.IdPrenotazione);

            builder.Property(p => p.DataInizio)
                   .IsRequired();

            builder.Property(p => p.DataFine)
                   .IsRequired();

            builder.HasOne(p => p.Risorsa) // Prenotazione ha una Risorsa
                   .WithMany(r => r.Prenotazioni) // Risorsa ha molte Prenotazioni
                   .HasForeignKey(p => p.IdRisorsa) // Chiave esterna in Prenotazione che punta a Risorsa
                   .OnDelete(DeleteBehavior.Restrict); // Imposta il comportamento di cancellazione

            // Aggiungi qui ulteriori configurazioni se necessario
        }
    }
}
