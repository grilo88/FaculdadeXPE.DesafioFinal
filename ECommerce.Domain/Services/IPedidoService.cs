using ECommerce.Domain.Aggregates.Pedidos;
using ECommerce.Domain.Aggregates.Pedidos.DTOs;

namespace ECommerce.Domain.Services
{
    public interface IPedidoService
    {
        Task<bool> CreatePedidoAsync(PedidoEntity pedido, List<PedidoItemDto> itens);

        Task<bool> DeletePedidoAsync(long id);

        Task<IEnumerable<PedidoEntity>> GetAllPedidosAsync();

        Task<IEnumerable<PedidoEntity>> GetPedidosByStatusAsync(string status);
        
        Task<IEnumerable<PedidoEntity>> GetPedidosByNomeAsync(string nome);

        Task<PedidoEntity?> GetPedidoByIdAsync(long id);

        Task<bool> UpdatePedidoAsync(PedidoEntity pedido, List<PedidoItemDto> itens);
    }
}
