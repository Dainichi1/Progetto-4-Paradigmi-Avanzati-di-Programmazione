using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unica.Progetto4.Abstractions;
using Unicam.Progetto4.Models.Context;
using Unicam.Progetto4.Models.Entities;
using Unicam.Progetto4.Models.Repositories;

namespace Unicam.Progetto4.Test.Orm
{
    public class Repository : IExample
    {

        public async Task RunExampleAsync()
        {
            var ctx = new MyDbContext();
            var utenteRepo = new UtenteRepository(ctx);
            var risorsaRepo = new RisorsaRepository(ctx);

            var utente = await utenteRepo.OttieniAsync(1);

            var risorsa = await risorsaRepo.OttieniAsync(2);
            risorsa.Nome = "CLIO - MODIFICA";
            await risorsaRepo.ModificaAsync(risorsa);
            await risorsaRepo.SaveAsync();

            var nuovaRisorsa = new Risorsa
            {
                Nome = "MASERATI",
                IdRisorsa = 50,
                IdRisorsaTipologia = 4,
            };
            await risorsaRepo.AggiungiAsync(nuovaRisorsa);
            await risorsaRepo.SaveAsync();

        }
        
    }
}
