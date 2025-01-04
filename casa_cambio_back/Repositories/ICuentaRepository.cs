using GestionProvedores.Dto;

namespace GestionProvedores.Repositories
{
    public interface ICuentaRepository
    {
        ResponseDto crear(string json);

        ResponseDto actualizar(string json);

        ResponseDto listar(string json);

        ResponseDto eliminar(string json);
    }
}
