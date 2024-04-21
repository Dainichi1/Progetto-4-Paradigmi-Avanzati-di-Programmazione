using Unicam.Progetto4.Application.Abstractions.Services;
using Unicam.Progetto4.Models.Entities;
using Unicam.Progetto4.Models.Repositories;

namespace Unicam.Progetto4.Application.Services
{
    // qui mappo le operazioni che devono essere effettuate sulle prenotazioni (creazione, modifica, elenco ...)
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

        public List<Prenotazione> GetPrenotazioni()
        {
            return new List<Prenotazione>();
        }

        public List<Prenotazione> GetPrenotazioni(int from, int num, string? name, out int totalNum)
        {
            return _prenotazioneRepository.GetPrenotazioni(from, num, name, out totalNum);
        }

        
    }
}
