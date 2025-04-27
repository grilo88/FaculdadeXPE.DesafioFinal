using ECommerce.Domain.Aggregates.Clientes;
using ECommerce.Domain.Contracts;

namespace ECommerce.Domain.Repositories
{
    public interface IClienteRepository : IRepository<ClienteEntity>
    {
        Task<IEnumerable<ClienteEntity>> GetByNomeAsync(string nome);
    }
}
