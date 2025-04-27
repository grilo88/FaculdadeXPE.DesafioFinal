using ECommerce.Domain.Aggregates.Clientes;

namespace ECommerce.Domain.Services
{
    public interface IClienteService
    {
        Task<bool> CreateClienteAsync(ClienteEntity cliente);

        Task<bool> DeleteClienteAsync(long id);
        
        Task<IEnumerable<ClienteEntity>> GetAllClientesAsync();

        Task<IEnumerable<ClienteEntity>> GetClienteByNameAsync(string nome);

        Task<ClienteEntity> ObterClientePorIdAsync(long id);

        Task<bool> UpdateClienteAsync(ClienteEntity cliente);
    }
}
