using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto4.Models.Entities;


// METODO PER FARE IL MAPPING tra la classe Utente e la tabella del db utenti
namespace Unicam.Progetto4.Models.Configurations
{

    // questa classe è una configurazione per l'oggetto "utente"
    public class UtenteConfiguration : IEntityTypeConfiguration<Utente>
    {
        public void Configure(EntityTypeBuilder<Utente> builder)
        {
            builder.ToTable("Utenti"); // la classe utente viene messa dentro la tabella utenti del db
            builder.HasKey(y => y.IdUtente); // la classe ha come chiave IdUtente
        }
    }
}
