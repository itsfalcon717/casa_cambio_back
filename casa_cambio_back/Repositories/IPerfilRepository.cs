using GestionProvedores.Dto;

namespace GestionProvedores.Repositories
{
    public interface IPerfilRepository
    {
        ResponseDto listar(string json);
        ResponseDto buscar(string json);
        ResponseDto actualizarPermiso(string json);

        
    }
}
