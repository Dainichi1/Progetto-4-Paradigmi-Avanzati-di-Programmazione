using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto4.Models.Entities;
using Unicam.Progetto4.Models.Context;


namespace Unicam.Progetto4.Models.Repositories
{
    public class RisorsaRepository : GenericRepository<Risorsa>
    {
        public RisorsaRepository(MyDbContext ctx) : base(ctx)
        {
        }

        public Risorsa GetById(int id)
        {
            return _ctx.Risorse.FirstOrDefault(u => u.IdRisorsa == id);
        }
        public List<Risorsa> GetRisorse(int from, int num, string? name, out int totalNum)
        {
            var query = _ctx.Risorse.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(w => w.Nome.ToLower().Contains(name.ToLower()));
            }

            totalNum = query.Count();
            return
                query
                .OrderBy(o => o.Nome)
                .Skip(from)
                .Take(num)
                .ToList();
        }
        public bool RisorsaExists(int idRisorsa)
        {
            return _ctx.Risorse.Any(r => r.IdRisorsa == idRisorsa);
        }
    }


}

