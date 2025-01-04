namespace GestionProvedores.Services
{
    public interface IHttpSunatService
    {
        Task<string> devuelveToken();

        Task<string> consultar(Dictionary<string, object> json);
    }
}
