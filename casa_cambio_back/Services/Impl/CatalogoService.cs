using GestionProvedores.Dto;
using GestionProvedores.Repositories;

namespace GestionProvedores.Services.Impl
{
    public class CatalogoServiceImpl : ICatalogoService
    {
        private readonly ICatalogoRepository _catalogoRepository;

        public CatalogoServiceImpl(ICatalogoRepository catalogoRepository)
        {
            _catalogoRepository = catalogoRepository;
        }
        public ResponseDto actualizar(string json)
        {
            return _catalogoRepository.actualizar(json);
        }

        public ResponseDto crear(string json)
        {
            return _catalogoRepository.crear(json);
        }

        public ResponseDto eliminar(string json)
        {
            return _catalogoRepository.eliminar(json);
        }

        public ResponseDto listar(string json)
        {
            return _catalogoRepository.listar(json);
        }
    }
}
