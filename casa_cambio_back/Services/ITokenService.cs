using static System.Net.Mime.MediaTypeNames;
using System.Security.Claims;

namespace GestionProvedores.Services
{
    public interface ITokenService
    {
        string CreateToken(Dictionary<string, object> row);

        ClaimsPrincipal ValidateToken(string token);

        string RefreshToken(string oldToken, Dictionary<string, object> row);
    }
}
