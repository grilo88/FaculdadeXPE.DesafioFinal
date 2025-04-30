using ECommerce.Domain.Aggregates.Pedidos.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Pedidos.Commands.Requests
{
    public class CreatePedidoCommandRequest : IRequest<bool>
    {
        public long Id { get; init; }

        public long ClienteId { get; init; }

        public string Status { get; init; }

        public List<PedidoItemDto> Itens { get; init; } = new();
    }
}
