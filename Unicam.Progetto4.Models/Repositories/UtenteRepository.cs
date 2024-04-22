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
        public Utente GetById(int id)
        {
            return _ctx.Utenti.FirstOrDefault(u => u.IdUtente == id);
        }
        public List<Utente> GetUtenti(int from, int num, string? searchTerm, out int totalNum)
        {
            var query = _ctx.Utenti.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(u => u.Nome.ToLower().Contains(searchTerm) || u.Cognome.ToLower().Contains(searchTerm));
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
