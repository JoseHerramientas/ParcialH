using Dapper;
using model; // Asegúrate de que este sea el namespace correcto para la clase "tiposSeguros"
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace data.repositorio
{
    public class tiposSegurosRepository : iTiposSegurosRepository
    {
        public readonly mysqlConfig _connection;

        public tiposSegurosRepository(mysqlConfig connection)
        {
            _connection = connection;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connection._connectionString);
        }

        public async Task<bool> deleteTipoSeguro(int id)
        {
            var db = dbConnection();
            var sql = @"delete from tiposSeguros where IDTipoSeguro=@id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }

        public Task<tiposSeguros> getTipoSeguroById(int id)
        {
            var db = dbConnection();
            var consulta = @"select * from tiposSeguros where IDTipoSeguro=@Id";
            return db.QueryFirstOrDefaultAsync<tiposSeguros>(consulta, new { Id = id });
        }

        public Task<IEnumerable<tiposSeguros>> getTipoSeguro()
        {
            var db = dbConnection();
            var consulta = @"select * from tiposSeguros";
            return db.QueryAsync<tiposSeguros>(consulta);
        }

        public async Task<bool> insertTipoSeguro(tiposSeguros tipoSeguro)
        {
            var db = dbConnection();
            var sql = @"insert into tiposSeguros
            (IDTipoSeguro, nombreSeguro, valorSeguro, duracionMeses)
            values(@IDTipoSeguro, @nombreSeguro, @valorSeguro, @duracionMeses)";
            var result = await db.ExecuteAsync(sql, new
            {
                tipoSeguro.IDTipoSeguro,
                tipoSeguro.nombreSeguro,
                tipoSeguro.valorSeguro,
                tipoSeguro.duracionMeses
            });

            return result > 0;
        }

        public async Task<bool> updateTipoSeguro(tiposSeguros tipoSeguro)
        {
            var db = dbConnection();
            var sql = @"update tiposSeguros set
                    nombreSeguro=@nombreSeguro,
                    valorSeguro=@valorSeguro,
                    duracionMeses=@duracionMeses
                    where IDTipoSeguro=@IDTipoSeguro";
            var result = await db.ExecuteAsync(sql, new
            {
                tipoSeguro.IDTipoSeguro,
                tipoSeguro.nombreSeguro,
                tipoSeguro.valorSeguro,
                tipoSeguro.duracionMeses
            });
            return result > 0;
        }

    }
}
