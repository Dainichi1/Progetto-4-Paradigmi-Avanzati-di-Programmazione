using Unicam.Progetto4.Models.Entities;

namespace Unicam.Progetto4.Application.Models.Dtos
{
    public class UtenteDto
    {

        public UtenteDto() { }

        public UtenteDto(Utente utente) 
        { 
            IdUtente = utente.IdUtente;
            Nome = utente.Nome;
            Cognome = utente.Cognome;
            Email = utente.Email;
            Password = utente.Password;

        }

        public int IdUtente { get; set; } 
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;    
    }
}
