using GestionProvedores.Dto;
using GestionProvedores.Repositories;

namespace GestionProvedores.Services.Impl
{
    public class CuentaService : ICuentaService
    {
        private readonly ICuentaRepository _cuentaRepository;

        public CuentaService(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
        }
        public ResponseDto actualizar(string json)
        {
            return _cuentaRepository.actualizar(json);
        }

        public ResponseDto crear(string json)
        {
            return _cuentaRepository.crear(json);
        }

        public ResponseDto eliminar(string json)
        {
            return _cuentaRepository.eliminar(json);
        }

        public ResponseDto listar(string json)
        {
            return _cuentaRepository.listar(json);
        }
    }
}
