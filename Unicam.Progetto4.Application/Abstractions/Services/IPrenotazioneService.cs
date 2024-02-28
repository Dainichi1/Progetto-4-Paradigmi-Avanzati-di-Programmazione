using Unicam.Progetto4.Models.Entities;

namespace Unicam.Progetto4.Application.Abstractions.Services
{
    public interface IPrenotazioneService
    {

        List<Prenotazione> GetPrenotazione();
        void AddPrenotazione(Prenotazione prenotazione);
    }
}
