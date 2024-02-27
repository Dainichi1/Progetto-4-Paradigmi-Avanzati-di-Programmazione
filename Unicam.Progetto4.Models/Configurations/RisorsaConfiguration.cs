using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto4.Models.Entities;

namespace Unicam.Progetto4.Models.Configurations
{
    public class RisorsaConfiguration : IEntityTypeConfiguration<Risorsa>
    {
        public void Configure(EntityTypeBuilder<Risorsa> builder)
        {
            builder.ToTable("Risorse");
            builder.HasKey(p => p.IdRisorsa);
            builder.Property(p => p.Nome)
                .HasMaxLength(100);

            builder.HasOne(r => r.RisorsaTipologiaACuiAppartiene) // Proprietà di navigazione in Risorsa
                .WithMany(rt => rt.Risorse) // Proprietà di navigazione inversa in RisorsaTipologia
                .HasForeignKey(r => r.IdRisorsaTipologia); // Chiave esterna in Risorsa
        }
    }
}
