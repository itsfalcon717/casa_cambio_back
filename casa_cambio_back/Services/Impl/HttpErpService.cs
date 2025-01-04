using GestionProvedores.Exceptions;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionProvedores.Services.Impl
{
    public class HttpErpService: IHttpErpService
    {
        private readonly IConfiguration _configuration;

        public HttpErpService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> devuelveToken()
        {
            var url = _configuration["tokenERP:Url"];
            var username = _configuration["tokenERP:Username"];
            var password = _configuration["tokenERP:Password"];

            var requestData = new
            {
                Idempresa = "1",
                NomUsuario = username,
                Contrasena = password
            };
            var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

            try
            {
               HttpClient client = new HttpClient();
                var response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();

                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody);

                return dictionary["token"].ToString(); ; // Retorna el contenido de la respuesta
            }
            catch (Exception ex)
            {
                throw new BadRequestCustomerException(ex.Message);
            }
        }
        public async Task<string> registrar(Dictionary<string, object> json)
        {
            var url = _configuration["UrlRegistroErp"];
            string token = await devuelveToken();
            if(token != null)
            try
            {
                HttpClient client = new HttpClient();
                var jsonData = JsonConvert.SerializeObject(json);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Añadir el encabezado de autorización
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                // Enviar solicitud POST
                HttpResponseMessage response = await client.PostAsync(url, content);

                // Leer la respuesta
                string responseBody = await response.Content.ReadAsStringAsync();

                return responseBody;
            }
            catch (Exception ex)
            {
                    throw new BadRequestCustomerException(ex.Message);
                }
            return null;
        }

    }
}
