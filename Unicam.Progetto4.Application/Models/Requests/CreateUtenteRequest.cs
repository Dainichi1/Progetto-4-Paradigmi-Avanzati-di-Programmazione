using Unicam.Progetto4.Models.Entities;

namespace Unicam.Progetto4.Application.Models.Requests
{
    
    public class CreateUtenteRequest
    {
        
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;    


       
        public Utente ToEntity() 
        {
            var utente = new Utente();
            utente.Nome = Nome;
            utente.Cognome = Cognome;
            utente.Email = Email;
            utente.Password = Password;
            return utente;
        }
    }
}
