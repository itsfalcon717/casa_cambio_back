using GestionProvedores.Dto;
using GestionProvedores.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace GestionProvedores.Services.Impl
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository _proveedorRepository;

        private readonly ICorreoService _correoService;

        private readonly IHttpSunatService _httpSunatService;

        public ProveedorService(IProveedorRepository proveedorRepository, ICorreoService correoService, IHttpSunatService httpSunatService)
        {
            _proveedorRepository = proveedorRepository;
            _correoService = correoService;
            _httpSunatService = httpSunatService;
        }
        public async Task<ResponseDto> crearAsync(string json)
        {
            var bodyRequest = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            string respuesta = "";

            try {
                if (bodyRequest["idTipoProveedor"].Equals("1")) {
                    respuesta = _httpSunatService.consultar(bodyRequest).Result;
                }
            }catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            if (respuesta != null && !respuesta.Equals("")) {
                var jsonBodyResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(respuesta);

                if (jsonBodyResponse!= null && jsonBodyResponse.TryGetValue("body", out var bodyObject) && bodyObject is JObject bodyJObjec)
                {
                    var bodyDict = bodyJObjec.ToObject<Dictionary<string, object>>();

                    if (bodyRequest["razonSocial"] == null || bodyRequest["razonSocial"].Equals("")) {
                        if (bodyDict.TryGetValue("razonSocial", out var razonSocial))
                        {
                            bodyRequest["razonSocial"] = razonSocial;
                        }
                    }
                    // Obtener el valor de "nombreComercial"
                    if (bodyDict.TryGetValue("nombreComercial", out var nombreComercial))
                    {
                        bodyRequest["nombreComercial"] = nombreComercial;
                    }

                    if (bodyDict.TryGetValue("fechaInscripcion", out var fechaInscripcion))
                    {
                        bodyRequest["fechaConstitucion"] = fechaInscripcion;
                    }

                    if (bodyDict.TryGetValue("domicilioFiscal", out var domicilioFiscal))
                    {
                        bodyRequest["direccionFiscal"] = domicilioFiscal;
                    }
                    if (bodyDict.TryGetValue("estadoContribuyente", out var estadoContribuyente))
                    {
                        bodyRequest["sunatActivo"] = estadoContribuyente.Equals("ACTIVO") ? "1":"0";
                    }
                    if (bodyDict.TryGetValue("condicionContribuyente", out var condicionContribuyente))
                    {
                        bodyRequest["sunarHabido"] = condicionContribuyente.Equals("HABIDO") ? "1" : "0";
                    }
                    json = JsonConvert.SerializeObject(bodyRequest, Formatting.Indented);
                }
            }
            var response =_proveedorRepository.crear(json);
            if(response.code>0)
            {
                Dictionary<string, object> jsonObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

                Dictionary<string, object> data =response.data  as Dictionary<string, object>;

                string pPlantilla = data["plantilla"].ToString();
                data.Remove("plantilla");

                List<string> correos = new List<string>();
                correos.Add(jsonObject["correo"].ToString());
          

                 await _correoService.enviar(correos, "Registro de Usuarios", pPlantilla, null);

            }

            return response;

        }

        public ResponseDto actualizar(string json)
        {
            return _proveedorRepository.actualizar(json);
        }

        public ResponseDto listar(string json)
        {
            return _proveedorRepository.listar(json);
        }

        public ResponseDto buscar(string json)
        {
            return _proveedorRepository.buscar(json);
        }

        public ResponseDto aprobar(string json)
        {
            return _proveedorRepository.aprobar(json);
        }

        public ResponseDto buscarErp(string json)
        {
            return _proveedorRepository.buscarErp(json);
        }
    }
}
