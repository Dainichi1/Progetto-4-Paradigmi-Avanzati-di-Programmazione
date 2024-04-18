using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unica.Progetto4.Abstractions;
using Unicam.Progetto4.Models.Context;

namespace Unicam.Progetto4.Test.Orm
{
    public class Linq : IExample
    {
        public async Task RunExampleAsync()
        {
            var ctx = new MyDbContext();

            // Recupera le risorse in modo asincrono e poi esegue il raggruppamento
            var risorse = await ctx.Risorse.ToListAsync();
            var queryResult = risorse.GroupBy(g => g.IdRisorsaTipologia);

            foreach (var item in queryResult)
            {
                Console.WriteLine($"Tipologia di Risorsa con codice {item.Key}:");
                foreach (var risorsa in item)
                {
                    Console.WriteLine($"{risorsa.Nome} {risorsa.IdRisorsa}\n");
                }
            }
        }
    }
}
