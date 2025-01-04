using GestionProvedores.Dto;
using GestionProvedores.Repositories;
using GestionProvedores.Repositories.Impl;
using System.Collections.Generic;
using System.Text.Json;


namespace GestionProvedores.Services.Impl
{
    public class UserService : IUserService
    {

        private readonly ICorreoService _correoService;

        private readonly IUserRepository _userRepository;

        public UserService(
          IUserRepository userRepository, ICorreoService correoService
        )
        {
            _userRepository = userRepository;
            _correoService = correoService;
        }

        public ResponseDto actualizar(string json)
        {
            return _userRepository.actualizar(json);
        }

        public ResponseDto cambiarClave(string json)
        {
            return _userRepository.cambiarClave(json);
        }

        public ResponseDto crear(string json)
        {
            return _userRepository.crear(json);
        }

        public ResponseDto eliminar(string json)
        {
            return _userRepository.eliminar(json);
        }

        public ResponseDto listar(string json)
        {
            return _userRepository.listar(json);
        }

        public TokenResponseDto Login(LoginBodyDto body)
        {
            return _userRepository.Login(body);
        }

        public async Task<ResponseDto> resetearClave(string json)
        {
            var response =  _userRepository.resetearClave(json);
            if (response.code > 0)
            {
                var jsonObject = JsonSerializer.Deserialize<dynamic>(json);

                Dictionary<string, object> data = response.data as Dictionary<string, object>;

                string pPlantilla = data["plantilla"].ToString();
                data.Remove("plantilla");

                List<string> correos = new List<string>();
                correos.Add(jsonObject.GetProperty("correo").GetString());


                await _correoService.enviar(correos, "Restablecer Contraseña", pPlantilla, null);

            }

            return response;
        }

    }
}
