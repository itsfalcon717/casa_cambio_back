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
    [Route("api/usuario")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("login")]
        public ActionResult<TokenResponseDto> login(LoginBodyDto body)
        {
            return this._userService.Login(body);
        }


        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("cambiarClave")]
        public ActionResult<ResponseDto> cambiarClave()
        {
            StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
            string content = reader.ReadToEndAsync().Result.ToString();
            return this._userService.cambiarClave(content);
        }

        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("resetearClave")]
        public async Task<ResponseDto> resetearClave()
        {
            StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
            string content = reader.ReadToEndAsync().Result.ToString();
            var result = await this._userService.resetearClave(content);
            return result;
        }

        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("listar")]
        public ActionResult<ResponseDto> listar()
        {
            StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
            string content = reader.ReadToEndAsync().Result.ToString();
            return this._userService.listar(content);
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
            return this._userService.crear(content);
        }

        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("actualizar")]
        public ActionResult<ResponseDto> actualizar()
        {
            StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
            string content = reader.ReadToEndAsync().Result.ToString();
            return this._userService.actualizar(content);
        }

        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TokenResponseDto), StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("eliminar")]
        public ActionResult<ResponseDto> eliminar()
        {
            StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
            string content = reader.ReadToEndAsync().Result.ToString();
            return this._userService.eliminar(content);
        }
    }
}
