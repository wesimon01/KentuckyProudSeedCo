using KentuckyProudSeedCo.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KentuckyProudSeedCo.Data.Repos
{
    public class GenericRepository : IGenericRepository
    {
        private readonly KentuckyProudSeedCoContext context;

        public GenericRepository(KentuckyProudSeedCoContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(KentuckyProudSeedCoContext));
        }

        public async Task<EntityEntry<T>> Add<T>(T entity) where T : class
        {
            var dbSet = context.Set<T>();
            context.Entry(entity).State = EntityState.Added;
            return await dbSet.AddAsync(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            var dbSet = context.Set<T>();
            dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> FindAll<T>() where T : class
        {
            var dbSet = context.Set<T>();
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T?> FindById<T>(int id) where T : class
        {
            var dbSet = context.Set<T>();
            return await dbSet.FindAsync(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<T?> Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
