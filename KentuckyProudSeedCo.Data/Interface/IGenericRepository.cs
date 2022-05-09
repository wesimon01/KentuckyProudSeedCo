using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KentuckyProudSeedCo.Data
{
    public interface IGenericRepository
    {
        Task<EntityEntry<T>> Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<T> Update<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
        Task<T?> FindById<T>(int id) where T : class;
        Task<IEnumerable<T>> FindAll<T>() where T : class;
    }
}
