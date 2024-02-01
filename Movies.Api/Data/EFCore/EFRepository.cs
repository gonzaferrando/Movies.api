using Microsoft.EntityFrameworkCore;
using Movies.Api.Data.Abstractions;
using System.Linq.Expressions;

namespace Movies.Api.Data.EFCore
{
    public class EFRepository<TEntity, TContext> : IRepository<TEntity>
                                                    where TEntity : class, IEntity
                                                    where TContext : DbContext
    {
        private readonly TContext _context;
        public EFRepository(TContext context)
        {
            _context = context;
        }
        protected DbSet<TEntity> EntitySet
        {
            get
            {
                return _context.Set<TEntity>();
            }
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync() => await EntitySet.ToListAsync();
        public async Task<TEntity?> GetAsync(Guid Id) => await EntitySet.FindAsync(Id);
        public TEntity Insert(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            EntitySet.Add(entity);

            return entity;
        }
        public void Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                EntitySet.Attach(entity);
            }
            EntitySet.Remove(entity);
        }
        public void Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            EntitySet.Update(entity);
        }
        public async Task<List<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate) => await EntitySet.Where(predicate).ToListAsync();
        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() >= 0;

    }
}
