using GestionProvedores.Dto;

namespace GestionProvedores.Services
{
    public interface IDescargarService
    {
        ResponseDto descargar(string json);
    }
}
