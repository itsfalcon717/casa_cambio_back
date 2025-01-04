using GestionProvedores.Dto;
using GestionProvedores.Repositories;

namespace GestionProvedores.Services.Impl
{
    public class DescargarService : IDescargarService
    {
        private readonly IDescargarRepository _descargarRepository;

        public DescargarService(IDescargarRepository descargarRepository)
        {
            _descargarRepository = descargarRepository;
        }
        public ResponseDto descargar(string json)
        {
            return _descargarRepository.descargar(json);
        }
    }
}
