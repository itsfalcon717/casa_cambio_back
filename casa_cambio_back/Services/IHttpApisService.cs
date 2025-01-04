using GestionProvedores.Dto;

namespace GestionProvedores.Services
{
    public interface IHttpApisService
    {
        //Task<string> devuelveToken();

        Task<ResponseDto> consultaOrdenCompra(string json);
        Task<ResponseDto> consultaComprobantes(string json);
        Task<ResponseDto> descargaRetencion(string json);
    }
}
