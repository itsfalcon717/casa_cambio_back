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
    [Route("api/perfil")]
    public class PerfilController : Controller
    {
        private readonly IPerfilService _perfilService;
        private readonly IHttpErpService _httpErpService;

        public PerfilController(IPerfilService perfilService, IHttpErpService httpErpService)
        {
            _perfilService = perfilService;
            _httpErpService = httpErpService;
        }

        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("listar")]
        public ActionResult<ResponseDto> listar()
        {
            StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
            string content = reader.ReadToEndAsync().Result.ToString();
            return this._perfilService.listar(content);
        }

        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("listarPermiso/{id}")]
        public ActionResult<ResponseDto> listarPermisoId([FromRoute] int id)
        {
            return this._perfilService.buscar("{\"id\":" + id + "}");
        }

        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("actualizarPermiso")]
        public ActionResult<ResponseDto> actualizarPermiso()
        {
            StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
            string content = reader.ReadToEndAsync().Result.ToString();
            return this._perfilService.actualizarPermiso(content);
        }
    }
}
