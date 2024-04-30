using System.Linq.Expressions;


namespace SparrowManagementSystem.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> CreateAsync(T entity);
        public Task<T> GetByIdAsync(int id);
        public Task<T> GetByGuidAsync(Guid id);
        public Task<T> UpdateAsync(T entity);
        public Task<T> DeleteAsync(T entity);
        Task<IEnumerable<T>> EntityWithEagerLoad(Expression<Func<T, bool>> filter, string[] entities);
    }
}
