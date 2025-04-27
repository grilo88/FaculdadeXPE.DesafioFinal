using ECommerce.Domain.Aggregates.Clientes;
using ECommerce.Domain.Contracts;
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Services;

namespace ECommerce.Application.Features.Clientes.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IUnitOfWork unitOfWork,
                              IClienteRepository clienteRepository)
        {
            _unitOfWork = unitOfWork;
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> CreateClienteAsync(ClienteEntity cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nome) || 
                string.IsNullOrEmpty(cliente.Cpf.ToString()) ||
                string.IsNullOrEmpty(cliente.Telefone.ToString()) ||
                string.IsNullOrEmpty(cliente.Endereco))
            {
                return false; // Se os dados estiverem incorretos, retorne falso
            }

            await _clienteRepository.AddAsync(cliente);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> DeleteClienteAsync(long id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
            {
                return false; // Cliente não encontrado
            }

            await _clienteRepository.DeleteAsync(cliente.Id);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> UpdateClienteAsync(ClienteEntity cliente)
        {
            var clienteExistente = await _clienteRepository.GetByIdAsync(cliente.Id);
            if (clienteExistente == null)
            {
                return false; // Cliente não encontrado
            }

            clienteExistente.Atualizar(cliente.Nome,
                                       cliente.Cpf,
                                       cliente.Endereco,
                                       cliente.Telefone);

            await _clienteRepository.UpdateAsync(clienteExistente);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<IEnumerable<ClienteEntity>> GetAllClientesAsync()
        {
            return await _clienteRepository.GetAllAsync();
        }

        public async Task<ClienteEntity> ObterClientePorIdAsync(long id)
        {
            return await _clienteRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ClienteEntity>> GetClienteByNameAsync(string nome)
        {
            return await _clienteRepository.GetByNomeAsync(nome);
        }
    }
}
