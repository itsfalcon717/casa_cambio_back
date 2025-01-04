using GestionProvedores.Dto;
using GestionProvedores.Repositories;

namespace GestionProvedores.Services.Impl
{
    public class UbicacionService : IUbicacionService
    {
        private readonly IUbicacionRepository _ubicacionRepository;

        public UbicacionService(IUbicacionRepository ubicacionRepository)
        {
            _ubicacionRepository = ubicacionRepository;
        }
        public ResponseDto actualizar(string json)
        {
            return _ubicacionRepository.actualizar(json);
        }

        public ResponseDto crear(string json)
        {
            return _ubicacionRepository.crear(json);
        }

        public ResponseDto eliminar(string json)
        {
            return _ubicacionRepository.eliminar(json);
        }

        public ResponseDto listar(string json)
        {
            return _ubicacionRepository.listar(json);
        }
    }
}
