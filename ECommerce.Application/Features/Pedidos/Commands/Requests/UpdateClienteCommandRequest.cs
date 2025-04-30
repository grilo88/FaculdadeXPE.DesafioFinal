using ECommerce.Domain.Aggregates.Pedidos.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Pedidos.Commands.Requests
{
    public class UpdatePedidoCommandRequest : IRequest<bool>
    {
        public long Id { get; set; }

        public long ClienteId { get; set; }

        public string Status { get; set; }

        public List<PedidoItemDto> Itens { get; set; }
    }
}
