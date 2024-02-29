using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto4.Models.Entities;
using Unicam.Progetto4.Models.Context;

namespace Unicam.Progetto4.Models.Repositories
{
    public class UtenteRepository : GenericRepository<Utente>
    {
        public UtenteRepository(MyDbContext ctx) : base(ctx)
        {
        }

        public List<Utente> GetUtenti(int from, int num, string? name, out int totalNum)
        {
            var query = _ctx.Utenti.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(w => w.Cognome.ToLower().Contains(name.ToLower()));
            }

            totalNum = query.Count();
            return
                query
                .OrderBy(o => o.Cognome)
                .Skip(from)
                .Take(num)
                .ToList();
        }
    }
}
