using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto4.Models.Entities;


// METODO PER FARE IL MAPPING tra la classe RisorsaTipologia e la tabella del db risorseTipologie
namespace Unicam.Progetto4.Models.Configurations
{

    // questa classe è una configurazione per l'oggetto "risorsatipologia"
    public class RisorsaTipologiaConfiguration : IEntityTypeConfiguration<RisorsaTipologia>
    {

        public void Configure(EntityTypeBuilder<RisorsaTipologia> builder)
        {
            builder.ToTable("RisorseTipologia"); // la classe risorsaTipologia viene messa dentro la tabella risorseTipologie del db
            builder.HasKey(k => k.IdRisorsaTipologia); // la classe ha come chiave IdRisorsaTipologia
        }
    }
}
