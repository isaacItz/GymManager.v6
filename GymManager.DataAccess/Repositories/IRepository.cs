using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager.DataAccess.Repositories
{
    public interface IRepository<TId, TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetAsync(TId id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> FindAsync(TId id);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TId id);
    }
}