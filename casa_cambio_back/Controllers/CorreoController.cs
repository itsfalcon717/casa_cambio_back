using Azure;
using GestionProvedores.Dto;
using GestionProvedores.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GestionProvedores.Controllers
{
    [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response), StatusCodes.Status500InternalServerError)]
    [ApiController]
    [Route("api/correo")]
    public class CorreoController : Controller
    {

        private readonly ICorreoService _correoService;

        public CorreoController(ICorreoService correoService)
        {
            _correoService = correoService;
        }

        // [Authorize]
        [Produces("application/json")]
        [HttpGet("enviarPrueba")]
        public async Task<IActionResult> enviarPrueba()
        {
            List<string> correos = new List<string>();
            correos.Add("ederharo@gmail.com");
            string titulo = "prueba";
            string htmlTemplate = "<!DOCTYPE html>\r\n<html lang=\"es\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Invitación a Participar</title>\r\n</head>\r\n<body>\r\n    <p>Estimado,</p>\r\n    <p><strong>(param_1)</strong></p>\r\n    <p>Se les invita a participar como proveedor de productos y/o servicios, para tal motivo debe ingresar a nuestro portal y cargar la información solicitada <a href=\"URL_DEL_PORTAL\">Aquí</a>.</p>\r\n    <table>\r\n        <tr>\r\n            <td><strong>Usuario:</strong></td>\r\n            <td>usuario_proveedor</td> <!-- Sustituir \"usuario_proveedor\" con el usuario real -->\r\n        </tr>\r\n        <tr>\r\n            <td><strong>Password:</strong></td>\r\n            <td>(param_2)</td> \r\n        </tr>\r\n    </table>\r\n</body>\r\n</html>";
            List<(string archivo, string archivo64, string tipo)> archivos = new List<(string , string , string )>();
            archivos.Add((
                archivo: "docs_24dp_FFFF_FILL0_wght400_GRAD0_opsz24.png",
                archivo64: "iVBORw0KGgoAAAANSUhEUgAAAGAAAABgCAYAAADimHc4AAAAAXNSR0IArs4c6QAAA11JREFUeF7tnVF61DAMhK2b0JMUTgKcpOUkcBPKSehNzLpf9iOkNFNnpJWTzL70wZEtzS/J3m27tqJXqgKWuroWLwKQnAQCIADJCiQvrwoQgGQFkpdXBRwNQK31Qynlcyml/fw4/cwM89HMvmU6sLa2awXUWr+UUr4PGOywENwA1Fp/Thk/oP4vLg0JwQVArfWhBTiq8jO/hoNAA5h6/u8diH91cSgIHgD2kv3zHBkGggeA0Xv/W8U5BAQPAHVH7WfpajqEcACXMzi9Rg/gy4GgNyFSIdDioIB3ACD1iCoAf8srpRIE4N/+dnMIAvB6g7kpBAH4/w5/MwgC8PYR6yYQBGD9jBsOQQDwm4xQCAKAAYS+TxCA9wEIgyAA7wcQAkEA+gC4QxCAfgCuEARgGwA3CAKwHYALBAHgABT243YBEABSgYU5+gWR72pFFbAUVAAWirA90jtje+dDQNn4DrcH9AqMnhcApFDwuAAEC4ymFwCkUPC4AAQLjKYXAKRQ8LgABAuMpj88ABQgEogdR+d45B+yR/6lvw9AAaIA2HEkIPIP2SP/BAD89bYAoBQix1EGCwApMDIXgP5/qECado0LgAB0Jcyrh9keiew577D16SsAS5T7BEoQBBB5n34MRQ5mjwtAMgEBEIB1BdgMQfbR+qMejvxD9sj/9D0ABYgCYMeRgMg/ZI/8EwB9FtT91QIoqbrGUQarArrk7H9YAPRRRH/WzC3YEkX2nHfYWhWgCsBZsvYEymCUYdzq8dbR8aUfQ+Ml5FYQAE4/2loAaAm5CQ4PAAXYK5/3noP8Y9dL3wNQgAIAFEACogxB9gIgAKtfg4kSDCWQWlBwggkAUkAAfD+OZlvCkgfao9j11ILOXgFkhwg3P3wFhCtILiAApICsuQCwCpL2ewDQ7o9pd4ad8fVsZndM4B6noL1eYcLodrV9MrNPzEQeANrFbe0CtzO+6G/V9QDQ2k+rgjO2oTsze2YyjwbQFr9sVHu8yorRrdnS2d8mcQEwQTjTXkD3/it9NwCzSmj7wZHb0Vcz+8GWTwiACUK7wvZ+dpXtEWA0wVuv/2VmT17iu7YgT6fONJdrCzqTcF6xCoCXkhvnEYCNwnmZCYCXkhvnEYCNwnmZCYCXkhvnEYCNwnmZ/QH+ksJ/Rhn39gAAAABJRU5ErkJggg==", // Este es un ejemplo de contenido Base64
                tipo: "image/png"
            ));
                    var result = await _correoService.enviar(correos, titulo, htmlTemplate, archivos);

            if (result)
            {
                return Ok("Correo enviado con éxito.");
            }
            else
            {
                return StatusCode(500, "Error al enviar el correo.");
            }
        }

    }
}
