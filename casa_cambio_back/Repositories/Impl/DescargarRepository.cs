using Azure;
using GestionProvedores.Config;
using GestionProvedores.Dto;
using GestionProvedores.Exceptions;
using GestionProvedores.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestionProvedores.Repositories.Impl
{
    public class DescargarRepository : IDescargarRepository
    {
        private readonly SqlDbContext _context;

        private readonly IHeaderService _headerService;

        public DescargarRepository(
            SqlDbContext sqlDbContext, IHeaderService headerService
        )
        {
            _context = sqlDbContext;
            _headerService = headerService;
        }

        public ResponseDto descargar(string json)
        {
            ResponseDto response = new ResponseDto();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_buscarDescarga";
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
