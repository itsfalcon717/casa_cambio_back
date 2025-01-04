using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace GestionProvedores.Dto
{
    public class LoginBodyDto
    {
        public BigInteger id { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }
    }
}
