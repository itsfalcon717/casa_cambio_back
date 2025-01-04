using GestionProvedores.Dto;
using GestionProvedores.Repositories;

namespace GestionProvedores.Services.Impl
{
    public class MasterService : IMasterService
    {
        private readonly IMasterRepository _masterRepository;

        public MasterService(IMasterRepository masterRepository)
        {
            _masterRepository = masterRepository;
        }
        public ResponseDto listar(string json)
        {
            return _masterRepository.listar(json);
        }
    }
}
