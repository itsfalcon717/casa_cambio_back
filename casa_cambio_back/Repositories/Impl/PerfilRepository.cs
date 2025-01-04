using GestionProvedores.Config;
using GestionProvedores.Dto;
using GestionProvedores.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestionProvedores.Repositories.Impl
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly SqlDbContext _context;

        private readonly IHeaderService _headerService;

        public PerfilRepository(
            SqlDbContext sqlDbContext, IHeaderService headerService
        )
        {
            _context = sqlDbContext;
            _headerService = headerService;
        }

        public ResponseDto actualizarPermiso(string json)
        {
            ResponseDto response = new ResponseDto();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_actualizarPermiso";
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

        public ResponseDto buscar(string json)
        {
            ResponseDto response = new ResponseDto();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_listarPermisoPerfil";
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

        public ResponseDto listar(string json)
        {
            ResponseDto response = new ResponseDto();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_listarPerfil";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@p_json", string.IsNullOrWhiteSpace(json) ? DBNull.Value : json));
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
