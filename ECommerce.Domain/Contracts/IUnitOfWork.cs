using Microsoft.EntityFrameworkCore;

namespace ECommerce.Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();

        void Rollback();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
