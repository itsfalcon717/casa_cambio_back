using GestionProvedores.Dto;

namespace GestionProvedores.Services
{
    public interface IPerfilService
    {
        ResponseDto listar(string json);
        ResponseDto buscar(string json);

        ResponseDto actualizarPermiso(string json);

    }
}
