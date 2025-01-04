using GestionProvedores.Config;
using GestionProvedores.Dto;
using GestionProvedores.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestionProvedores.Repositories.Impl
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly SqlDbContext _context;

        private readonly IHeaderService _headerService;

        public ProveedorRepository(
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
                command.CommandText = "sp_actualizarProveedor";
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

        public ResponseDto aprobar(string json)
        {
            ResponseDto response = new ResponseDto();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_aprobarProveedor";
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
                command.CommandText = "sp_buscarProveedor";
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

        public ResponseDto buscarErp(string json)
        {

            ResponseDto response = new ResponseDto();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_buscarProveedorErp";
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

        public ResponseDto crear(string json)
        {
            ResponseDto response = new ResponseDto();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_crearProveedor";
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
                command.CommandText = "sp_listarProveedor";
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
