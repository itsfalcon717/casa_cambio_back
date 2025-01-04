using GestionProvedores.Config;
using GestionProvedores.Dto;
using GestionProvedores.Services;
using GestionProvedores.Services.Impl;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestionProvedores.Repositories.Impl
{
    public class CatalogoRepository: ICatalogoRepository
    {
        private readonly SqlDbContext _context;

        private readonly IHeaderService _headerService;

        public CatalogoRepository(
            SqlDbContext sqlDbContext, IHeaderService headerService
        )
        {
            _context = sqlDbContext;
            _headerService = headerService;
        }

        public ResponseDto actualizar(string json)
        {
            ResponseDto response = new ResponseDto();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_actualizarCatalogo";
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

        public ResponseDto crear(string json)
        {
            ResponseDto response = new ResponseDto();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_crearCatalogo";
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
                command.CommandText = "sp_eliminarCatalogo";
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
                command.CommandText = "sp_listarCatalogo";
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
