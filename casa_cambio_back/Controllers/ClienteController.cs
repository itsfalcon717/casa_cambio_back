using Azure;
using GestionProvedores.Dto;
using GestionProvedores.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace GestionProvedores.Controllers
{

    [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response), StatusCodes.Status500InternalServerError)]
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _ClienteService;

        public ClienteController(IClienteService ClienteService)
        {
            _ClienteService = ClienteService;
        }

        // [Authorize]
        [Produces("application/json")]
        [HttpGet("listar/{id}")]
        public ActionResult<ResponseDto> listar([FromRoute] int id)
        {

            return this._ClienteService.listar("{\"id\":" + id + "}");
        }

        // [Authorize]
        [Produces("application/json")]
        [HttpDelete("eliminar/{id}")]
        public ActionResult<ResponseDto> eliminar([FromRoute] int id)
        {

            return this._ClienteService.eliminar("{\"id\":" + id + "}");
        }


        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("crear")]
        public ActionResult<ResponseDto> crear()
        {
            StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
            string content = reader.ReadToEndAsync().Result.ToString();
            return this._ClienteService.crear(content);
        }


        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("actualizar")]
        public ActionResult<ResponseDto> actualizar()
        {
            StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
            string content = reader.ReadToEndAsync().Result.ToString();
            return this._ClienteService.actualizar(content);
        }
    }
}
