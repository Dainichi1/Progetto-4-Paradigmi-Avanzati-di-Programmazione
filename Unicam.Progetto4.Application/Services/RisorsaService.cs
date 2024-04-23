using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Unicam.Progetto4.Application.Abstractions.Services;
using Unicam.Progetto4.Application.Models.Dtos;
using Unicam.Progetto4.Models.Context;
using Unicam.Progetto4.Models.Entities;
using Unicam.Progetto4.Models.Repositories;

namespace Unicam.Progetto4.Application.Services
{
    public class RisorsaService : IRisorsaService
    {
        private readonly RisorsaRepository _risorsaRepository;
        private readonly MyDbContext _dbContext;
        
        public RisorsaService(RisorsaRepository risorsaRepository, MyDbContext dbContext)
        {
            _risorsaRepository = risorsaRepository;
            _dbContext = dbContext;
        }
        public Risorsa GetRisorsaById(int id)
        {
            return _risorsaRepository.GetById(id);
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

        public List<Risorsa> GetRisorse(int from, int num, string? name, out int totalNum)
        {
            return _risorsaRepository.GetRisorse(from, num, name, out totalNum);
        }

        public List<RisorsaDto> GetDisponibilita(int from, int num, DateTime dataInizio, DateTime dataFine, int? codiceRisorsa, out int totalItems)
        {
            from = Math.Max(from, 0);

            codiceRisorsa = codiceRisorsa == 0 ? null : codiceRisorsa;

            var query = _dbContext.Risorse
                .Include(r => r.Prenotazioni)
                .Where(r => !r.Prenotazioni.Any(p => (p.DataInizio < dataFine && p.DataFine > dataInizio)));

            if (codiceRisorsa.HasValue)
            {
                query = query.Where(r => r.IdRisorsa == codiceRisorsa.Value);
            }

            totalItems = query.Count();

            var risorse = query
                .OrderBy(r => r.Nome)
                .Skip(from * num) 
                .Take(num)
                .ToList();

            var risorseDto = risorse.Select(r => new RisorsaDto
            {
                Id = r.IdRisorsa,
                Nome = r.Nome,
                IdRisorsaTipologia = r.IdRisorsaTipologia
               
            }).ToList();

            return risorseDto;
        }
        public bool RisorsaExists(int idRisorsa)
        {
            return _dbContext.Risorse.Any(r => r.IdRisorsa == idRisorsa);
        }

    }
}
