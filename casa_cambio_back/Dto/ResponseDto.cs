using System.Net;

namespace GestionProvedores.Dto
{
    public class ResponseDto
    {
        public HttpStatusCode statusCode { get; set; }
        public int code { get; set; }
        public Object data { get; set; }
        public string message { get; set; }
    }
}
