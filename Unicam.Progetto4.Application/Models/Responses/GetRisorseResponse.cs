using Unicam.Progetto4.Application.Models.Dtos;

namespace Unicam.Progetto4.Application.Models.Responses
{
    public class GetRisorseResponse
    {
        public List<RisorsaDto> Risorse { get; set; } = new List<RisorsaDto>();
        public int NumeroPagine { get; set; }
    }
}
