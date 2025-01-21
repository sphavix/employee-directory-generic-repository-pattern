using EmployeeDirectory.Persistence;
using EmployeeDirectory.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeDirectory.Repositories
{
    public class GenericRepository<T>(EmployeeDbContext context) : IGenericRepository<T> where T : class
    {
        private readonly EmployeeDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = _context.Set<T>();
            query = include.Aggregate(query, (current, include) => current.Include(include));
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(int id, params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = _context.Set<T>();
            query = include.Aggregate(query, (current, include) => current.Include(include));
            return await query.FirstOrDefaultAsync(x => EF.Property<int>(x, "Id") == id);
        }
        
        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if(entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }

            return entity;
        }

        

        
    }
}
