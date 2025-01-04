using GestionProvedores.Dto;
using GestionProvedores.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace GestionProvedores.Config
{
    public class SqlDbContext : DbContext
    {

        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
        }

        public ResponseDto responseLista(DbDataReader reader)
        {
            string mensaje = "";
            int cod = 0;
            ResponseDto response = new ResponseDto();
            response.statusCode = HttpStatusCode.BadRequest;
            if (reader.HasRows)
            {

                if (reader.Read())
                {
                    cod = reader.GetInt32(reader.GetOrdinal("cod"));
                    mensaje = reader.GetString(reader.GetOrdinal("mensaje"));
                }
            }
            if (cod == 1)
            {
                if (reader.NextResult())
                {
                    // Leer el segundo conjunto de resultados (el resultado)
                    if (reader.HasRows)
                    {
                        var results = new List<Dictionary<string, object>>();
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string columnName = reader.GetName(i);
                                object value = reader.IsDBNull(i) ? null : reader.GetValue(i);
                                row.Add(columnName, value);
                            }
                             results.Add(row);

                           
                            //  }
                        }
                        response.data = results;
                        response.message = mensaje;
                        response.code= cod;
                        response.statusCode = HttpStatusCode.OK;
                    }
                }
            }
            else
            {
                throw new BadRequestCustomerException(mensaje);
            }
            return response;
        }

        public ResponseDto responseObjeto(DbDataReader reader)
        {
            string mensaje = "";
            int cod = 0;
            ResponseDto response = new ResponseDto();
            response.statusCode = HttpStatusCode.BadRequest;
            if (reader.HasRows)
            {

                if (reader.Read())
                {
                    cod = reader.GetInt32(reader.GetOrdinal("cod"));
                    mensaje = reader.GetString(reader.GetOrdinal("mensaje"));
                }
            }
            if (cod == 1)
            {
                if (reader.NextResult())
                {
                    // Leer el segundo conjunto de resultados (el resultado)
                    if (reader.HasRows)
                    {
                        var row = new Dictionary<string, object>();
                        if (reader.Read())
                        {
                          
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string columnName = reader.GetName(i);




                                if (reader.IsDBNull(i))
                                {

                                    if (columnName.StartsWith("num_"))
                                    {
                                        row.Add(columnName.Substring(4), new List<int>());

                                    }
                                    else if (columnName.StartsWith("jsn_"))
                                    {
                                        row.Add(columnName.Substring(4), new List<Dictionary<string, object>>());

                                    }
                                    else
                                                row.Add(columnName, null);
                                }
                                else
                                {
                                    object value = reader.GetValue(i);

                                    if (columnName.StartsWith("num_"))
                                    {
                                        row.Add(columnName.Substring(4), value.ToString().Trim('[', ']').Split(',').Select(int.Parse).ToList());

                                    }else if (columnName.StartsWith("jsn_"))
                                    {
                                        row.Add(columnName.Substring(4), getJsonList(value.ToString()));

                                    }
                                    else
                                        row.Add(columnName, value);
                                }
                              
                            }


                            //  }
                        }
                        response.data = row;
                        response.message = mensaje;
                        response.code = cod;
                        response.statusCode = HttpStatusCode.OK;
                    }
                }
            }
            else
            {
                throw new BadRequestCustomerException(mensaje);
            }
            return response;
        }

         private List<Dictionary<string, object>> getJsonList(string reader)
        {


            return JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(reader);
        }
    }
}
