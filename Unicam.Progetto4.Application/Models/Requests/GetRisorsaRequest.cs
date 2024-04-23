namespace Unicam.Progetto4.Application.Models.Requests
{
    public class GetRisorsaRequest
    {
        public int PageSize { get; set; } 
        public int PageNumber { get; set; } 
        public string? Name { get; set; } 
       
    }
}
