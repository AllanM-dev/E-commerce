using E_CommerceBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceBackend.Repositories
{
    public class GenericRepository<TEntity>: IGenericRepository<TEntity>
        where TEntity : class
    {
        public MyDbContext context { get; }
        public GenericRepository(MyDbContext myContext)
        {
            context = myContext;
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        public IQueryable<TEntity> GetAll()
        {
            return context.Set<TEntity>().AsNoTracking();
        }

        /// <summary>
        /// Create a new entity
        /// </summary>
        /// <param name="entity"></param>
        public async Task Create(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
        }
    }
}
