using Microsoft.EntityFrameworkCore;

namespace FaculdadeXPE.ECommerceOnline.Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();

        void Rollback();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
