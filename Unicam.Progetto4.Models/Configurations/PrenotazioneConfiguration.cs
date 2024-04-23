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

            builder.HasOne(p => p.Risorsa) 
                   .WithMany(r => r.Prenotazioni) 
                   .HasForeignKey(p => p.IdRisorsa) 
                   .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
