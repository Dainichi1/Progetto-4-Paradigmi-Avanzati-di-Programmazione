using Unicam.Progetto4.Application.Abstractions.Services;
using Unicam.Progetto4.Models.Entities;
using Unicam.Progetto4.Models.Repositories;

namespace Unicam.Progetto4.Application.Services
{
    public class PrenotazioneService : IPrenotazioneService
    {
        private readonly PrenotazioneRepository _prenotazioneRepository;
        public PrenotazioneService(PrenotazioneRepository prenotazioneRepository)
        {
            _prenotazioneRepository = prenotazioneRepository;
        }

        public void AddPrenotazione(Prenotazione prenotazione)
        {
            _prenotazioneRepository.AggiungiAsync(prenotazione).Wait();
            _prenotazioneRepository.SaveAsync().Wait();
        }

        public List<Prenotazione> GetPrenotazione()
        {
            return new List<Prenotazione>();
        }
    }
}
