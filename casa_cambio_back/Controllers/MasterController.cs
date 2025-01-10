using Azure;
using GestionProvedores.Dto;
using GestionProvedores.Exceptions;
using GestionProvedores.Repositories;
using GestionProvedores.Services;
using GestionProvedores.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace GestionProvedores.Controllers
{

    [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response), StatusCodes.Status500InternalServerError)]
    [ApiController]
    [Route("api/master")]
    public class MasterController : Controller
    {
        private readonly IMasterService _masterService;

        public MasterController(IMasterService masterService)
        {
            _masterService = masterService;
        }

        //[Authorize]
        //[Produces("application/json")]
        //[HttpGet("listarPaises")]
        //public ActionResult<ResponseDto> listarPaises()
        //{

        //    return this._masterService.listar("{\"cod\":0}");
        //}


        //// [Authorize]
        //[Produces("application/json")]
        //[HttpGet("listarRegion")]
        //public ActionResult<ResponseDto> listarRegiones()
        //{

        //    return this._masterService.listar("{\"cod\":1}");
        //}


        //// [Authorize]
        //[Produces("application/json")]
        //[HttpGet("listarProvincia/{id}")]
        //public ActionResult<ResponseDto> listarProvincia([FromRoute] int id)
        //{

        //    return this._masterService.listar("{\"cod\":2,\"id\":" + id + "}");
        //}

        //// [Authorize]
        //[Produces("application/json")]
        //[HttpGet("listarDistrito/{id}")]
        //public ActionResult<ResponseDto> listarDistrito([FromRoute] int id)
        //{

        //    return this._masterService.listar("{\"cod\":3,\"id\":" + id + "}");
        //}


        ////[Authorize]
        //[Produces("application/json")]
        //[HttpGet("listarGiroNegocio/{id}")]
        //public ActionResult<ResponseDto> listarGiroNegocio([FromRoute] int id)
        //{

        //    return this._masterService.listar("{\"cod\":4,\"id\":" + id + "}");
        //}

        ////[Authorize]
        //[Produces("application/json")]
        //[HttpGet("listarTipoPersona")]
        //public ActionResult<ResponseDto> listarTipoPersona()
        //{

        //    return this._masterService.listar("{\"cod\":5}");
        //}


        ////[Authorize]
        //[Produces("application/json")]
        //[HttpGet("listarCategoriaProveedor")]
        //public ActionResult<ResponseDto> listarCategoriaProveedor()
        //{

        //    return this._masterService.listar("{\"cod\":6}");
        //}


        ////[Authorize]
        //[Produces("application/json")]
        //[HttpGet("listarEstadoProveedor")]
        //public ActionResult<ResponseDto> listarEstadoProveedor()
        //{

        //    return this._masterService.listar("{\"cod\":7}");
        //}

        ////[Authorize]
        //[Produces("application/json")]
        //[HttpGet("listarTipoProveedor")]
        //public ActionResult<ResponseDto> listarTipoProveedor()
        //{

        //    return this._masterService.listar("{\"cod\":8}");
        //}

        ////[Authorize]
        //[Produces("application/json")]
        //[HttpGet("listarRamaNegocio/{id}")]
        //public ActionResult<ResponseDto> listarRamaNegocio([FromRoute] int ? id)
        //{

        //    return this._masterService.listar("{\"cod\":9,\"id\":" + id + "}");
        //}

        ////[Authorize]
        //[Produces("application/json")]
        //[HttpGet("listarTipoCliente")]
        //public ActionResult<ResponseDto> listarTipoCliente()
        //{

        //    return this._masterService.listar("{\"cod\":10}");
        //}


        ////[Authorize]
        //[Produces("application/json")]
        //[HttpGet("listarTipoContribuyente")]
        //public ActionResult<ResponseDto> listarTipoContribuyente()
        //{

        //    return this._masterService.listar("{\"cod\":11}");
        //}

        ////[Authorize]
        //[Produces("application/json")]
        //[HttpGet("listarTipoCuenta")]
        //public ActionResult<ResponseDto> listarTipoCuenta()
        //{

        //    return this._masterService.listar("{\"cod\":12}");
        //}

        ////[Authorize]
        //[Produces("application/json")]
        //[HttpGet("listarTipoDocumento")]
        //public ActionResult<ResponseDto> listarTipoDocumento()
        //{

        //    return this._masterService.listar("{\"cod\":13}");
        //}


        ////[Authorize]
        //[Produces("application/json")]
        //[HttpGet("listarTipoMoneda/{id}")]
        //public ActionResult<ResponseDto> listarTipoMoneda([FromRoute] int ? id)
        //{
        //    return this._masterService.listar("{\"cod\":14,\"id\":" + id + "}");
        //}


        ////[Authorize]
        //[Produces("application/json")]
        //[HttpGet("listarTipoUbicacion")]
        //public ActionResult<ResponseDto> listarTipoUbicacion()
        //{

        //    return this._masterService.listar("{\"cod\":15}");
        //}

        ////[Authorize]
        //[Produces("application/json")]
        //[HttpGet("listarOperacionesAfectadas")]
        //public ActionResult<ResponseDto> listarOperacionesAfectadas()
        //{

        //    return this._masterService.listar("{\"cod\":16}");
        //}

 


        ////[Authorize]
        //[Produces("application/json")]
        //[HttpGet("listarCondicionPago")]
        //public ActionResult<ResponseDto> listarCondicionPago()
        //{

        //    return this._masterService.listar("{\"cod\":17}");
        //}


        ////[Authorize]
        //[Produces("application/json")]
        //[HttpGet("listarTipoComprobante/{id}")]
        //public ActionResult<ResponseDto> listarTipoComprobante([FromRoute] int ? id)
        //{
        //    return this._masterService.listar("{\"cod\":18,\"id\":" + id + "}");
        //}


        ////[Authorize]
        //[Produces("application/json")]
        //[HttpGet("listarEntidadBancaria")]
        //public ActionResult<ResponseDto> listarEntidadBancaria()
        //{

        //    return this._masterService.listar("{\"cod\":19}");
        //}


        ////[Authorize]
        //[Produces("application/json")]
        //[HttpGet("listarEmpresa")]
        //public ActionResult<ResponseDto> listarEmpresa()
        //{

        //    return this._masterService.listar("{\"cod\":20}");
        //}


        ////[Authorize]
        //[Produces("application/json")]
        //[HttpGet("listarTipoCalle")]
        //public ActionResult<ResponseDto> listarTipoCalle()
        //{

        //    return this._masterService.listar("{\"cod\":21}");
        //}

        ////[Authorize]
        //[Produces("application/json")]
        //[HttpGet("listarTipoDireccion")]
        //public ActionResult<ResponseDto> listarTipoDireccion()
        //{

        //    return this._masterService.listar("{\"cod\":22}");
        //}

        ////[Authorize]
        //[Produces("application/json")]
        //[HttpGet("listarTipoZona")]
        //public ActionResult<ResponseDto> listarTipoZona()
        //{

        //    return this._masterService.listar("{\"cod\":23}");
        //}

        ////[Authorize]
        //[Produces("application/json")]
        //[HttpGet("listarZona")]
        //public ActionResult<ResponseDto> listarZona()
        //{

        //    return this._masterService.listar("{\"cod\":24}");
        //}
    }
}
