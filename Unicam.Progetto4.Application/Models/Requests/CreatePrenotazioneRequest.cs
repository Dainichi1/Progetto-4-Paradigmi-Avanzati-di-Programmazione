using Unicam.Progetto4.Models.Entities;

namespace Unicam.Progetto4.Application.Models.Requests
{
    public class CreatePrenotazioneRequest
    {
        public int IdRisorsa { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }

        public Prenotazione ToEntity()
        {
            var prenotazione = new Prenotazione();
            prenotazione.IdRisorsa = IdRisorsa;
            prenotazione.DataInizio = DataInizio;
            prenotazione.DataFine = DataFine;
            return prenotazione;
        }
    }
}
