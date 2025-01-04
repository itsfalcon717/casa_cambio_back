using GestionProvedores.Dto;

namespace GestionProvedores.Services
{
    public interface IEncuestaService
    {
        ResponseDto buscar(string json);

        ResponseDto respuesta(string json);
        ResponseDto finalizar(string json);

        ResponseDto validar(string json);
                
    }
}
