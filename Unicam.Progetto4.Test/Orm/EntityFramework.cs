﻿using Microsoft.EntityFrameworkCore;
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
    public class EntityFramework : IExample
    {

        public async Task RunExampleAsync()
        {

            var ctx = new MyDbContext();



            var utenti = await ctx.Utenti.ToListAsync();
            await DeleteUtenteAsync(ctx);
            await AddRisorsaTipologiaAsync(ctx);
            await AddUtenteAsync(ctx);
            await AddRisorsaAsync(ctx);

        }


        public async Task AddUtenteAsync(MyDbContext ctx)
        {
            var utenti = new List<Utente>
            {

                new Utente
                {
                    Nome = "Mario",
                    Cognome = "Rossi",
                    Email = "prova1@mail.it",
                    Password = "12345",
                },

                new Utente
                {
                    Nome = "Luca",
                    Cognome = "Bianchi",
                    Email = "prova2@mail.it",
                    Password = "123456",
                },

                new Utente
                {
                    Nome = "Paolo",
                    Cognome = "Verdi",
                    Email = "prova2@mail.it",
                    Password = "123466",
                },

                new Utente
                {
                    Nome = "Mauro",
                    Cognome = "Grigi",
                    Email = "prova3@mail.it",
                    Password = "98765",
                },

                new Utente
                {
                    Nome = "Giorgio",
                    Cognome = "Azzurri",
                    Email = "prova5@mail.it",
                    Password = "465465",
                },

                new Utente
                {
                    Nome = "Marco",
                    Cognome = "Verdi",
                    Email = "prova6@mail.it",
                    Password = "23432432",
                },

                new Utente
                {
                    Nome = "Tommaso",
                    Cognome = "Rossi",
                    Email = "prova7@mail.it",
                    Password = "53453",
                },

                new Utente
                {
                    Nome = "Roberto",
                    Cognome = "Rossi",
                    Email = "prova8@mail.it",
                    Password = "53453",
                },

                new Utente
                {
                    Nome = "Riccardo",
                    Cognome = "Rossi",
                    Email = "prova10@mail.it",
                    Password = "564564646",
                },

                new Utente
                {
                    Nome = "Luigi",
                    Cognome = "Neri",
                    Email = "prova19@mail.it",
                    Password = "45645645645",
                }
            };

            foreach (var nuovoUtente in utenti)
            {
                // Controlla se l'utente esiste già
                var esisteUtente = ctx.Utenti
                    .Any(u => u.Email == nuovoUtente.Email);

                // Se non esiste, aggiungilo
                if (!esisteUtente)
                {
                    ctx.Utenti.Add(nuovoUtente);
                }
            }

            await ctx.SaveChangesAsync();
        }

        public async Task DeleteUtenteAsync(MyDbContext ctx)
        {

            var utentiDaCancellare = ctx.Utenti
                .Where(u => u.IdUtente >= 34 && u.IdUtente <= 35)
                .ToList();

            // Rimuovi gli utenti selezionati dal contesto
            foreach (var utente in utentiDaCancellare)
            {
                ctx.Utenti.Remove(utente);
            }

            // Salva le modifiche nel database
            await ctx.SaveChangesAsync();
        }

        public async Task AddRisorsaTipologiaAsync(MyDbContext ctx)
        {
            var risorseTipologia = new List<RisorsaTipologia>
            {
                new RisorsaTipologia
                {
                    IdRisorsaTipologia = 4,
                    NomeTipologia = "Auto",
                },

                new RisorsaTipologia
                {
                    IdRisorsaTipologia = 2,
                    NomeTipologia = "Sala Riunioni",
                },

                new RisorsaTipologia
                {
                    IdRisorsaTipologia = 1,
                    NomeTipologia = "Ristoranti",
                },

                new RisorsaTipologia
                {
                    IdRisorsaTipologia = 3,
                    NomeTipologia = "Hotel",
                },

                new RisorsaTipologia
                {
                    IdRisorsaTipologia = 5,
                    NomeTipologia = "Pub",
                }

            };

            foreach (var tipologia in risorseTipologia)
            {
                // Verifica se la tipologia esiste già nel database
                var esistente = ctx.RisorseTipologia
                    .AsNoTracking() // Aggiunto per evitare il tracciamento delle entità in questa query
                    .FirstOrDefault(rt => rt.IdRisorsaTipologia == tipologia.IdRisorsaTipologia);

                // Se non esiste, aggiungila
                if (esistente == null)
                {
                    ctx.RisorseTipologia.Add(tipologia);
                }
            }


            await ctx.SaveChangesAsync();
        }


        public async Task AddRisorsaAsync(MyDbContext ctx)
        {
            var risorse = new List<Risorsa>
            {
                new Risorsa
                {
                    IdRisorsa = 1,
                    Nome = "AUDI A1",
                    IdRisorsaTipologia = 4,
                },

                new Risorsa
                {
                    IdRisorsa = 3,
                    Nome = "FIAT 500",
                    IdRisorsaTipologia = 4,
                },

                new Risorsa
                {
                    IdRisorsa = 10,
                    Nome = "PANDA",
                    IdRisorsaTipologia = 4,
                },

                new Risorsa
                {
                    IdRisorsa = 2,
                    Nome = "PUNTO",
                    IdRisorsaTipologia = 4,
                },

                new Risorsa
                {
                    IdRisorsa = 40,
                    Nome = "POLO",
                    IdRisorsaTipologia = 4,
                },

                new Risorsa
                {
                    IdRisorsa = 4,
                    Nome = "Gigilio",
                    IdRisorsaTipologia = 2,
                },

                new Risorsa
                {
                    IdRisorsa = 5,
                    Nome = "Rovere",
                    IdRisorsaTipologia = 2,
                },

                new Risorsa
                {
                    IdRisorsa = 6,
                    Nome = "Aula Magna",
                    IdRisorsaTipologia = 2,
                },

                new Risorsa
                {
                    IdRisorsa = 7,
                    Nome = "Bella Napoli",
                    IdRisorsaTipologia = 1,
                },

                new Risorsa
                {
                    IdRisorsa = 8,
                    Nome = "Lo Scalino",
                    IdRisorsaTipologia = 1,
                },

                new Risorsa
                {
                    IdRisorsa = 20,
                    Nome = "Sora Lella",
                    IdRisorsaTipologia = 1,
                },

                new Risorsa
                {
                    IdRisorsa = 30,
                    Nome = "I TRE ARCHI",
                    IdRisorsaTipologia = 1,
                },
            };

            foreach (var nuovaRisorsa in risorse)
            {
                // Controlla se la risorsa esiste già
                var esisteRisorsa = ctx.Risorse
                    .Any(r => r.IdRisorsa == nuovaRisorsa.IdRisorsa);

                // Se non esiste, aggiungila
                if (!esisteRisorsa)
                {
                    ctx.Risorse.Add(nuovaRisorsa);
                }
            }

            await ctx.SaveChangesAsync();
        }

       
    }
}