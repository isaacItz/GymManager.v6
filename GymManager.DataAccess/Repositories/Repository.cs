using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManager.DataAccess.Repositories
{
    public class Repository<TId, TEntity> : IRepository<TId, TEntity> where TEntity : class, new()
    {
        private readonly GymManagerContext _context;

        protected GymManagerContext Context { get => _context; }

        public Repository(GymManagerContext context)
        {
            _context = context;
        }

        public virtual IQueryable<TEntity> GetAll() {
            try{
                return _context.Set<TEntity>();
            }catch (Exception ex){
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
        public virtual async Task<TEntity> GetAsync(TId id) {
            var entity = await _context.FindAsync<TEntity>(id);
            return entity;
        }
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {

            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must be not null");
            }

            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }

        }
        public virtual async Task<TEntity> UpdateAsync(TEntity entity) {
            if(entity == null) {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }
            try {
                Console.WriteLine("entro al Repository");
                _context.Attach(entity);
                //Console.WriteLine(_context.Entry(entity));
                //Console.WriteLine(_context.Entry(entity).Entity);
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }catch (Exception ex) {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        public virtual async Task<TEntity> FindAsync(TId id) {
            return await _context.FindAsync<TEntity>(id);
        }

        public virtual async Task DeleteAsync(TId id) {
            Console.WriteLine($"Entidad a eliminar {id}");
            var entity = await _context.FindAsync<TEntity>(id);
            Console.WriteLine(entity);
            //Console.WriteLine(entity.City);
            _context.Remove<TEntity>(entity);
            await _context.SaveChangesAsync();
        }

    }
}