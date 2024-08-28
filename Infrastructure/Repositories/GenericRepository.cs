using Domain.Interfaces;
using Domain.ViewModels;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly AppDbContext _context;
        public readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public IQueryable<T> Get(
       Expression<Func<T, bool>> filter = null,
       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
       int? pageIndex = null,
       int? pageSize = null,
       string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            // Apply filter
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Include properties
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            // Apply ordering
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            // Apply pagination
            if (pageIndex != null && pageSize != null)
            {
                query = query.Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }

            return query;
        }

        public void DeleteEntity(T entityToDelete)
        {
            if (entityToDelete == null)
            {
                throw new ArgumentNullException(nameof(entityToDelete));
            }

            _dbSet.Remove(entityToDelete);
        }
 

        public async Task<PaginatedList<T>> GetPagedDataAsync(int pageNumber, int pageSize)
        {
            var source = _context.Set<T>().AsQueryable();
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize)
                                     .Take(pageSize)
                                     .ToListAsync();

            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
    }
}