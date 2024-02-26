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
        

    }
}
