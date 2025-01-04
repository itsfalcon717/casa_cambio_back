namespace GestionProvedores.Services
{
    public interface IHttpErpService
    {
        Task<string> devuelveToken();

        Task<string> registrar(Dictionary<string, object> json);
    }
}
