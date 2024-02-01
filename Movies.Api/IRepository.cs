using Movies.Api.Data.Abstractions;
using System.Linq.Expressions;

namespace Movies.Api
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetAsync(Guid id);
        TEntity Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<List<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> SaveChangesAsync();
    }
}
