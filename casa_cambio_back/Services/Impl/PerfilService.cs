using GestionProvedores.Dto;
using GestionProvedores.Repositories;
using GestionProvedores.Repositories.Impl;

namespace GestionProvedores.Services.Impl
{
    public class PerfilService : IPerfilService
    {
        private readonly IPerfilRepository _perfilRepository;

        public PerfilService(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }

        public ResponseDto actualizarPermiso(string json)
        {
            return _perfilRepository.actualizarPermiso(json);
        }

        public ResponseDto buscar(string json)
        {
            return _perfilRepository.buscar(json);
        }

        public ResponseDto listar(string json)
        {
            return _perfilRepository.listar(json);
        }
    }
}
