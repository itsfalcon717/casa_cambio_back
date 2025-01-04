using GestionProvedores.Dto;

namespace GestionProvedores.Repositories
{
    public interface IMasterRepository
    {
        ResponseDto listar(string json);
    }
}
