using Dapper;
using model; // Asegúrate de que este sea el namespace correcto para la clase "ventas"
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace data.repositorio
{
    public class ventasRepository : iVentasRepository
    {
        public readonly mysqlConfig _connection;

        public ventasRepository(mysqlConfig connection)
        {
            _connection = connection;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connection._connectionString);
        }

        public async Task<bool> deleteVenta(int id)
        {
            var db = dbConnection();
            var sql = @"delete from ventas where IDventa=@id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }

        public Task<ventas> getVentaById(int id)
        {
            var db = dbConnection();
            var consulta = @"select * from ventas where IDventa=@Id";
            return db.QueryFirstOrDefaultAsync<ventas>(consulta, new { Id = id });
        }

        public Task<IEnumerable<ventas>> getVenta()
        {
            var db = dbConnection();
            var consulta = @"select * from ventas";
            return db.QueryAsync<ventas>(consulta);
        }

        public async Task<bool> insertVenta(ventas venta)
        {
            var db = dbConnection();
            var sql = @"insert into ventas
            (IDventa, cantidadSeguros, empleados_ID, clientes_ID, tiposSeguros_IDTipoSeguro)
            values(@IDventa, @cantidadSeguros, @empleados_ID, @clientes_ID, @tiposSeguros_IDTipoSeguro)";
            var result = await db.ExecuteAsync(sql, new
            {
                venta.IDventa,
                venta.cantidadSeguros,
                venta.empleados_ID,
                venta.clientes_ID,
                venta.tiposSeguros_IDTipoSeguro
            });

            return result > 0;
        }

        public async Task<bool> updateVenta(ventas venta)
        {
            var db = dbConnection();
            var sql = @"update ventas set
                    cantidadSeguros=@cantidadSeguros,
                    empleados_ID=@empleados_ID,
                    clientes_ID=@clientes_ID,
                    tiposSeguros_IDTipoSeguro=@tiposSeguros_IDTipoSeguro
                    where IDventa=@IDventa";
            var result = await db.ExecuteAsync(sql, new
            {
                venta.IDventa,
                venta.cantidadSeguros,
                venta.empleados_ID,
                venta.clientes_ID,
                venta.tiposSeguros_IDTipoSeguro
            });
            return result > 0;
        }

    }
}

