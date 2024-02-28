namespace Unicam.Progetto4.Application.Models.Requests
{
    public class CreateTokenRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
