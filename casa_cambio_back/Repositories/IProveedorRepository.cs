using GestionProvedores.Dto;

namespace GestionProvedores.Repositories
{
    public interface IProveedorRepository
    {
        ResponseDto crear(string json);

        ResponseDto actualizar(string json);

        ResponseDto listar(string json);

        ResponseDto buscar(string json);

        ResponseDto aprobar(string json);

        ResponseDto buscarErp(string json);

    }
}
