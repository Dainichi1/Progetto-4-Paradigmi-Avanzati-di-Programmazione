namespace Unicam.Progetto4.Application.Models.Requests
{
    public class GetDisponibilitaRequest
    {
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        public int? IdRisorsa { get; set; }
        public int PageSize { get; set; } 
        public int PageNumber { get; set; } 
    }
}
