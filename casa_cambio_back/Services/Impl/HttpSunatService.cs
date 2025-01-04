using GestionProvedores.Exceptions;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionProvedores.Services.Impl
{
    public class HttpSunatService : IHttpSunatService
    {
        private readonly IConfiguration _configuration;

        public HttpSunatService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> devuelveToken()
        {
            var url = _configuration["tokenSunat:Url"];
            var username = _configuration["tokenSunat:Username"];
            var password = _configuration["tokenSunat:Password"];

            var requestData = new
            {
                userName = username,
                password = password
            };
            var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

            try
            {
               HttpClient client = new HttpClient();
                var response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();

                var dictionaryBody = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody);

                if (dictionaryBody != null) {
                    var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(dictionaryBody["response"].ToString());
                    return dictionary["token"].ToString(); // Retorna el contenido de la respuesta
                }
                return null;

                
            }
            catch (Exception ex)
            {
                throw new BadRequestCustomerException(ex.Message);
            }
        }
        public async Task<string> consultar(Dictionary<string, object> json)
        {
            var url = _configuration["UrlDatosSunatProveedor"];
            string token = await devuelveToken();
            if (token != null) {
                int maxRetries = 3;
                int delayBetweenRetries = 1000; // Milisegundos
                int attempt = 0;

                while (attempt < maxRetries) {
                    try
                    {
                        using (HttpClient client = new HttpClient())
                        {
                            var jsonData = JsonConvert.SerializeObject(json);
                            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                            // Añadir el encabezado de autorización
                            client.DefaultRequestHeaders.Clear();
                            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                            // Enviar solicitud GET
                            HttpResponseMessage response = await client.GetAsync(url + json["ruc"].ToString());

                            // Verificar si la solicitud fue exitosa
                            if (response.IsSuccessStatusCode)
                            {
                                // Leer la respuesta
                                return await response.Content.ReadAsStringAsync();
                            }
                            else
                            {
                                // Si no fue exitosa, lanzar excepción para intentar nuevamente
                                throw new HttpRequestException($"Error en la solicitud: {response.StatusCode}");
                            }
                        }
                    }
                    catch (Exception ex) when (attempt < maxRetries - 1) // Evitar que se lance en el último intento
                    {
                        // Esperar antes del próximo intento
                        await Task.Delay(delayBetweenRetries);
                        attempt++;
                    }
                }
            }
            
            return null;
        }

    }
}
