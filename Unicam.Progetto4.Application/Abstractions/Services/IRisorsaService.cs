using Unicam.Progetto4.Application.Models.Dtos;
using Unicam.Progetto4.Application.Models.Requests;
using Unicam.Progetto4.Models.Entities;

namespace Unicam.Progetto4.Application.Abstractions.Services
{
    public interface IRisorsaService
    {

        List<Risorsa> GetRisorse();
        List<Risorsa> GetRisorse(int from, int num, string? name, out int totalNum);
        void AddRisorsa(Risorsa risorsa);

        List<RisorsaDto> GetDisponibilita(int from, int num, DateTime dataInizio, DateTime dataFine, int? codiceRisorsa, out int totalItems);

    }
}
