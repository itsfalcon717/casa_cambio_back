using GestionProvedores.Dto;
using GestionProvedores.Repositories;

namespace GestionProvedores.Services.Impl
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public ResponseDto actualizar(string json)
        {
            return _clienteRepository.actualizar(json);
        }

        public ResponseDto crear(string json)
        {
            return _clienteRepository.crear(json);
        }

        public ResponseDto eliminar(string json)
        {
            return _clienteRepository.eliminar(json);
        }

        public ResponseDto listar(string json)
        {
            return _clienteRepository.listar(json);
        }
    }
}
