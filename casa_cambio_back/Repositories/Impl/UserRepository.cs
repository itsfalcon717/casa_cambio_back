using Azure;
using GestionProvedores.Config;
using GestionProvedores.Dto;
using GestionProvedores.Exceptions;
using GestionProvedores.Services;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.Data.Common;
using System.Net;
using Microsoft.Data.SqlClient;

namespace GestionProvedores.Repositories.Impl
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlDbContext _context;
        private readonly ITokenService _itoken;
        private readonly IHeaderService _headerService;

        public UserRepository(
            SqlDbContext sqlDbContext, IHeaderService headerService, ITokenService tokenService
        )
        {
            _context = sqlDbContext;
            _headerService = headerService;
            _itoken =   tokenService;
        }
        public TokenResponseDto Login(LoginBodyDto body)
        {
            TokenResponseDto response = new TokenResponseDto();
            //string clave=Util.Util
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_validarUsuario";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@p_usuario", body.username));
                command.Parameters.Add(new SqlParameter("@p_clave", body.password));
                command.Parameters.Add(new SqlParameter("@p_idioma", _headerService.obtenerIdioma()));

                _context.Database.OpenConnection();
                string mensaje = "";
                int cod = 0;
                using (var reader = command.ExecuteReader())
                {
                   
                    if (reader.HasRows)
                    {
                        
                        if (reader.Read())
                        {
                            cod = reader.GetInt32(reader.GetOrdinal("cod"));
                            mensaje = reader.GetString(reader.GetOrdinal("mensaje"));
                        }
                    }
                    if(cod==1)
                    {
                        if (reader.NextResult())
                        {
                            // Leer el segundo conjunto de resultados (el resultado)
                            if (reader.HasRows)
                            {
                                //var results = new List<Dictionary<string, object>>();
                                if (reader.Read())
                                {
                                    var row = new Dictionary<string, object>();
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        string columnName = reader.GetName(i);
                                        object value = reader.IsDBNull(i) ? null : reader.GetValue(i);
                                        row.Add(columnName, value);
                                    }
                                    // results.Add(row);

                                    response.token = this._itoken.CreateToken(row);
                                    //  }
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new UnauthorizedCustomerException(mensaje);
                    }
                    
                }
            }

            return response;
        }

        public ResponseDto cambiarClave(string json)
        {
            ResponseDto response = new ResponseDto();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_cambiarClave";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@p_json", json));
                command.Parameters.Add(new SqlParameter("@p_idioma", _headerService.obtenerIdioma()));

                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {

                    response = _context.responseLista(reader);
                }
            }

            return response;
        }

        public ResponseDto resetearClave(string json)
        {
            ResponseDto response = new ResponseDto();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_resetearClave";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@p_json", json));
                command.Parameters.Add(new SqlParameter("@p_idioma", _headerService.obtenerIdioma()));

                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {

                    response = _context.responseObjeto(reader);
                }
            }

            return response;
        }

        public ResponseDto listar(string json)
        {
            ResponseDto response = new ResponseDto();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_listarUsuarioPerfil";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@p_json", string.IsNullOrWhiteSpace(json) ? "{}" : json));
                command.Parameters.Add(new SqlParameter("@p_idioma", _headerService.obtenerIdioma()));

                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {

                    response = _context.responseLista(reader);
                }
            }

            return response;
        }

        public ResponseDto crear(string json)
        {
            ResponseDto response = new ResponseDto();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_crearUsuario";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@p_json", json));
                command.Parameters.Add(new SqlParameter("@p_idioma", _headerService.obtenerIdioma()));

                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {

                    response = _context.responseLista(reader);
                }
            }

            return response;
        }

        public ResponseDto actualizar(string json)
        {
            ResponseDto response = new ResponseDto();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_actualizarUsuario";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@p_json", json));
                command.Parameters.Add(new SqlParameter("@p_idioma", _headerService.obtenerIdioma()));

                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {

                    response = _context.responseLista(reader);
                }
            }

            return response;
        }

        public ResponseDto eliminar(string json)
        {
            ResponseDto response = new ResponseDto();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_eliminarUsuario";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@p_json", json));
                command.Parameters.Add(new SqlParameter("@p_idioma", _headerService.obtenerIdioma()));

                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {

                    response = _context.responseObjeto(reader);
                }
            }

            return response;
        }
    }
}
