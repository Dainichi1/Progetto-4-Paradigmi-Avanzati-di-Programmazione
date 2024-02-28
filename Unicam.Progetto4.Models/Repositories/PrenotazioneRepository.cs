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
    }
}