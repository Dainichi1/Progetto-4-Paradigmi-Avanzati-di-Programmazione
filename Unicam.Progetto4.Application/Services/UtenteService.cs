using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto4.Application.Abstractions.Services;
using Unicam.Progetto4.Models.Entities;
using Unicam.Progetto4.Models.Repositories;

namespace Unicam.Progetto4.Application.Services
{
    public class UtenteService : IUtenteService
    {
        private readonly UtenteRepository _utenteRepository;
        public UtenteService(UtenteRepository utenteRepository) 
        {
            _utenteRepository = utenteRepository;
        }
        public void AddUtente(Utente utente)
        {
            _utenteRepository.AggiungiAsync(utente).Wait();
            _utenteRepository.SaveAsync().Wait();
        }

        public List<Utente> GetUtenti()
        {
            return new List<Utente>();
        }
    }
}
