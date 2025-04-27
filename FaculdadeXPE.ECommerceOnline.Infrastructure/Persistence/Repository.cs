using FaculdadeXPE.ECommerceOnline.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FaculdadeXPE.ECommerceOnline.Infrastructure.Persistence
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _dbSet.Update(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Entity with ID {id} not found.");

            _dbSet.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }
    }
}
