using Unicam.Progetto4.Models.Entities;

namespace Unicam.Progetto4.Application.Abstractions.Services
{
    public interface IRisorsaService
    {

        List<Risorsa> GetRisorse();
        void AddRisorsa(Risorsa risorsa);
    }
}
