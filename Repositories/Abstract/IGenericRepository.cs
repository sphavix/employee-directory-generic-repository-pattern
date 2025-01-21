using System.Linq.Expressions;

namespace EmployeeDirectory.Repositories.Abstract
{
    public interface IGenericRepository<T>
    {
        Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] include);

        Task<T> GetAsync(int id, params Expression<Func<T, object>>[] include);

        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<T> DeleteAsync(int id);
    }
}
