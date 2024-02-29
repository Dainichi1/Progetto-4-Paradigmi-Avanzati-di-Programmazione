using Unicam.Progetto4.Application.Models.Dtos;

namespace Unicam.Progetto4.Application.Models.Responses
{
    public class GetPrenotazioniResponse
    {
        public List<PrenotazioneDto> Prenotazioni { get; set; } = new List<PrenotazioneDto>();
        public int NumeroPagine { get; set; }
    }
}
