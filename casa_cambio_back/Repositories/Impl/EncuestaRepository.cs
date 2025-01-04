using GestionProvedores.Config;
using GestionProvedores.Dto;
using GestionProvedores.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestionProvedores.Repositories.Impl
{
    public class EncuestaRepository : IEncuestaRepository
    {
        private readonly SqlDbContext _context;

        private readonly IHeaderService _headerService;

        public EncuestaRepository(
            SqlDbContext sqlDbContext, IHeaderService headerService
        )
        {
            _context = sqlDbContext;
            _headerService = headerService;
        }
        public ResponseDto buscar(string json)
        {
            ResponseDto response = new ResponseDto();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_buscarEncuesta";
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

        public ResponseDto finalizar(string json)
        {
            ResponseDto response = new ResponseDto();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_finalizarEncuesta";
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

        public ResponseDto respuesta(string json)
        {
            ResponseDto response = new ResponseDto();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_respuestaEncuesta";
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

        public ResponseDto validar(string json)
        {
            ResponseDto response = new ResponseDto();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_validarEncuesta";
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
    }
}
