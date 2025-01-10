using Azure;
using GestionProvedores.Dto;
using GestionProvedores.Services;
using GestionProvedores.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace GestionProvedores.Controllers
{

    [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response), StatusCodes.Status500InternalServerError)]
    [ApiController]
    [Route("api/proveedor")]
    public class ProveedorController : Controller
    {
        private readonly IProveedorService _proveedorService;
        private readonly IHttpErpService _httpErpService;

        public ProveedorController(IProveedorService proveedorService, IHttpErpService httpErpService)
        {
            _proveedorService = proveedorService;
            _httpErpService = httpErpService;
        }

        //[ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status401Unauthorized)]
        //[Produces("application/json")]
        //[Consumes("application/json")]
        //[HttpPost("crear")]
        //public async Task<ResponseDto> crear()
        //{
        //    StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
        //    string content = reader.ReadToEndAsync().Result.ToString();
        //    var result = await this._proveedorService.crearAsync(content);
        //    return result;
        //}


        //[ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status401Unauthorized)]
        //[Produces("application/json")]
        //[Consumes("application/json")]
        //[HttpPut("actualizar")]
        //public ActionResult<ResponseDto> actualizar()
        //{
        //    StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
        //    string content = reader.ReadToEndAsync().Result.ToString();
        //    return this._proveedorService.actualizar(content);
        //}


        //[ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status401Unauthorized)]
        //[Produces("application/json")]
        //[Consumes("application/json")]
        //[HttpPost("listar")]
        //public ActionResult<ResponseDto> listar()
        //{
        //    StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
        //    string content = reader.ReadToEndAsync().Result.ToString();
        //    return this._proveedorService.listar(content);
        //}

        //// [Authorize]
        //[Produces("application/json")]
        //[HttpGet("buscar/{id}")]
        //public ActionResult<ResponseDto> buscar([FromRoute] int id)
        //{

        //    return this._proveedorService.buscar("{\"id\":" + id + "}");
        //}


        //[ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status401Unauthorized)]
        //[Produces("application/json")]
        //[Consumes("application/json")]
        //[HttpPut("aprobar")]
        //public ActionResult<ResponseDto> aprobar()
        //{
        //    StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
        //    string content = reader.ReadToEndAsync().Result.ToString();
        //    return this._proveedorService.aprobar(content);
        //}


        //// [Authorize]
        //[Produces("application/json")]
        //[HttpGet("subsanacion/{id}")]
        //public ActionResult<ResponseDto> subsanacion([FromRoute] int id)
        //{

        //    return this._proveedorService.buscar("{\"id\":" + id + "}");
        //}



        //[Produces("application/json")]
        //[HttpGet("erp/{id}")]
        //public async Task<object> erp([FromRoute] int id)
        //{
        //    var pro=_proveedorService.buscarErp("{\"id\":" + id + "}");

        //    Dictionary<string, object> data = pro.data as Dictionary<string, object>;
        //    string token = await _httpErpService.registrar(data);
        //    pro.message = token;
        //    return pro;
        //}

    }
}
