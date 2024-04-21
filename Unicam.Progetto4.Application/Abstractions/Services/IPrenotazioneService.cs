using Unicam.Progetto4.Models.Entities;

namespace Unicam.Progetto4.Application.Abstractions.Services
{
    public interface IPrenotazioneService
    {


        List<Prenotazione> GetPrenotazioni() ;
        List<Prenotazione> GetPrenotazioni(int from, int num, string? name, out int totalNum);
        void AddPrenotazione(Prenotazione prenotazione);

    }
}
