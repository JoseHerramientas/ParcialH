using Dapper;
using model; // Asegúrate de que este sea el namespace correcto para la clase "clientes"
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace data.repositorio
{
    public class clientesRepository : iClientesRepository
    {
        public readonly mysqlConfig _connection;

        public clientesRepository(mysqlConfig connection)
        {
            _connection = connection;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connection._connectionString);
        }

        public async Task<bool> deleteCliente(int id)
        {
            var db = dbConnection();
            var sql = @"delete from clientes where ID=@id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }

        public Task<clientes> getClienteById(int id)
        {
            var db = dbConnection();
            var consulta = @"select * from clientes where ID=@Id";
            return db.QueryFirstOrDefaultAsync<clientes>(consulta, new { Id = id });
        }

        public Task<IEnumerable<clientes>> getClientes()
        {
            var db = dbConnection();
            var consulta = @"select * from clientes";
            return db.QueryAsync<clientes>(consulta);
        }

        public async Task<bool> insertCliente(clientes cliente)
        {
            var db = dbConnection();
            var sql = @"insert into clientes
            (ID, nombre, cedula, edad, cantidadMiembrosFamilia)
            values(@Id,@nombre, @cedula, @edad, @cantidadMiembrosFamilia)";
            var result = await db.ExecuteAsync(sql, new
            {
                cliente.ID,
                cliente.nombre,
                cliente.cedula,
                cliente.edad,
                cliente.cantidadMiembrosFamilia
            });

            return result > 0;
        }

        public async Task<bool> updateCliente(clientes cliente)
        {
            var db = dbConnection();
            var sql = @"update clientes set
                    nombre=@nombre,
                    cedula=@cedula,
                    edad=@edad,
                    cantidadMiembrosFamilia=@cantidadMiembrosFamilia
                    where ID=@Id";
            var result = await db.ExecuteAsync(sql, new
            {
                cliente.ID,
                cliente.nombre,
                cliente.cedula,
                cliente.edad,
                cliente.cantidadMiembrosFamilia
            });
            return result > 0;
        }
    }
}
