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

    public class RisorsaTipologiaConfiguration : IEntityTypeConfiguration<RisorsaTipologia>
    {

        public void Configure(EntityTypeBuilder<RisorsaTipologia> builder)
        {
            builder.ToTable("RisorseTipologia"); 
            builder.HasKey(k => k.IdRisorsaTipologia); 
        }
    }
}
