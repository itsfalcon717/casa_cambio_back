using GestionProvedores.Dto;
using GestionProvedores.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionProvedores.Controllers
{
    [Route("api/consultaOC")]
    [ApiController]
    public class ConsultaOcController : ControllerBase
    {
        private readonly IHttpApisService _httpApisService;

        public ConsultaOcController(IHttpApisService httpApisService) {
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
        //    var result = await this._httpApisService.consultaOrdenCompra(content);
        //    return result;
        //}

    }
}
