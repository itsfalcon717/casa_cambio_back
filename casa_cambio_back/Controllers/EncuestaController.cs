using Azure;
using GestionProvedores.Dto;
using GestionProvedores.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;

namespace GestionProvedores.Controllers
{

    [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response), StatusCodes.Status500InternalServerError)]
    [ApiController]
    [Route("api/encuesta")]
    public class EncuestaController : Controller
    {
        private readonly IEncuestaService _encuestaService;

        public EncuestaController(IEncuestaService encuestaService)
        {
            _encuestaService = encuestaService;
        }

        // [Authorize]
        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("buscar")]
        public ActionResult<ResponseDto> buscar()
        {
            StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
            string content = reader.ReadToEndAsync().Result.ToString();
            return this._encuestaService.buscar(content);
        }


        // [Authorize]
        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("respuesta")]
        public ActionResult<ResponseDto> respuesta()
        {
            StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
            string content = reader.ReadToEndAsync().Result.ToString();
            return this._encuestaService.respuesta(content);
        }

        // [Authorize]
        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("finalizar")]
        public ActionResult<ResponseDto> finalizar()
        {
            StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
            string content = reader.ReadToEndAsync().Result.ToString();
            return this._encuestaService.finalizar(content);
        }

        // [Authorize]
        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("validar")]
        public ActionResult<ResponseDto> validar()
        {
            StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
            string content = reader.ReadToEndAsync().Result.ToString();
            return this._encuestaService.validar(content);
        }


        [Produces("application/json")]
        [HttpGet("validacionArchivo/{id}")]
        public ActionResult<ResponseDto> validacionArchivo([FromRoute] int id)
        {
            var response = new ResponseDto();
            response.code = 1;
            response.statusCode = HttpStatusCode.OK;
            return response;
        }
    }
}
