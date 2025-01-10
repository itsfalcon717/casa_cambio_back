using GestionProvedores.Dto;
using GestionProvedores.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionProvedores.Controllers
{
    [Route("api/consultaComprobante")]
    [ApiController]
    public class ConsultaComprobanteController : ControllerBase
    {
        private readonly IHttpApisService _httpApisService;

        public ConsultaComprobanteController(IHttpApisService httpApisService) {
            _httpApisService = httpApisService;
        }

        //[ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status401Unauthorized)]
        //[Produces("application/json")]
        //[Consumes("application/json")]
        //[HttpPost("filtra")]
        //public async Task<ResponseDto> Post()
        //{
        //    StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
        //    string content = reader.ReadToEndAsync().Result.ToString();
        //    var result = await this._httpApisService.consultaComprobantes(content);
        //    return result;
        //}

        //[ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status401Unauthorized)]
        //[Produces("application/json")]
        //[Consumes("application/json")]
        //[HttpPost("descargaRet")]
        //public async Task<ResponseDto> PostDesargaRet()
        //{
        //    StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
        //    string content = reader.ReadToEndAsync().Result.ToString();
        //    var result = await this._httpApisService.descargaRetencion(content);
        //    return result;
        //}

    }
}
