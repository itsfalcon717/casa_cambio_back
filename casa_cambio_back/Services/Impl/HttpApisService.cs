using Azure;
using GestionProvedores.Dto;
using GestionProvedores.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionProvedores.Services.Impl
{
    public class HttpApisService: IHttpApisService
    {
        private readonly IConfiguration _configuration;

        public HttpApisService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private async Task<string> devuelveToken()
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

        public async Task<ResponseDto> consultaOrdenCompra(string json) {
            
            Console.WriteLine(json.ToString());
            ResponseDto response = new ResponseDto();
            string respuesta = "";
            try
            {
                var bodyRequest = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                var uri = _configuration["UrlConsultaOrdenCompra"];

                if (bodyRequest == null || bodyRequest.Values.Any(value => value == null))
                {
                    response.code = 400;
                    response.message = "Error en el body";
                    return response;
                }
                else if (uri == null || uri == "")
                {
                    response.code = 400;
                    response.message = "Uri no encontrada";
                    return response;
                }


                ValidateAndNormalizeDictionary(bodyRequest);
                
                    respuesta = consultaPost(bodyRequest, uri).Result;
                }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                response.code = 500;
                response.message = "Error en Api";
                return response;
                
            }
            if (respuesta != null && !respuesta.Equals("")) {
                var jsonBodyResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(respuesta);
                
                if (jsonBodyResponse != null && jsonBodyResponse.ContainsKey("body") && jsonBodyResponse["body"] is JArray bodyArray)
                {

                    if (bodyArray != null)
                    {
                        var bodyList = new List<Dictionary<string, object>>();
                        foreach (var item in bodyArray)
                        {
                            var ordenCompra = item.ToObject<Dictionary<string, object>>();

                            // Verificar si el campo "detalle" existe y es un JArray
                            if (ordenCompra!= null && ordenCompra.TryGetValue("detalle", out var detalleValue) && detalleValue is JArray detalleArray)
                            {
                                // Convertir cada item en "detalle" a Dictionary<string, object> y almacenar en una lista
                                var detalleList = new List<Dictionary<string, object>>();
                                foreach (var detalleItem in detalleArray)
                                {
                                    var detalleDict = detalleItem.ToObject<Dictionary<string, object>>();
                                    detalleList.Add(detalleDict);
                                }
                                // Reemplazar el JArray "detalle" con la lista de diccionarios
                                ordenCompra["detalle"] = detalleList;
                                bodyList.Add(ordenCompra);
                            }
                            
                        }

                        response.data = bodyList;
                        response.code = 200;
                        response.message = "Ok";
                        return response;
                    }
                    else
                    {
                        response.code = 400;
                        response.message = "Sin informacion";
                    }
                }
                else {
                    response.code = 400;
                    response.message = "Data Vacia";
                }
            }
            

            return response;
        
        }

        public async Task<ResponseDto> consultaComprobantes(string json)
        {

            Console.WriteLine(json.ToString());
            ResponseDto response = new ResponseDto();
            string respuesta = "";
            try
            {
                var bodyRequest = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                var uri = _configuration["UrlConsultaComprobantes"];

                if (bodyRequest == null || bodyRequest.Values.Any(value => value == null))
                {
                    response.code = 400;
                    response.message = "Error en el body";
                    return response;
                }
                else if (uri == null || uri == "") {
                    response.code = 400;
                    response.message = "Uri no encontrada";
                    return response;
                }



                ValidateAndNormalizeDictionary(bodyRequest);

                respuesta = consultaPost(bodyRequest, uri).Result;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                response.code = 500;
                response.message = "Error en Api";
                return response;

            }
            if (respuesta != null && !respuesta.Equals(""))
            {
                var jsonBodyResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(respuesta);

                if (jsonBodyResponse != null && jsonBodyResponse.ContainsKey("body") && jsonBodyResponse["body"] is JArray bodyArray)
                {

                    if (bodyArray != null)
                    {
                        var bodyList = new List<Dictionary<string, object>>();
                        foreach (var item in bodyArray)
                        {
                            if (item != null) {
                                var ordenCompra = item.ToObject<Dictionary<string, object>>();
                                if(ordenCompra != null)
                                bodyList.Add(ordenCompra);
                            }
                            //var ordenCompra = item.ToObject<Dictionary<string, object>>();

                            // Verificar si el campo "detalle" existe y es un JArray
                            /*if (ordenCompra != null && ordenCompra.TryGetValue("detalle", out var detalleValue) && detalleValue is JArray detalleArray)
                            {
                                // Convertir cada item en "detalle" a Dictionary<string, object> y almacenar en una lista
                                var detalleList = new List<Dictionary<string, object>>();
                                foreach (var detalleItem in detalleArray)
                                {
                                    var detalleDict = detalleItem.ToObject<Dictionary<string, object>>();
                                    detalleList.Add(detalleDict);
                                }
                                // Reemplazar el JArray "detalle" con la lista de diccionarios
                                ordenCompra["detalle"] = detalleList;
                                bodyList.Add(ordenCompra);
                            }*/

                        }

                        response.data = bodyList;
                        response.code = 200;
                        response.message = "Ok";
                        return response;
                    }
                    else
                    {
                        response.code = 400;
                        response.message = "Sin informacion";
                    }
                }
                else
                {
                    response.code = 400;
                    response.message = "Data Vacia";
                }
            }


            return response;

        }

        public async Task<ResponseDto> descargaRetencion(string json)
        {

            Console.WriteLine(json.ToString());
            ResponseDto response = new ResponseDto();
            var auxBody = new Dictionary<string, object>();
            string respuesta = "";
            try
            {
                var bodyRequest = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                var uri = _configuration["UrlDescargaRetencion"];

                if (bodyRequest == null || bodyRequest.Values.Any(value => value == null))
                {
                    response.code = 400;
                    response.message = "Error en el body";
                    return response;
                }
                else if (uri == null || uri == "")
                {
                    response.code = 400;
                    response.message = "Uri no encontrada";
                    return response;
                }


                auxBody = bodyRequest;
                ValidateAndNormalizeDictionary(bodyRequest);

                respuesta = consultaPost(bodyRequest, uri).Result;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                response.code = 500;
                response.message = "Error en Api";
                return response;

            }
            if (respuesta != null && !respuesta.Equals(""))
            {
                var jsonBodyResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(respuesta);

                if (jsonBodyResponse != null && jsonBodyResponse.ContainsKey("body"))
                {

                    if (jsonBodyResponse["body"] is string bodyString && !bodyString.Equals(""))
                    {
                        // Asignar el string directamente a la respuesta
                        Dictionary<string, object> resp = new Dictionary<string, object>();

                        resp.Add("archivo64", bodyString);
                        resp.Add("nombre", "Retencion_" + auxBody["serie"] + "_" + auxBody["numero"]);

                        response.data = resp;
                        response.code = 200;
                        response.message = "Ok";
                        return response;
                    }
                    else
                    {
                        response.code = 400;
                        response.message = "Sin informacion";
                    }
                }
                else
                {
                    response.code = 400;
                    response.message = "Data Vacia";
                }
            }


            return response;

        }

        static void ValidateAndNormalizeDictionary(Dictionary<string, object> json)
        {
            // Claves y valores predeterminados
            var defaultValues = new Dictionary<string, object>
        {
            { "string", "" },
            { "int", 0 }
        };

            // Recorremos el diccionario para verificar los valores
            foreach (var key in new List<string>(json.Keys))
            {
                var type = json[key].GetType();
                if (json[key] == null && type != typeof(int))
                {
                    json[key] = defaultValues["string"];
                }
                else
                {
                    
                    if (type == typeof(string) && string.IsNullOrEmpty(json[key] as string))
                    {
                        json[key] = defaultValues["string"];
                    }
                    else if (type == typeof(int) && (int)json[key] == 0)
                    {
                        json[key] = defaultValues["int"];
                    }
                }
            }
        }
        private async Task<string> consultaPost(Dictionary<string, object> json,string urlApi)
        {
            var url = urlApi;// _configuration["UrlConsultaOrdenCompra"];
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
