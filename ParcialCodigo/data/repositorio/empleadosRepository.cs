using Dapper;
using model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace data.repositorio
{
    public class empleadosRepository : iEmpleadosRepository
    {
        public readonly mysqlConfig _connection;
        public empleadosRepository(mysqlConfig connection)
        {
            _connection = connection;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connection._connectionString);
        }
        //aca inicia el completo//
        public Task<IEnumerable<empleados>> getEmpleados()
        {
            var db = dbConnection();
            var consulta = @"select * from empleados";
            return db.QueryAsync<empleados>(consulta);
        }

        public Task<empleados> getEmpleadosById(int id)
        {
            var db = dbConnection();
            var consulta = @"select * from empleados where ID=@Id";
            return db.QueryFirstOrDefaultAsync<empleados>(consulta, new { Id = id });
        }

        public async Task<bool> insertEmpleados(empleados empleado)
        {
            var db = dbConnection();
            var sql = @"insert into empleados
            (ID, nombre, cedula, edadEmpleado, Salario)
            values(@Id,@Nombre, @Cedula, @Edad, @Salario)";
            var result = await db.ExecuteAsync(sql, new
            {
                empleado.ID,
                empleado.nombre,
                empleado.cedula,
                empleado.edadEmpleado,
                empleado.Salario
            });

            return result > 0;
        }

        public async Task<bool> updateEmpleados(empleados empleado)
        {
            var db = dbConnection();
            var sql = @"update empleados set
                    ID=@Id,
                    nombre=@Nombre,
                    cedula=@Cedula,
                    edadEmpleado=@Edad,
                    Salario=@Salario,
                    where (ID=@Id)";
            var result = await db.ExecuteAsync(sql, new
            {
                empleado.ID,
                empleado.nombre,
                empleado.cedula,
                empleado.edadEmpleado,
                empleado.Salario
            });
            return result > 0;
        }

        public async Task<bool> deleteEmpleados(int id)
        {
            var db = dbConnection();
            var sql = @"delete from empleados where ID=@id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }
    }
}
