using GestionProvedores.Dto;

namespace GestionProvedores.Repositories
{
    public interface IEncuestaRepository
    {
        ResponseDto buscar(string json);

        ResponseDto respuesta(string json);

        ResponseDto finalizar(string json);

        ResponseDto validar(string json);
    }
}
