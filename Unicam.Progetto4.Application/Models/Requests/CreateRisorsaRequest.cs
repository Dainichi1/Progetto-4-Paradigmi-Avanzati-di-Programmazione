using Unicam.Progetto4.Models.Entities;

namespace Unicam.Progetto4.Application.Models.Requests
{
    public class CreateRisorsaRequest
    {

        public int IdRisorsa { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int IdRisorsaTipologia { get; set; }

        public Risorsa ToEntity()
        {
            var risorsa = new Risorsa();
            risorsa.IdRisorsa = IdRisorsa;
            risorsa.Nome = Nome;
            risorsa.IdRisorsaTipologia = IdRisorsaTipologia;
           
            return risorsa;
        }
    }
}
