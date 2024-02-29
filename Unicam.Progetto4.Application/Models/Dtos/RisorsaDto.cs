using Unicam.Progetto4.Models.Entities;

namespace Unicam.Progetto4.Application.Models.Dtos
{
    public class RisorsaDto
    {

        public RisorsaDto() { }

        public RisorsaDto(Risorsa risorsa) 
        {
            Id = risorsa.IdRisorsa;
            Nome = risorsa.Nome;
            IdRisorsaTipologia = risorsa.IdRisorsaTipologia;
        
        }


        public int Id { get; set; } 
        public string Nome { get; set; } = string.Empty;
        public int IdRisorsaTipologia { get; set; }
    }
}
