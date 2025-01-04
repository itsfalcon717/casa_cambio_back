using GestionProvedores.Dto;

namespace GestionProvedores.Services
{
    public interface ICorreoService
    {
        Task<bool> enviar(List<string> correos, string titulo, string htmlTemplate, List<(string archivo, string archivo64, string tipo)> archivos);

    }
}
