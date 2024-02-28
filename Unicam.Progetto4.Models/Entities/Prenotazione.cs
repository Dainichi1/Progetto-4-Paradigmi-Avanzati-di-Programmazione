using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Progetto4.Models.Entities
{
    public class Prenotazione
    {
        public int IdPrenotazione { get; set; }
        public int IdRisorsa { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }

        // Proprietà di navigazione
        public Risorsa Risorsa { get; set; } 
    }
}
