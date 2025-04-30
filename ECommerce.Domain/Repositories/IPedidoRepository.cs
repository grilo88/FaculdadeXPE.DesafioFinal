using ECommerce.Domain.Aggregates.Pedidos;
using ECommerce.Domain.Contracts;
using static ECommerce.Domain.Aggregates.Pedidos.PedidoEntity;

namespace ECommerce.Domain.Repositories
{
    public interface IPedidoRepository : IRepository<PedidoEntity>
    {
        Task<IEnumerable<PedidoEntity>> GetPedidosByStatusAsync(string status);

        Task<IEnumerable<PedidoEntity>> GetPedidosByClienteIdAsync(long clienteId);

        Task<IEnumerable<PedidoEntity>> GetPedidosByClienteNomeAsync(string nome);

        Task<IEnumerable<PedidoEntity>> GetAllPedidosAsync();

        Task<PedidoEntity?> GetPedidoByIdAsync(long id);
    }
}
