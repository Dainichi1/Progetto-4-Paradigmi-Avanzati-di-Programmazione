using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Progetto4.Models.Entities
{
    public class Risorsa
    {
        public int IdRisorsa { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int IdRisorsaTipologia { get; set; }

        public RisorsaTipologia RisorsaTipologiaACuiAppartiene { get; set; } = null!;
        public List<Prenotazione> Prenotazioni { get; set; } = null!;
    }
}
