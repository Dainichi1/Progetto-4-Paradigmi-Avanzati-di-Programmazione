namespace Unicam.Progetto4.Application.Models.Requests
{
    public class GetPrenotazioneRequest
    {
        public int PageSize { get; set; } 
        public int PageNumber { get; set; } 

        public string? Id { get; set; } 
    }
}
