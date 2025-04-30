using ECommerce.Domain.Aggregates.Pedidos;
using ECommerce.Domain.Aggregates.Pedidos.DTOs;
using ECommerce.Domain.Contracts;
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Services;
using static ECommerce.Domain.Aggregates.Pedidos.PedidoEntity;

namespace ECommerce.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;

        public PedidoService(IUnitOfWork unitOfWork,
                             IPedidoRepository pedidoRepository,
                             IProdutoRepository produtoRepository)
        {
            _unitOfWork = unitOfWork;
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> CreatePedidoAsync(PedidoEntity pedido, List<PedidoItemDto> itens)
        {
            if (pedido.ClienteId <= 0)
                return false;

            var produtos = (await _produtoRepository.GetAllAsync()).ToList();

            if (itens != null && 
                itens.Any())
            {
                var itensValidados = new List<PedidoItemEntity>();

                foreach (var item in itens)
                {
                    var produto = produtos.FirstOrDefault(x => x.Id == item.ProdutoId);

                    if (produto == null)
                        return false;

                    itensValidados.Add(new PedidoItemEntity(
                        item.Id,
                        pedido,
                        produto,
                        item.Quantidade));
                }

                pedido.DefinirItens(itensValidados);
            }

            await _pedidoRepository.AddAsync(pedido);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> UpdatePedidoAsync(PedidoEntity pedido, List<PedidoItemDto> itens)
        {
            var pedidoExistente = await _pedidoRepository.GetByIdAsync(pedido.Id);
            if (pedidoExistente == null)
                return false;

            var produtos = (await _produtoRepository.GetAllAsync()).ToList();
            var itensValidados = new List<PedidoItemEntity>();

            if (itens != null && 
                itens.Any())
            {
                foreach (var item in itens)
                {
                    var produto = produtos.FirstOrDefault(p => p.Id == item.ProdutoId);
                    if (produto == null)
                        return false;

                    itensValidados.Add(new PedidoItemEntity(
                        item.Id,
                        pedidoExistente,
                        produto,
                        item.Quantidade));
                }
            }

            pedidoExistente.Atualizar(
                pedido.ClienteId,
                pedido.Status,
                itensValidados);

            await _pedidoRepository.UpdateAsync(pedidoExistente);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> DeletePedidoAsync(long id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);

            if (pedido == null)
                return false;

            await _pedidoRepository.DeleteAsync(pedido.Id);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<IEnumerable<PedidoEntity>> GetAllPedidosAsync()
        {
            return await _pedidoRepository.GetAllPedidosAsync();
        }

        public async Task<IEnumerable<PedidoEntity>> GetPedidosByStatusAsync(string status)
        {
            return await _pedidoRepository.GetPedidosByStatusAsync(status);
        }

        public async Task<PedidoEntity?> GetPedidoByIdAsync(long id)
        {
            return await _pedidoRepository.GetPedidoByIdAsync(id);
        }

        public Task<IEnumerable<PedidoEntity>> GetPedidosByNomeAsync(string nome)
        {
            return _pedidoRepository.GetPedidosByClienteNomeAsync(nome);
        }
    }
}
