using Azure;
using GestionProvedores.Dto;

namespace GestionProvedores.Services
{
    public interface IUserService
    {
        TokenResponseDto Login(LoginBodyDto body);

        ResponseDto cambiarClave(string json);

        ResponseDto listar(string json);

        ResponseDto crear(string json);

        ResponseDto actualizar(string json);

        ResponseDto eliminar(string json);

        Task<ResponseDto> resetearClave(string json);
    }
}
