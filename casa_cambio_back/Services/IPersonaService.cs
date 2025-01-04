using GestionProvedores.Dto;

namespace GestionProvedores.Services
{
    public interface IPersonaService
    {
        ResponseDto crear(string json);

        ResponseDto actualizar(string json);

        ResponseDto listar(string json);

        ResponseDto eliminar(string json);

    }
}

