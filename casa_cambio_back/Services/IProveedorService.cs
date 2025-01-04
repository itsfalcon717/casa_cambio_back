using GestionProvedores.Dto;

namespace GestionProvedores.Services
{
    public interface IProveedorService
    {
        Task<ResponseDto> crearAsync(string json);

        ResponseDto actualizar(string json);
        ResponseDto listar(string json);

        ResponseDto buscar(string json);

        ResponseDto aprobar(string json);

        ResponseDto buscarErp(string json);
    }
}