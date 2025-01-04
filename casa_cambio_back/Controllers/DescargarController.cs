using Azure;
using GestionProvedores.Dto;
using GestionProvedores.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestionProvedores.Controllers
{
    [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response), StatusCodes.Status500InternalServerError)]
    [ApiController]
    [Route("api/descargar")]
    public class DescargarController : Controller
    {
        private readonly IDescargarService _descargarService;

        public DescargarController(IDescargarService descargarService)
        {
            _descargarService = descargarService;
        }
        // [Authorize]
        [Produces("application/json")]
        [HttpGet("respuesta/{id}")]
        public ActionResult<ResponseDto> respuesta([FromRoute] int id)
        {

            return this._descargarService.descargar("{\"cod\":0,\"id\":" + id + "}");
        }

        [Produces("application/json")]
        [HttpGet("pregunta/{id}")]
        public ActionResult<ResponseDto> pregunta([FromRoute] int id)
        {

            return this._descargarService.descargar("{\"cod\":2,\"id\":" + id + "}");
        }

        [Produces("application/json")]
        [HttpGet("catalogo/{id}")]
        public ActionResult<ResponseDto> catalogo([FromRoute] int id)
        {

            return this._descargarService.descargar("{\"cod\":1,\"id\":" + id + "}");
        }
    }
}