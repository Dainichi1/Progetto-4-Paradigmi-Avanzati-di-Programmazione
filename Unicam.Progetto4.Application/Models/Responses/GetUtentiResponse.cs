using Unicam.Progetto4.Application.Models.Dtos;

namespace Unicam.Progetto4.Application.Models.Responses
{
    public class GetUtentiResponse
    {
        public List<UtenteDto> Utenti { get; set; } = new List<UtenteDto>();
        public int NumeroPagine { get; set; }
    }
}
