namespace SRS.Core.Domain.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task CreateAsync(T entity);

    }
}
