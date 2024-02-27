using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Progetto4.Models.Entities
{
    public class RisorsaTipologia
    {
        public int IdRisorsaTipologia { get; set; }
        public string NomeTipologia { get; set; } = string.Empty;// es. "Auto","Sala Riunione"

        public ICollection<Risorsa> Risorse { get; set; } = null!; 
    }
}
