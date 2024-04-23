using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto4.Models.Context;
using Unicam.Progetto4.Models.Entities;

namespace Unicam.Progetto4.Models.Repositories
{
    public class PrenotazioneRepository : GenericRepository<Prenotazione>
    {
        public PrenotazioneRepository(MyDbContext ctx) : base(ctx)
        {
        }

        public List<Prenotazione> GetPrenotazioni(int from, int num, string? nomeRisorsa, out int totalNum)
        {
            var query = _ctx.Prenotazioni.Include(p => p.Risorsa).AsQueryable();

            if (!string.IsNullOrEmpty(nomeRisorsa))
            {
                query = query.Where(w => w.Risorsa.Nome.ToLower().Contains(nomeRisorsa.ToLower()));
            }

            totalNum = query.Count();

            return query.OrderBy(o => o.IdPrenotazione)
                        .Skip(from)
                        .Take(num)
                        .ToList();
        }
        
    }
}