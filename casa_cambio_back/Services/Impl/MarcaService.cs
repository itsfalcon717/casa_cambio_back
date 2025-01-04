using GestionProvedores.Dto;
using GestionProvedores.Repositories;

namespace GestionProvedores.Services.Impl
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }
        public ResponseDto actualizar(string json)
        {
            return _marcaRepository.actualizar(json);
        }

        public ResponseDto crear(string json)
        {
            return _marcaRepository.crear(json);
        }

        public ResponseDto eliminar(string json)
        {
            return _marcaRepository.eliminar(json);
        }

        public ResponseDto listar(string json)
        {
            return _marcaRepository.listar(json);
        }
    }
}
