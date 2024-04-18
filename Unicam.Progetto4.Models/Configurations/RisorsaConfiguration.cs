using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto4.Models.Entities;


// METODO PER FARE IL MAPPING tra la classe Risorsa e la tabella del db risorse
namespace Unicam.Progetto4.Models.Configurations
{

    // questa classe è una configurazione per l'oggetto "risorsa"
    public class RisorsaConfiguration : IEntityTypeConfiguration<Risorsa>
    {
        public void Configure(EntityTypeBuilder<Risorsa> builder)
        {
            builder.ToTable("Risorse"); // la classe risorsa viene messa dentro la tabella risorse del db
            builder.HasKey(p => p.IdRisorsa); // la classe ha come chiave IdRisorsa
            builder.Property(p => p.Nome)
                .HasMaxLength(100); // la stringa Nome ha lunghezza massima 100 caratteri

            builder.HasOne(r => r.RisorsaTipologiaACuiAppartiene) // Proprietà di navigazione in Risorsa
                .WithMany(rt => rt.Risorse) // Proprietà di navigazione inversa in RisorsaTipologia
                .HasForeignKey(r => r.IdRisorsaTipologia); // Chiave esterna in Risorsa
        }
    }
}
