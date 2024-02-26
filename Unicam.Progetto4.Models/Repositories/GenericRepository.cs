using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto4.Models.Context;

namespace Unicam.Progetto4.Models.Repositories
{
    public abstract class GenericRepository<T> where T : class
    {
        protected MyDbContext _ctx;
        public GenericRepository(MyDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task AggiungiAsync(T entity)
        {
            var idProperty = _ctx.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties[0];
            var id = (int)typeof(T).GetProperty(idProperty.Name).GetValue(entity);
            var entityExists = await OttieniAsync(id) != null;

            if (!entityExists)
            {
                await _ctx.Set<T>().AddAsync(entity);
            }



        }

        public async Task ModificaAsync(T entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
        }

        public async Task<T> OttieniAsync(object id)
        {
            return await _ctx.Set<T>()
                .FindAsync(id);
        }

        public async Task EliminaAsync(object id)
        {
            var entity = await OttieniAsync(id);
            _ctx.Set<T>().Remove(entity);
            await _ctx.SaveChangesAsync();

        }

        public async Task SaveAsync()
        {
            await _ctx.SaveChangesAsync();
        }
    }
}

