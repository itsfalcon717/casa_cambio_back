using GestionProvedores.Dto;

namespace GestionProvedores.Repositories
{
    public interface IDescargarRepository
    {
        ResponseDto descargar(string json);
    }
}
