namespace Unicam.Progetto4.Application.Models.Requests
{
    public class GetDisponibilitaRequest
    {
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        public int? CodiceRisorsa { get; set; }
        public int PageSize { get; set; } // Nessun valore predefinito
        public int PageNumber { get; set; } // Nessun valore predefinito
    }
}
