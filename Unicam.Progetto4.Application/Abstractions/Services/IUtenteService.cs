using Unicam.Progetto4.Models.Entities;

namespace Unicam.Progetto4.Application.Abstractions.Services
{
    public interface IUtenteService
    {
        List<Utente> GetUtenti();
        void AddUtente(Utente utente);

    }
}
