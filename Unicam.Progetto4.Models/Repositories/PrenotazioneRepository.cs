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
            // Inizia con una query su tutte le prenotazioni
            var query = _ctx.Prenotazioni.Include(p => p.Risorsa).AsQueryable();

            // Filtra le prenotazioni in base al nome della risorsa, se specificato
            if (!string.IsNullOrEmpty(nomeRisorsa))
            {
                query = query.Where(w => w.Risorsa.Nome.ToLower().Contains(nomeRisorsa.ToLower()));
            }

            // Calcola il numero totale di prenotazioni che soddisfano i criteri
            totalNum = query.Count();

            // Ritorna le prenotazioni ordinate per ID della prenotazione in modo crescente
            // Effettua la paginazione basata sui parametri forniti
            return query.OrderBy(o => o.IdPrenotazione)
                        .Skip(from)
                        .Take(num)
                        .ToList();
        }
    }
}