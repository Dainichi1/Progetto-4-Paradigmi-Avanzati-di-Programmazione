using Unicam.Progetto4.Models.Configurations;
using Unicam.Progetto4.Models.Entities;

namespace Unicam.Progetto4.Application.Models.Dtos
{
    public class PrenotazioneDto
    {
        public PrenotazioneDto() { }

        public PrenotazioneDto (Prenotazione prenotazione) 
        {
            Id = prenotazione.IdPrenotazione;
            IdRisorsa = prenotazione.IdRisorsa;
            DataInizio = prenotazione.DataInizio;
            DataFine = prenotazione.DataFine;
            

        }

        public int Id { get; set; }
        public int IdRisorsa { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }

        
    }
}
