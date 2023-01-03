namespace E_CommerceBackend.Repositories
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task Create(TEntity entity);
    }
}
