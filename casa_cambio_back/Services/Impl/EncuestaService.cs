using GestionProvedores.Dto;
using GestionProvedores.Repositories;

namespace GestionProvedores.Services.Impl
{
    public class EncuestaService : IEncuestaService
    {
        private readonly IEncuestaRepository _encuestaRepository;

        public EncuestaService(IEncuestaRepository encuestaRepository)
        {
            _encuestaRepository = encuestaRepository;
        }
        public ResponseDto buscar(string json)
        {
            return _encuestaRepository.buscar(json);
        }

        public ResponseDto finalizar(string json)
        {
            return _encuestaRepository.finalizar(json);
        }

        public ResponseDto respuesta(string json)
        {
            return _encuestaRepository.respuesta(json);
        }

        public ResponseDto validar(string json)
        {
            return _encuestaRepository.validar(json);
        }
    }
}
