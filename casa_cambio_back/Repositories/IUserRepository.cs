using GestionProvedores.Dto;

namespace GestionProvedores.Repositories
{
    public interface IUserRepository
    {
        TokenResponseDto Login(LoginBodyDto body);

        ResponseDto cambiarClave(string json);

        ResponseDto listar(string json);
        ResponseDto resetearClave(string json);
        ResponseDto crear(string json);
        ResponseDto actualizar(string json);
        ResponseDto eliminar(string json);
    }
}
