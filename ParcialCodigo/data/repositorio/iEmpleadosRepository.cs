using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.repositorio
{
    public interface iEmpleadosRepository
    {
        Task<IEnumerable<empleados>> getEmpleados();
        Task<empleados> getEmpleadosById(int id);
        Task<bool> insertEmpleados(empleados empleado);
        Task<bool> updateEmpleados(empleados empleado);
        Task<bool> deleteEmpleados(int id);
    }
}