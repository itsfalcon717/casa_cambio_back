using GestionProvedores.Dto;

namespace GestionProvedores.Services
{
    public interface ICuentaService
    {
        ResponseDto crear(string json);

        ResponseDto actualizar(string json);

        ResponseDto listar(string json);

        ResponseDto eliminar(string json);
    }
}

