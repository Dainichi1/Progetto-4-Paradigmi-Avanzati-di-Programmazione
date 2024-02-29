namespace Unicam.Progetto4.Application.Models.Requests
{
    public class GetUtenteRequest
    {
        public int PageSize { get; set; } // grandezza della pagina. per esempio posso impostare di restituire 10 risultati alla volta
        public int PageNumber { get; set; } // identifica il numero di pagina che voglio vedere. ha indici 0: se faccio 0 vuol dire che voglio vedere la prima pagina, indice 1 la seconda pagina e così via 

        public String? Name { get; set; } // filtra per nome dell'aziende
    }
}
