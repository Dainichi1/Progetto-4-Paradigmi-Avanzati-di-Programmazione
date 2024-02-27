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
    public class RisorsaService : IRisorsaService // servizio che restituisce le risorse
    {
       
        private readonly RisorsaRepository _risorsaRepository;
        public RisorsaService(RisorsaRepository risorsaRepository)
        {
            _risorsaRepository = risorsaRepository;
        }

        public void AddRisorsa(Risorsa risorsa)
        {
            _risorsaRepository.AggiungiAsync(risorsa).Wait();
            _risorsaRepository.SaveAsync().Wait();
        }

        public List<Risorsa> GetRisorse()
        {
            return new List<Risorsa>();
        }

        
    }
}

