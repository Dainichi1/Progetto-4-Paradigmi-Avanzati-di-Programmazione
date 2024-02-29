using Unicam.Progetto4.Models.Entities;

namespace Unicam.Progetto4.Application.Abstractions.Services
{
    public interface IUtenteService
    {
        List<Utente> GetUtenti();
        List<Utente> GetUtenti(int from, int num, string? name, out int totalNum);
        void AddUtente(Utente utente);

    }
}
